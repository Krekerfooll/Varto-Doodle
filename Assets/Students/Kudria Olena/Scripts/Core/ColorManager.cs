using System.Collections.Generic;
using Students.Kudria_Olena.Scripts.Platforms;
using UnityEngine;

namespace Students.Kudria_Olena.Scripts.Core
{
    public class ColorManager : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> platforms;
        [SerializeField] private SpriteRenderer player;
        [SerializeField] private SpriteRenderer background;
        
        private void OnEnable() => PlatformTrigger.OnPlatformTrigger += ChangeColor;
        
        private void ChangeColor()
        {
            foreach (SpriteRenderer platform in platforms)
                platform.color = GetRandomColor();
            
            player.color = GetRandomColor();
            background.color = GetRandomColor();
        }

        private static Color GetRandomColor()
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);
            
            return new Color(r, g, b);
        }
        
        private void OnDisable() => PlatformTrigger.OnPlatformTrigger -= ChangeColor;
    }
}