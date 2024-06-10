using UnityEngine;

namespace RomanDoliba.Utils
{
    public class BGMusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSourse;
        [SerializeField] private float _mixRate;
        [SerializeField] private AudioClip[] _audioClips;
        private int _currentClipIndex = 0;
        private bool _isEnoughTimeToPlayNext => _audioSourse.clip.length - _mixRate <= _audioSourse.time;
        void Update()
        {
            if (!_audioSourse.isPlaying || (_audioSourse.isPlaying && _isEnoughTimeToPlayNext))
            {
                _audioSourse.clip = _audioClips[_currentClipIndex];
                _audioSourse.Play();
                _currentClipIndex = GetNextClipIndex(_currentClipIndex, _audioClips.Length);
            }
        }

        private int GetNextClipIndex(int current, int length)
        {
            var next = current + 1;
            if (next < length)
            {
                return next;
            }
            else
            {
                return 0;
            }
        }
    }
}
