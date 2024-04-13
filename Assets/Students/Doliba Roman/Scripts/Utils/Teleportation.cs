using UnityEngine;

namespace RomanDoliba.Utils
{
    public class Teleportation : OnTriggerAction
    {
        [SerializeField] private Transform _destination;
        [SerializeField] private bool _teleportToPoint;
        [SerializeField] private bool _fromBoundToBound;

        private void Teleport()
        {
            if (_teleportToPoint)
            {
                LastCollider.transform.position = new Vector3(_destination.position.x, _destination.position.y, _destination.position.z);
            }
            else if (_fromBoundToBound)
            {
                var currentPosition = LastCollider.transform.position;
                if (currentPosition.x < 0)
                {
                    LastCollider.transform.position = new Vector3(currentPosition.x * -1 - 0.1f, currentPosition.y, currentPosition.z);
                }
                else
                {
                    LastCollider.transform.position = new Vector3(currentPosition.x * -1 + 0.1f, currentPosition.y, currentPosition.z);
                } 
            }
        }

        protected override void Execute()
        {
            Teleport();
        }
    }
}
