using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ButtonDisableObjects : ActionBase
    {
        [SerializeField] private List<GameObject> _gameObjectToDisable = new List<GameObject>();

        public override void ExecuteInternal()
        {
            DisableObjects();
        }

        private void DisableObjects()
        {
            foreach (GameObject obj in _gameObjectToDisable)
                obj.SetActive(false);
        }
    }
}