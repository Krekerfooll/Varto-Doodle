using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

namespace Ustich.Arthur.DoodleJump
{
    public class PlayAudioCollisionAction : ActionBaseCollisionEvent
    {
        [Space]
        [Header("Audio Configuration")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField, Range(0f, 1f)] private float _volume = 1f;

        [SerializeField] private float _playDelay;
        [SerializeField] private bool _playWithDelay;
        [SerializeField] private bool _playWithotSource;

        public override void ExecuteInternal()
        {
            if (!_playWithDelay)
            {
                PlayAudio();
                return;
            }

            if (_playWithDelay)
            {
                StartCoroutine(PlayAudioWithDelay());
                return;
            }
        }

        private void PlayAudio()
        {
            if (_playWithotSource)
            {
                AudioSource.PlayClipAtPoint(_audioClip, transform.position, _volume);
                return;
            }

            if (_audioClip != null)
                _audioSource.clip = _audioClip;

            _audioSource.volume = _volume;
            _audioSource.loop = false;
            _audioSource.Play();
        }

        IEnumerator PlayAudioWithDelay()
        {
            yield return new WaitForSeconds(_playDelay);
            PlayAudio();
        }
    }
}