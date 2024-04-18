using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public void UpdateScore(int value)
    {
        scoreText.text = value.ToString();
    }
}
