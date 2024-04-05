using UnityEngine;

public class BackgoundChange : MonoBehaviour
{
    [SerializeField] private SpriteRenderer [] Backgrounds = new SpriteRenderer [3];
    private int _random;
    
    public void BackgoundsChange()
    {
        Backgrounds[_random].enabled = false;
            _random = Random.Range(0, Backgrounds.Length);
            Backgrounds[_random].enabled = true;
    }  
}
