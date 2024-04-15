using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlayerBorderLimit : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;

        private void Update() => BorderCheck();
        private void BorderCheck()
        {
            if (gameData.playerInstance == null) return;

            var playerTransform = gameData.playerInstance.transform;
            var playerPos = gameData.playerInstance.transform.position;
            var borderLeft = gameData.levelBorderLeft.transform.position.x;
            var borderRight = gameData.levelBorderRight.transform.position.x;

            if (playerPos.x < borderLeft)
                playerTransform.position = new Vector3(borderRight, playerPos.y, 0);
            else if (playerPos.x > borderRight)
                playerTransform.position = new Vector3(borderLeft, playerPos.y, 0);
        }
    }
}

