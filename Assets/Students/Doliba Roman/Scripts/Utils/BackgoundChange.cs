using UnityEngine;

namespace RomanDoliba.Utils
{
    public class BackgoundChange : OnTriggerAction
    {
        [SerializeField] private SpriteRenderer [] Backgrounds = new SpriteRenderer [3];
        private int _currentBackground;
        
        public void BackgoundsChange()
        {
            Backgrounds[_currentBackground].enabled = false;
                _currentBackground = Random.Range(0, Backgrounds.Length);
                Backgrounds[_currentBackground].enabled = true;
        }

        protected override void Execute()
        {
            BackgoundsChange();
        }
    }
}
