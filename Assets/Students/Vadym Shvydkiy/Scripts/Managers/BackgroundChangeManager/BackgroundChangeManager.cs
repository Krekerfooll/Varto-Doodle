using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChangeManager : MonoBehaviour
{
    [SerializeField] private Image[] backgroundImages;
    private void ChangeBackgroundColor()
    {
        foreach (var image in backgroundImages)
        {
            image.color = Random.ColorHSV();
        }
    }

    public void CallChangeBackgroundColor()
    {
        ChangeBackgroundColor();
    }
}
