using UnityEngine;

namespace SmartPoint.Components
{
    public class AudioChannel
    {
        private AudioChannelType _type;
        private AudioSource _source;
        private float _volume;

        public AudioChannel(AudioChannelType type, AudioSource source)
        {
            _volume = 1.0f;
            _type = type;
            _source = source;
            ResetVolume();
        }

        public AudioClip clip { get => _source != null ? _source.clip : null; set => _source.clip = value; }
        public float time { get => _source != null ? _source.time : 0.0f; set => _source.time = value; }
        public float volume
        {
            get => _volume;
            set
            {
                _volume = value;
                ResetVolume();
            }
        }
        public bool isPlaying { get => _source.isPlaying; }

        public void Play()
        {
            status = AudioChannelStatus.Start;
        }

        public void Stop()
        {
            status = AudioChannelStatus.Stop;
        }

        public void Pause()
        {
            status = AudioChannelStatus.Pause;
        }

        public void ResetVolume()
        {
            switch (_type)
            {
                case AudioChannelType.Stream:
                    _source.volume = AudioPlayer.globalStreamVolume * _volume;
                    break;

                case AudioChannelType.Effect:
                    _source.volume = AudioPlayer.globalEffectVolume * _volume;
                    break;

                case AudioChannelType.Voice:
                    _source.volume = AudioPlayer.globalVoiceVolume * _volume;
                    break;

                default:
                    _source.volume = 0.0f * _volume;
                    break;
            }
        }

        public AudioSource source { get => _source; }
        public AudioChannelStatus status { get; set; }
        public float duration { get; set; }
        public float elapsedTime { get; set; }
    }
}