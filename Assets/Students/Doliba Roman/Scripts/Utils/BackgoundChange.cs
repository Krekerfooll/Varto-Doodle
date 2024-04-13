using UnityEngine;

namespace RomanDoliba.Utils
{
    public class BackgoundChange : OnTriggerAction
    {
        [SerializeField] private SpriteRenderer[] _backgrounds;
        private int _currentBackground;
        
        public void BackgoundsChange()
        {
            _backgrounds[_currentBackground].enabled = false;
                _currentBackground = Random.Range(0, _backgrounds.Length);
                _backgrounds[_currentBackground].enabled = true;
        }

        protected override void Execute()
        {
            BackgoundsChange();
        }
        
    }
}
