using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class RainbowEffect : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _color1;
        [SerializeField] private Color _color2;
        [SerializeField] private float _speedOfChange;

        private void LateUpdate()
        {
            RainbowBuff();
        }

        private void RainbowBuff()
        {
            _spriteRenderer.color = Color.Lerp(_color1, _color2, Mathf.PingPong(Time.time * _speedOfChange, 1));
        }
    }
}

