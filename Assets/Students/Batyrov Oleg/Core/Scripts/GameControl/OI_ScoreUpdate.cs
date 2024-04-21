using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_ScoreUpdate : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;
        void Update()
        {
            if (gameData.playerInstance == null) return;

            var playerPosY = gameData.playerInstance.transform.position.y;
            if (playerPosY >= gameData.hightScore)
                gameData.hightScore = (int)playerPosY;
            gameData.gameScore = gameData.hightScore + gameData.bonusScore;

            if (gameData.gameScore > gameData.gameRecordScore)
                gameData.gameRecordScore = gameData.gameScore;
        }
    }
}

