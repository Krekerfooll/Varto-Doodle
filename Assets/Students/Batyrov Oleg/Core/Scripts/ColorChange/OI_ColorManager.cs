using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_ColorManager : OI_InputManager
    {
        [Header("Colorized Targets Setup")]
        [SerializeField] private SpriteRenderer[] colorManager;
        [SerializeField] OI_MoveManager player;
        [Space]
        [Header("Color Pallete Setup")]
        [SerializeField] Color[] colorPallete;

        private void Update() {
            ChangeColorOnJump();
        }
        public void ChangeColorOnJump() {
            foreach (SpriteRenderer spriteRenderer in colorManager)
            {
                Color baseColor = spriteRenderer.color;
                Color targetColor = colorPallete[player.colorIndex];

                spriteRenderer.color = Color.Lerp(baseColor,targetColor, 1.5f * Time.deltaTime);

            }
        }
    }
}

