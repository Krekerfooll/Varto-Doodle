using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Ustich.Arthur.DoodleJump
{
    public class ChangeTextAction : ActionBase
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private int _score;
        public System.Action<int> ChangeScore;

        private void Awake()
        {
            _scoreText.text = _score.ToString();
        }

        private void OnEnable()
        {
            GameSettingsManager.Instance.ChangeTextAction = this;
        }

        private void Update() => ExecuteInternal();

        public override void ExecuteInternal() => ChangeText();

        private void ChangeText()
        {
            if (_target != null && _target.transform.position.y > _score)
            {
                _score = (int)_target.transform.position.y;
                ChangeScore?.Invoke(_score);
                _scoreText.text = _score.ToString();
            }
        }
    }
}