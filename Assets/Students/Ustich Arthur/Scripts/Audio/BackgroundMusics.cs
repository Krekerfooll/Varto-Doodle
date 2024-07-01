using UnityEngine;

public class BackgroundMusics : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private float _mixRate;
    [SerializeField] private bool _shuffle;

    private int _currentClipIndex = 0;

    //private bool _IsEnoughTimeToPlayClip  => _audioSource.clip.length - _mixRate <= _audioSource.time;
    [SerializeField] private bool _IsEnoughTimeToPlayClip;

    private void Start()
    {
        _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length - 1)];
        _audioSource.Play();

        if (_shuffle)
        {
            for (int i = _audioClips.Length - 1; i > 0; i--)
            {
                var randomIndex = Random.Range(0, _audioClips.Length);

                var temp = _audioClips[i];
                _audioClips[i] = _audioClips[randomIndex];
                _audioClips[randomIndex] = temp;
            }
        }
    }

    private void Update()
    {
        CheckTimeToPlay();
        PlayAudio();
    }

    private void PlayAudio()
    {
        if (!_audioSource.isPlaying || (_audioSource.isPlaying && _IsEnoughTimeToPlayClip))
        {
            _audioSource.clip = _audioClips[_currentClipIndex];
            _audioSource.Play();
            _currentClipIndex = GetNextLoopedIndex(_currentClipIndex, _audioClips.Length);
        }
    }

    private int GetNextLoopedIndex(int currentID, int lenght)
    {
        var next = currentID + 1;
        return next < lenght ? next : 0;
    }

    private void CheckTimeToPlay()
    {
        if (_audioSource.clip.length - _mixRate <= _audioSource.time)
            _IsEnoughTimeToPlayClip = true;
        else
            _IsEnoughTimeToPlayClip = false;
    }
}