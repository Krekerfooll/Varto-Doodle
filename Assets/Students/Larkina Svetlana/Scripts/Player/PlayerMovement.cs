using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float jumpHeight = 4f;
    public float jumpDistance = 2.5f;
    public float controllPointY = 7.0f;

    public float jumpSpeed = 1.2f;

    private Rigidbody2D rb;


    private Vector3 _startingPoint;
    private Vector3 _controlPoint;
    private Vector3 _endingPoint;
    private float count = 10.0f;
    private bool _isControllFree = true;
    private bool _canDie = false;

    private Vector3 _estmatedPlayerPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        _startingPoint = transform.position;
    }

    void Update()
    {
        //Debug.Log(rb.velocity.y);

        if (count < 1f)
        {
            count += jumpSpeed * Time.deltaTime;
            Vector3 m1 = Vector3.Lerp(_startingPoint, _controlPoint, count);
            Vector3 m2 = Vector3.Lerp(_controlPoint, _endingPoint, count);
            transform.localPosition = Vector3.Lerp(m1, m2, count);
            _isControllFree = false;
        }
        if (!_isControllFree) {
            if (rb.velocity.y == 0f && count >= 1f)
            {
                _isControllFree = true;
                //Debug.Log($"_startTransformPosition: {_estmatedPlayerPosition}");
                //Debug.Log($"transform.position: {transform.position}");
            }
        }

        /*if(_canDie)
        {
            if (transform.position.y <= _startingPoint.y && _canDie)
            {
                Debug.Log("You DIED!!!!");
            }
        }*/

        if (Input.GetKey(KeyCode.LeftArrow) && _isControllFree)
        {
            //Debug.Log($"ButtonPressed: LeftArrow");
            _startingPoint = transform.position;
            _endingPoint = transform.position;
            _endingPoint.y += jumpHeight;
            _endingPoint.x -= jumpDistance;

            _controlPoint = _startingPoint + (_endingPoint - _startingPoint) / 2 + Vector3.up * controllPointY;
            _estmatedPlayerPosition = _endingPoint;
            count = 0.0f;
            _canDie = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && _isControllFree)
        {
            //Debug.Log($"ButtonPressed: RightArrow");
            _startingPoint = transform.position;
            _endingPoint = transform.position;
            _endingPoint.y += jumpHeight;
            _endingPoint.x += jumpDistance;

            _controlPoint = _startingPoint + (_endingPoint - _startingPoint) / 2 + Vector3.up * controllPointY;
            _estmatedPlayerPosition = _endingPoint;
            count = 0.0f;
            _canDie = true;
        }

    }
}