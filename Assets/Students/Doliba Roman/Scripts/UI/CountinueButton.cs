using UnityEngine;
using UnityEngine.UI;

namespace RomanDoliba.UI
{
    public class CountinueButton : MonoBehaviour
    {
        [SerializeField] private Button _countinueButton;
        [SerializeField] private RectTransform _pauseScreen;

        private void Awake()
        {
            _countinueButton.onClick.AddListener(Countinue);
        }

        private void Countinue()
        {
            _pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
