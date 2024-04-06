using UnityEngine;

namespace PVitaliy
{
    public class BoundsController : MonoBehaviour
    {
        [SerializeField] private Collider2D leftWall;
        [SerializeField] private Collider2D rightWall;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Globals.IsPlayer(other.gameObject))
            {
                var moveToX = 0f;
                if (leftWall.IsTouching(other))
                {
                    moveToX = rightWall.ClosestPoint(other.transform.position).x + other.transform.localScale.x / 1.99f;
                }
                else
                {
                    moveToX = leftWall.ClosestPoint(other.transform.position).x - other.transform.localScale.x / 1.99f;
                }

                var origPosition = other.gameObject.transform.position;
                other.gameObject.transform.position = new Vector3(moveToX, origPosition.y, origPosition.z);
            }
        }
    }
}