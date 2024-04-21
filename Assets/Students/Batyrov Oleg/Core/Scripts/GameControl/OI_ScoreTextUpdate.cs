using TMPro;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_ScoreTextUpdate : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;
        private enum scoreDataType { totalScore = 0, hightScore = 1, bonusScore = 2, recordScore = 3 };
        [SerializeField] private scoreDataType _selectedScoreType = scoreDataType.totalScore;
        [SerializeField] private TextMeshProUGUI[] _scoreText;

        private int _currentScore;

        void Update()
        {
            switch ( _selectedScoreType )
            {
                case scoreDataType.totalScore:
                    _currentScore = gameData.gameScore;
                    break;
                case scoreDataType.hightScore:
                    _currentScore = gameData.hightScore;
                    break;
                case scoreDataType.bonusScore:
                    _currentScore = gameData.bonusScore;
                    break;
                case scoreDataType.recordScore:
                    _currentScore = gameData.gameRecordScore;
                    break;
            }

            for (int i = 0; i <= _scoreText.Length - 1; i++)
                _scoreText[i].text = ($"{_currentScore}");
        }
    }
}

