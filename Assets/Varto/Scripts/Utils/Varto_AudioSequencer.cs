using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Varto.Examples.Utils
{
    public class Varto_AudioSequencer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _mixRate;
        [SerializeField] private AudioClip[] _audioClips;
        [Space]
        [SerializeField] private bool _shuffle;

        private int _currentClipIndex = 0;
        private bool _IsEnoughTimeToPlayNextClip => _audioSource.clip.length - _mixRate <= _audioSource.time;

        private void Start()
        {
            if (_shuffle)
            {
                for (int i = _audioClips.Length - 1; i > 0; i--)
                {
                    var randomIndex = UnityEngine.Random.Range(0, _audioClips.Length);

                    var temp = _audioClips[i];
                    _audioClips[i] = _audioClips[randomIndex];
                    _audioClips[randomIndex] = temp;
                }
            }
        }

        private void Update()
        {
            if (!_audioSource.isPlaying || (_audioSource.isPlaying && _IsEnoughTimeToPlayNextClip)) 
            {
                _audioSource.clip = _audioClips[_currentClipIndex];
                _audioSource.Play();
                _currentClipIndex = GetNextLoopedIndex(_currentClipIndex, _audioClips.Length);
            }
        }

        private int GetNextLoopedIndex(int current, int length)
        {
            var next = current + 1;
            return next < length ? next : 0;
        }
    }
}
