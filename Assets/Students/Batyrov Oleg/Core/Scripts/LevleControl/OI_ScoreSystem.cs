using TMPro;
using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_ScoreSystem : MonoBehaviour
    {
        [SerializeField] Transform _player;
        [SerializeField ]private TextMeshProUGUI _scoreText;

        private int _score;

        private void Start() => _scoreText.alignment = TextAlignmentOptions.Top;
        void Update()
        {
            if (_player.position.y >= _score)
                _score = (int)_player.position.y;
            _scoreText.text = ($"Score: {_score}");
        }
    }
}

