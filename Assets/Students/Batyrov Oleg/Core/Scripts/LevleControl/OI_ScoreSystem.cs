using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_ScoreSystem : MonoBehaviour
    {
        [SerializeField] Transform _player;
        public int _score;
        [SerializeField ]private TextMeshProUGUI _textMeshPro;
        private void Start()
        {
            _textMeshPro.alignment = TextAlignmentOptions.Top;
        }
        void Update()
        {
            if (_player.position.y >= _score)
                _score = (int)_player.position.y;
            _textMeshPro.text = ($"Score: {_score}");
        }
    }
}

