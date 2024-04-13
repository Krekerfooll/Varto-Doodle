using System;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class BuffSpring : BuffBase
    {
        [SerializeField] private Rigidbody2D _playerTarget;
        [SerializeField] private float _springJumpPower;
        
        public override void ApplyBuff()
        {
           
        }

        private void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}
