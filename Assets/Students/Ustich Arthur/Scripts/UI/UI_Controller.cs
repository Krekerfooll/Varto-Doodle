using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [Header("TextForFormating")]
    [SerializeField] private List<TextMeshProUGUI> _textMeshProUGUIs = new List<TextMeshProUGUI>();

    private void Awake()
    {
        FontResize();
    }

    private void FontResize()
    {
        float maxFontSize = _textMeshProUGUIs[0].fontSize;
        foreach (TextMeshProUGUI tempText in _textMeshProUGUIs)
        {
            if(tempText.fontSize > maxFontSize)
                maxFontSize = tempText.fontSize;
        }

        for (int i = 0; i < _textMeshProUGUIs.Count; i++)
        {
            _textMeshProUGUIs[i].enableAutoSizing = false;
            _textMeshProUGUIs[i].fontSize = maxFontSize;
        }
    }
}