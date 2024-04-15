using TMPro;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_ScoreTextUpdate : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;
        [SerializeField] private TextMeshProUGUI[] _scoreText;

        void Update()
        {
            for (int i = 0; i <= _scoreText.Length - 1; i++)
                _scoreText[i].text = ($"Score: {gameData.gameScore}");
        }
    }
}

