using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public abstract class ButtonActionBase : ActionBase
    {
        [SerializeField] protected List<GameObject> _objectToEnable = new List<GameObject>();
        [SerializeField] protected List<GameObject> _objectToDisable = new List<GameObject>();

        protected void DisableEnableObjects()
        {
            foreach (GameObject obj in _objectToEnable)
                obj.SetActive(true);

            foreach (GameObject obj in _objectToDisable)
                obj.SetActive(false);
        }
    }
}