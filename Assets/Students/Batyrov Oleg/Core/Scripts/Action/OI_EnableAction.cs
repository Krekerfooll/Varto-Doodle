using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_EnableAction : OI_ActionBase
    {
        [SerializeField] public GameObject[] _target;
        [SerializeField] private float delay;
        protected override void ExecuteInternal()
        {
            if (_target != null)
                foreach (GameObject target in _target) target.SetActive(true);
        }
    }
}