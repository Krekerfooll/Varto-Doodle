using UnityEngine;

namespace Students.Drobiniak_Volodymyr.Scripts.PlatformScripts
{
    public class PlatformChangeColor : MonoBehaviour
    {
        private Renderer _platformRenderer;
        private Color _baseColor = Color.green; 
    
        private void Start()
        {
            _platformRenderer = GetComponent<Renderer>();
            _platformRenderer.material.color = _baseColor;        
        }


        /// <summary>
        /// Color change to random when in contact with another object
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _platformRenderer.material.color = Random.ColorHSV();
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
          _platformRenderer.material.color = _baseColor;
        }
    }
}
