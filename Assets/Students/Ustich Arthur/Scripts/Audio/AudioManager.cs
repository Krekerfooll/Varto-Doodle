using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ustich.Arthur.DoodleJump
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private GameObject _backGroundMusic;
        private int activeIndex = 0;
        private int inactiveIndex = 0;

        private void OnEnable()
        {
            activeIndex = 0;
            inactiveIndex = 0;
        }

        private void Update()
        {
            switch (GetCurrentScene())
            {
                case 0:
                    if(inactiveIndex == 0)
                    {
                        _backGroundMusic.SetActive(false);
                        inactiveIndex++;
                    }
                    break;
                case 1:
                    if (activeIndex == 0)
                    {
                        _backGroundMusic.SetActive(true);
                        activeIndex++;
                    }
                    break;
            }
        }

        private int GetCurrentScene()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
}