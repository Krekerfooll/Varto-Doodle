using UnityEngine;

namespace RomanDoliba.Utils
{
    public class PlaySoundOnJump : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField, Range(0f, 1f)] private float _volume = 1f;

        private void Update()
        {
            if (_inputManager.JumpInput)
            {
                _audioSource.volume = _volume;
                _audioSource.PlayOneShot(_audioClip);
            }
        }
    }
}
