using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using SmartPoint.AssetAssistant;

namespace SmartPoint.Components
{
    public class AudioPlayer
    {
        private static Dictionary<string, AudioClip> _clipTable = new Dictionary<string, AudioClip>(StringComparer.CurrentCultureIgnoreCase);
        private static AudioChannel[] _streamChannels = new AudioChannel[2];
        private static AudioChannel[] _effectChannels = new AudioChannel[16];
        private static AudioChannel[] _voiceChannels = new AudioChannel[4];
        private static AudioListener _audioListener = null;
        private static AudioListener _currentAudioListener = null;
        private static float _globalStreamVolume = 1.0f;
        private static float _globalEffectVolume = 1.0f;
        private static float _globalVoiceVolume = 1.0f;
        private static Dictionary<string, AudioListener> _listenerTables = new Dictionary<string, AudioListener>();
        private static AudioChannel[][] _channelList;

        private static void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            GameObject[] rootGameObjects = scene.GetRootGameObjects();

            for (int i = 0; i < rootGameObjects.Length; i++)
            {
                var audioListeners = rootGameObjects[i].GetComponentsInChildren<AudioListener>();

                AudioListener current = null;
                for (int j = 0; j < audioListeners.Length; j++)
                {
                    var audioListener = audioListeners[j];
                    var workCurrent = current;

                    if (audioListener.enabled)
                    {
                        if (current != null)
                            workCurrent = current;
                        else
                            workCurrent = audioListener;

                        audioListener.enabled = false;
                    }

                    if (j + 1 < audioListeners.Length)
                        current = workCurrent;
                }

                if (current != null)
                {
                    if (_listenerTables.ContainsKey(scene.path))
                        _listenerTables[scene.path] = current;
                    else
                        _listenerTables.Add(scene.path, current);
                }

                if (_currentAudioListener != null)
                {
                    if (_currentAudioListener.gameObject.scene == scene)
                        _currentAudioListener = _audioListener;
                }
            }
        }

        [AssetAssistantInitializeMethod]
        private static void Initialize()
        {
            // Empty
        }

        private static void OnBeforeSceneChanged(SceneEntity currentScene, SceneEntity targetScene)
        {
            if (_listenerTables.TryGetValue(targetScene.path, out AudioListener listener))
            {
                _currentAudioListener.enabled = false;
                listener.enabled = true;
                _currentAudioListener = listener;
            }
            else
            {
                if (_currentAudioListener != _audioListener && _currentAudioListener != null)
                {
                    _currentAudioListener.enabled = false;
                    _currentAudioListener = _audioListener;
                    _currentAudioListener.enabled = true;
                }
            }
        }

        public static float globalStreamVolume
        {
            get => _globalStreamVolume;
            set
            {
                _globalStreamVolume = value;
                for (int i=0; i<_streamChannels.Length; i++)
                    _streamChannels[i].ResetVolume();
            }
        }
        public static float globalEffectVolume
        {
            get => _globalEffectVolume;
            set
            {
                _globalEffectVolume = value;
                for (int i=0; i<_effectChannels.Length; i++)
                    _effectChannels[i].ResetVolume();
            }
        }
        public static float globalVoiceVolume
        {
            get => _globalVoiceVolume;
            set
            {
                _globalVoiceVolume = value;
                for (int i=0; i<_voiceChannels.Length; i++)
                    _voiceChannels[i].ResetVolume();
            }
        }

        private static bool IsExistReservation(AudioChannel[] channels, AudioClip clip)
        {
            for (int i=0; i<channels.Length; i++)
            {
                var channel = channels[i];
                if (channel != null && channel.status == AudioChannelStatus.Start)
                {
                    if (channel.clip == clip)
                        return true;
                }
            }

            return false;
        }

        private static AudioChannel GetEmptyChannel(AudioChannel[] channels)
        {
            for (int i=0; i<channels.Length; i++)
            {
                if (channels[i] != null && channels[i].status == AudioChannelStatus.Empty)
                    return channels[i];
            }

            return null;
        }

        public static AudioChannel PlayEffect(string soundName, float pitch = 1.0f)
        {
            if (!_clipTable.TryGetValue(soundName, out AudioClip clip))
                return null;

            if (IsExistReservation(_effectChannels, clip))
                return null;

            var channel = GetEmptyChannel(_effectChannels);

            if (channel == null)
                return null;

            channel.source.clip = clip;
            channel.source.pitch = pitch;
            channel.volume = 1.0f;
            channel.status = AudioChannelStatus.Start;
            channel.duration = 0.0f;

            return channel;
        }

        public static AudioChannel CrossFadeStreamDirect(AudioClip clip, float duration = 2.0f, float time = 0.0f)
        {
            var channel1 = _streamChannels[0];

            if (channel1 == null)
                return null;

            var channel2 = _streamChannels[1];

            _streamChannels[0] = channel2;
            _streamChannels[1] = channel1;

            StopStream(1, duration);

            channel2.source.clip = clip;
            channel2.source.time = time;
            channel2.volume = 0.0f;
            channel2.duration = duration;
            channel2.status = AudioChannelStatus.Start;
            channel2.source.loop = true;

            return channel2;
        }

        public static AudioChannel PlayStreamDirect(int channelIndex, AudioClip clip, float time = 0.0f)
        {
            var channel = _streamChannels[channelIndex];

            if (channel == null)
                return null;

            channel.source.clip = clip;
            channel.source.time = time;
            channel.status = AudioChannelStatus.Start;
            channel.duration = 0.0f;

            return channel;
        }

        public static (AudioChannel, AudioChannel) PlayStreamWithIntro(string introStreamName, string loopStreamName)
        {
            var introChannel = PlayStream(1, introStreamName);
            var loopChannel = PlayStream(0, loopStreamName);

            introChannel.source.PlayScheduled(AudioSettings.dspTime);
            introChannel.source.loop = false;
            introChannel.status = AudioChannelStatus.Empty;

            loopChannel.source.PlayScheduled(AudioSettings.dspTime + ((float)introChannel.source.clip.samples / introChannel.source.clip.frequency));
            loopChannel.status = AudioChannelStatus.Empty;

            return (introChannel, loopChannel);
        }

        public static AudioChannel PlayStream(int channelIndex, string soundName, float time = 0.0f)
        {
            if (!_clipTable.TryGetValue(soundName, out AudioClip clip))
                return null;

            if (_streamChannels[channelIndex] == null)
                return null;

            var channel = _streamChannels[channelIndex];
            channel.source.clip = clip;
            channel.source.time = time;
            channel.duration = 0.0f;
            channel.volume = 1.0f;

            return channel;
        }

        public static void StopStream(int channelIndex, float duration)
        {
            var channel = _streamChannels[channelIndex];

            if (channel == null)
                return;

            if (channel.clip == null)
                return;

            channel.status = duration != 0.0f ? AudioChannelStatus.Mute : AudioChannelStatus.Stop;
            channel.duration = duration;
            channel.elapsedTime = 0.0f;
        }

        public static void PauseStream(int channelIndex)
        {
            var channel = _streamChannels[channelIndex];

            if (channel == null)
                return;

            if (channel.clip == null)
                return;

            channel.status = AudioChannelStatus.Pause;
        }

        private static void Update(float deltaTime)
        {
            for (int i=0; i<_channelList.Length; i++)
            {
                var channelGroup = _channelList[i];
                for (int j=0; j<channelGroup.Length; j++)
                {
                    var channel = channelGroup[j];
                    if (channel == null)
                        continue;

                    channel.elapsedTime += deltaTime;

                    switch (channel.status)
                    {
                        case AudioChannelStatus.Start:
                            channel.source.Play();
                            channel.status = channel.duration <= 0.0f ? AudioChannelStatus.Playing : AudioChannelStatus.FadeIn;
                            channel.elapsedTime = 0.0f;
                            break;

                        case AudioChannelStatus.Playing:
                            if (!channel.source.isPlaying)
                            {
                                channel.status = AudioChannelStatus.Stop;
                                channel.elapsedTime = 0.0f;
                            }
                            break;

                        case AudioChannelStatus.Pause:
                            channel.source.Pause();
                            channel.status = AudioChannelStatus.Wait;
                            channel.elapsedTime = 0.0f;
                            break;

                        case AudioChannelStatus.FadeIn:
                            channel.volume = Math.Min(channel.elapsedTime / channel.duration, 1.0f);
                            if (channel.volume == 1.0f)
                            {
                                channel.status = AudioChannelStatus.Playing;
                                channel.elapsedTime = 0.0f;
                            }
                            break;

                        case AudioChannelStatus.Mute:
                            channel.volume = 1.0f - Math.Min(channel.elapsedTime / channel.duration, 1.0f);
                            if (channel.volume == 0.0f)
                            {
                                channel.status = AudioChannelStatus.Stop;
                                channel.elapsedTime = 0.0f;
                            }
                            break;

                        case AudioChannelStatus.Stop:
                            channel.source.Stop();
                            channel.status = AudioChannelStatus.Empty;
                            channel.source.clip = null;
                            channel.elapsedTime = 0.0f;
                            break;

                        default:
                            continue;
                    }
                }
            }
        }

        public static void OnDestroy()
        {
            _clipTable.Clear();
        }

        public static bool AddClip(string clipName, AudioClip clip)
        {
            if (clip == null)
                return false;

            if (_clipTable.TryGetValue(clipName, out AudioClip _))
                return false;

            _clipTable.Add(clipName, clip);
            return true;
        }

        public static void RemoveClip(string clipName)
        {
            if (_clipTable.ContainsKey(clipName))
                _clipTable.Remove(clipName);
        }
    }
}