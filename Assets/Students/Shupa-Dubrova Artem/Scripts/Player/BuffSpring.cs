using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class BuffSpring : BuffBase
    {
        [SerializeField] private GameObject _playerTarget;
        [SerializeField] private float _springJumpPower;
        
        public override void ApplyBuff(GameObject target)
        {
           
        }
    }
}
