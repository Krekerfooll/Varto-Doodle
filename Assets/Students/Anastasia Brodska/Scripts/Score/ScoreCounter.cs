using UnityEngine;

public class ScoreCounter : PlatformOnColision
{
    [SerializeField] private int _score = 0;
    private GameObject _trackedObject;

    public void SetTrackedObject(GameObject trackedObject)
    {
        _trackedObject = trackedObject;
    }

    protected override void ExecuteInternal()
    {
        
        if (LastCollision.gameObject == _trackedObject)
        {
            _score++;
        }
    }

    private void Update()
    {
        Debug.Log("Score: " + _score.ToString());
    }
}
