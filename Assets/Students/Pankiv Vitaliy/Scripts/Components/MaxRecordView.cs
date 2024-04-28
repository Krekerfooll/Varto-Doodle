using PVitaliy.Core;
using TMPro;
using UnityEngine;

public class MaxRecordView : MonoBehaviour
{
    public static string RecordKey = "player_max_record";
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void Awake()
    {
        GlobalEvents.AddAction(EventNames.NewRecordSet, OnNewRecordSet);
        scoreText.text = PlayerPrefs.GetInt(RecordKey).ToString();
    }

    private void OnNewRecordSet(object value)
    {
        scoreText.text = value.ToString();
        PlayerPrefs.SetInt(RecordKey, (int)value);
    }
}
