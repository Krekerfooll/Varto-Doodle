using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Artur.Pashchenko.Utils;
namespace Artur.Pashchenko.Conditions
{
    public class CollisionCondition : MonoBehaviour
    {
        [SerializeField] public GameObject _target;
        [SerializeField] ActionBase[] _actions;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collided");
            if (collision.gameObject == _target) 
            {
                Debug.Log("Check done");
                for (int i = 0; i < _actions.Length; i++)
                {
                    _actions[i].Execute();
                    Debug.Log("Done");
                }

            }
        }


    }

}