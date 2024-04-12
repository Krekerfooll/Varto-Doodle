using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_GameData : MonoBehaviour
    {
        [Header("Player Data")]
        [SerializeField] public GameObject playerInstance;
        [SerializeField] public GameObject playerRender;
        [SerializeField] public SpriteRenderer playerSpriteRender;
        [SerializeField] public Animator playerRenderAnimator;
        [Space]
        [SerializeField] public Rigidbody2D playerRigidBody;
        [SerializeField] public float playerSpeed;
        [SerializeField] public int playerJumpForce;
        [SerializeField] public float playerMaxVelocity;
        [SerializeField] public bool playerAutoJump;
        [Space]
        [SerializeField] public GameObject playerFloorTarget;
        [SerializeField] public GameObject rayPosLeft;
        [SerializeField] public GameObject rayPosCenter;
        [SerializeField] public GameObject rayPosRight;
        [SerializeField] public float jumpRayDist;
        [SerializeField] public LayerMask layerMask;
        [Space]
        [Header("Level Data")]
        [SerializeField] public int gameScore;
        [Space]
        [SerializeField] public GameObject levelBorderLeft;
        [SerializeField] public GameObject levelBorderRight;
        [SerializeField] public GameObject levelBorderDown;
        [Space]
        [SerializeField] public Color[] colorPalette;
        [Space]
        [Header("Platform Generator")]
        [SerializeField] public Transform spawnPosition;
        [SerializeField] public GameObject spawnPlaceholder;
    }
}

