using System;
using Students.Shupa_Dubrova_Artem.Scripts.Utils;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class RainbowEffect : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color[] _colors;
        [SerializeField] private float _speedOfChange;

        private Color _lerpedColor;

        private void LateUpdate()
        {
            RainbowBuff();
        }

        protected void RainbowBuff()
        {
            _spriteRenderer.color = Color.Lerp(_colors[0], _colors[1], Mathf.PingPong(Time.time * _speedOfChange, 1));
        }
    }
}

