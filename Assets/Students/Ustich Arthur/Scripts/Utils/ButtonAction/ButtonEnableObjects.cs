using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ButtonEnableObjects : ActionBase
    {
        [SerializeField] private List<GameObject> _gameObjectToEnable = new List<GameObject>();

        public override void ExecuteInternal()
        {
            EnableObjects();
        }

        private void EnableObjects()
        {
            foreach (GameObject obj in _gameObjectToEnable)
                obj.SetActive(true);
        }
    }
}