using Dpr.Message;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.Movie
{
    public class EndingPlayer : MonoBehaviour
    {
        private RawImage _fadeImage;
        private UnityAction _endCallback;
        private StaffrollPlayer _staffrollPlayer;
        private EndingState _state;
        private float _timeCounter;
        private bool _enableSkip;
        private const float _waitInputTime = 0;
#if PEARL
        private bool _diaVersion = false;
#else
        private bool _diaVersion = true;
#endif
        private MessageEnumData.MsgLangId _lang = MessageEnumData.MsgLangId.JPN;
        private bool _male = true;
        private int _bodyType;
        private MoviePlayer _moviePlayer;
        private string _moviePath;
        private string _logoPath;
        private string _endTextPath;
        private bool _isLoadedAssets;

        // TODO
        public void Initialize(MoviePlayer moviePlayer, bool diaVersion, MessageEnumData.MsgLangId lang, bool male, int bodyType, RawImage fadeImage, UnityAction endCallback, StaffrollPlayer staffrollPlayer) { }

        // TODO
        private IEnumerator LoadAssets() { return null; }

        // TODO
        private void UnloadAssets() { }

        // TODO
        public void Play() { }

        // TODO
        public IEnumerator PlayEnding() { return null; }

        // TODO
        private IEnumerator EndEnding() { return null; }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private string GetMoviePath() { return ""; }

        // TODO
        private void GetLogoPath(out string path, out string name)
        {
            path = "";
            name = "";
        }

        // TODO
        private void GetEndTextPath(out string path, out string name)
        {
            path = "";
            name = "";
        }

        // TODO
        private void PlayBGM() { }

        // TODO
        private void StopBGM() { }

        private enum EndingState : int
        {
            None = 0,
            PlayingMovie = 1,
            WaitInput = 2,
            End = 3,
        }
    }
}
