using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ustich.Arthur.DoodleJump
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private GameObject _backGroundMusic;

        private void Update()
        {
            switch (GetCurrentScene())
            {
                case 0:
                    _backGroundMusic.SetActive(false);
                    break;
                default:
                    _backGroundMusic.SetActive(true);
                    break;
            }
        }

        private int GetCurrentScene()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
}