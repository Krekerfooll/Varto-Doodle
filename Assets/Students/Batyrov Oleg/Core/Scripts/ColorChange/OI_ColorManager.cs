using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_ColorManager : OI_InputManager
    {
        [Header("Colorized Targets Setup")]
        [SerializeField] private SpriteRenderer[] colorManager;
        [SerializeField] public List<SpriteRenderer> layerToChangeColor;
        [SerializeField] private GameObject _platformHolder;
        [SerializeField] OI_MoveManager player;
        [Space]
        [Header("Color Pallete Setup")]
        [SerializeField] Color[] colorPallete;

        private void Update() {
           // FillPlatformsToList();
            ChangeColorOnJump();
        }
        private void FillPlatformsToList()
        {
            int childCount = _platformHolder.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = _platformHolder.transform.GetChild(i);
                layerToChangeColor.Add(child.GetComponentInChildren<SpriteRenderer>());
            }
            

        }
        public void ChangeColorOnJump()
        {
            for (int i = layerToChangeColor.Count-1;  i >= 0; i--)
            {
                if (layerToChangeColor[i] == null)
                    layerToChangeColor.RemoveAt(i);
            }

            foreach (SpriteRenderer spriteRenderer in layerToChangeColor)
            {
                Color baseColor = spriteRenderer.color;
                Color targetColor = colorPallete[player.colorIndex];

                spriteRenderer.color = Color.Lerp(baseColor, targetColor, 1.5f * Time.deltaTime);
            }
        }
    }
}

