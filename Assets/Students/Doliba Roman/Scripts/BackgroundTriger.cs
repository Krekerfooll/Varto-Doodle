using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundTriger : MonoBehaviour
{
    [SerializeField] private BackgoundChange backgoundChange;
    private void OnCollisionEnter2D(Collision2D other)
    {
        backgoundChange.BackgoundsChange();
    }
}
