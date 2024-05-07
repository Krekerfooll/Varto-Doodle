using Examples.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text swordText;
    [SerializeField] private TMP_Text shieldText;
    [SerializeField] private TMP_Text boolText;
    [SerializeField] private TMP_Text spearText;

    [SerializeField] private Button swordButton;
    [SerializeField] private Button shieldButton;
    [SerializeField] private Button boolButton;
    [SerializeField] private Button spearButton;

    public int swordCount { get; private set; }
    public int shieldCount { get; private set; }
    public int boolCount { get; private set; }
    public int spearCount { get; private set; }

    private void OnEnable()
    {
        GlobalEventSender.OnEvent += OnAnyGlobalEvent;

        swordButton.onClick.AddListener(UseSwordBuff);
        shieldButton.onClick.AddListener(UseShieldBuff);
        boolButton.onClick.AddListener(UseBoolBuff);
        spearButton.onClick.AddListener(UseSpearBuff);
    }

    private void OnDisable()
    {
        GlobalEventSender.OnEvent -= OnAnyGlobalEvent;

        swordButton.onClick.RemoveListener(UseSwordBuff);
        shieldButton.onClick.RemoveListener(UseShieldBuff);
        boolButton.onClick.RemoveListener(UseBoolBuff);
        spearButton.onClick.RemoveListener(UseSpearBuff);
    }

    private void OnAnyGlobalEvent(string eventName)
    {
        if (eventName.StartsWith("Buff_"))
        {
            UpdateBuffCount(eventName);
            UpdateUI();
        }
    }

    private void UpdateBuffCount(string buffName)
    {
        switch (buffName)
        {
            case "Buff_Sword":
                swordCount++;
                break;
            case "Buff_Shield":
                shieldCount++;
                break;
            case "Buff_Bool":
                boolCount++;
                break;
            case "Buff_Spear":
                spearCount++;
                break;
            default:
                Debug.Log("Unknown buff type: " + buffName);
                break;
        }
    }

    public void UseSwordBuff()
    {
        if (swordCount > 0)
        {
            swordCount--;
            UpdateUI();
        }
    }

    public void UseShieldBuff()
    {
        if (shieldCount > 0)
        {
            shieldCount--;
            UpdateUI();
        }
    }

    public void UseBoolBuff()
    {
        if (boolCount > 0)
        {
            boolCount--;
            UpdateUI();
        }
    }

    public void UseSpearBuff()
    {
        if (spearCount > 0)
        {
            spearCount--;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        swordText.text = $"Swords: {swordCount}";
        shieldText.text = $"Shields: {shieldCount}";
        boolText.text = $"Bools: {boolCount}";
        spearText.text = $"Spears: {spearCount}";
    }
}