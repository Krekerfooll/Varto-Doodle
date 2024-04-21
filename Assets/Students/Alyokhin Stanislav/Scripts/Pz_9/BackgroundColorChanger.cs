using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField] Color starsColor;
    [SerializeField] Color endColor;
    [Space]
    [SerializeField] float duration = 3f;

    //private float time = 0;
    void Update()
    {
        float t = Mathf.PingPong(Time.time /  duration, 1 );
        Camera.main.backgroundColor = Color.Lerp(starsColor, endColor, t);
        // if (time < duration)
        // {
        //     Camera.main.backgroundColor = Color.Lerp(starsColor, endColor, time / duration);
        //     time += Time.deltaTime;
        // }
    }
}
