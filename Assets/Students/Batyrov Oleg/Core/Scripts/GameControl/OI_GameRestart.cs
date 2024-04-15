using UnityEngine;
using UnityEngine.SceneManagement;

namespace OIMOD.Core.Component
{
    public class OI_GameRestart : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) || (Input.GetKeyDown(KeyCode.KeypadEnter)))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

