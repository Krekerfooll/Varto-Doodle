using UnityEngine;
using UnityEngine.UI;

namespace RomanDoliba.UI
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private RectTransform _pauseScreen;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(SetPause);
        }

        private void SetPause()
        {
            _pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
