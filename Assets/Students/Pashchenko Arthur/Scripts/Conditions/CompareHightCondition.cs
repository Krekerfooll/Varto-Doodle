using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Artur.Pashchenko.Utils;

namespace Artur.Pashchenko.Conditions
{
    public class CompareHightCondition : MonoBehaviour
    {
        [SerializeField] public GameObject _target;
        [SerializeField] private GameObject _instance;
        [SerializeField] private ActionBase[] _instanceIsHighterAction;
        [SerializeField] private ActionBase[] _targetIsHighterAction;
        [SerializeField] private float _distanceForExecute;

        private void Update()
        {
            float _targetPositionY = _target.transform.position.y;
            float _instancePositionY = _instance.transform.position.y;

            if (_instancePositionY > _targetPositionY + _distanceForExecute) 
            {
                for (int i = 0; i < _instanceIsHighterAction.Length; i++)
                {
                    _instanceIsHighterAction[i].Execute();
                }
            }
            else if (_instancePositionY < _targetPositionY) 
            {
                for (int i = 0; i < _targetIsHighterAction.Length; i++)
                {
                    _targetIsHighterAction[i].Execute();
                }
            }
        }
       
    }
    
}