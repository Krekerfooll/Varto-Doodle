using Students.Shupa_Dubrova_Artem.Scripts.Player;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Utils
{
    public class BuffStar : OnTriggerEnterAction
    {
        [SerializeField] private float _buffJumpPower;
        [SerializeField] private PlayerController _playerController;
        
        public override void Execute()
        {
            ExecuteStar();
        }

        private void ExecuteStar()
        {
            _playerController = Collider.gameObject.GetComponent<PlayerController>();

            _playerController.SetJumpPower(_buffJumpPower);
            
            Destroy(gameObject);
        }
    }
}
