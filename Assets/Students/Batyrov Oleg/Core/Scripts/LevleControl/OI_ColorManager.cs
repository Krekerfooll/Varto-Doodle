using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_ColorManager : OI_InputManager
    {
        [Header("Colorized Targets Setup")]
        [SerializeField] public List<SpriteRenderer> layerToChangeColor;
        [SerializeField] private GameObject _platformHolder;
        [SerializeField] OI_MoveManager player;
        [SerializeField] private bool _colorChangeOn;
        [Space]
        [Header("Color Pallete Setup")]
        [SerializeField] Color[] colorPallete;

        private void Update() {
            ChangeColorOnJump();
        }
        public void ChangeColorOnJump()
        {
            layerToChangeColor.RemoveAll(SpriteRenderer => SpriteRenderer == null);
            if (_colorChangeOn) {
                foreach (SpriteRenderer spriteRenderer in layerToChangeColor)  {
                    Color baseColor = spriteRenderer.color;
                    Color targetColor = colorPallete[player.colorIndex];

                    spriteRenderer.color = Color.Lerp(baseColor, targetColor, 1.5f * Time.deltaTime);
                }
            }
        }
    }
}

