using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class GameOverAction : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private List<ActionBase> _actions = new List<ActionBase>();

        private void Update()
        {
            if (_target == null)
            {
                foreach (var action in _actions)
                    action.Execute();
            }
        }
    }
}