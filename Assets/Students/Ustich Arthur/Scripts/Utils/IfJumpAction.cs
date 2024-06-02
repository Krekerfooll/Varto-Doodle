using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class IfJumpAction : ActionBase
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _clip;
        [SerializeField, Range(0f, 1f)] private float _volume = 1f;
        [SerializeField] private bool _playWithoutSource;

        public override void ExecuteInternal()
        {
            if (_playWithoutSource)
            {
                AudioSource.PlayClipAtPoint(_clip, transform.position, _volume);
                return;
            }

            if(_clip != null)
                _audioSource.clip = _clip;

            _audioSource.volume = _volume;
            _audioSource.loop = false;
            _audioSource.Play();
        }
    }
}