using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField]
    private float life = 100f; 
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpStrength = 10f;

    public float Life
    {
        get { return life; }
        set { life = Mathf.Max(0, value); }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = Mathf.Max(0, value); }
    }

    // сила прыжка
    public float JumpStrength
    {
        get { return jumpStrength; }
        set { jumpStrength = Mathf.Max(0, value); }
    }

    void Start()
    {

    }

    void Update()
    {
       
    }
}