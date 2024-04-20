using Students.Drobiniak_Volodymyr.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

namespace Students.Drobiniak_Volodymyr.Scripts.UI
{
    public class UI_Manager : MonoBehaviour
    {
        [SerializeField] private NewPlayerController playerScript;
        [SerializeField] private TextMeshProUGUI scoreText;
        private void Update()
        {
            string gemCountString = playerScript.gemCounter.ToString();
            scoreText.text = $"GEMS: {gemCountString}";
        }
    }
}


