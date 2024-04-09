using UnityEngine;

namespace RomanDoliba.Background
{
    public class BackgoundChange : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer [] Backgrounds = new SpriteRenderer [3];
        private int _currentBackground;
        
        public void BackgoundsChange()
        {
            Backgrounds[_currentBackground].enabled = false;
                _currentBackground = Random.Range(0, Backgrounds.Length);
                Backgrounds[_currentBackground].enabled = true;
        }  
    }
}
