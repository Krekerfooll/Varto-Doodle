using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    private bool _onCollisin;
    public bool OnCollisin 
    { 
        get => _onCollisin; 
        private set => _onCollisin = value; 
    }

    private void Start()
    {
        OnCollisin = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisin = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnCollisin = false;
    }
}
