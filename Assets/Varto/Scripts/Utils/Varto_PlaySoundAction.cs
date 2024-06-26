using UnityEngine;

namespace Varto.Examples.Utils
{
    public class Varto_PlaySoundAction : Varto_OnCollisionEventsActionBase
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField, Range(0f, 1f)] private float _volume = 1f;
        [SerializeField] private bool _loop = false;
        [Space]
        [SerializeField] private bool _playWithoutSource;

        protected override void ExecuteInternal()
        {
            if (_playWithoutSource) 
            {
                AudioSource.PlayClipAtPoint(_audioClip, transform.position, _volume);
                return;
            }

            if (_audioClip != null)
                _audioSource.clip = _audioClip;

            _audioSource.volume = _volume;
            _audioSource.loop = _loop;
            _audioSource.Play();
        }
    }
}
