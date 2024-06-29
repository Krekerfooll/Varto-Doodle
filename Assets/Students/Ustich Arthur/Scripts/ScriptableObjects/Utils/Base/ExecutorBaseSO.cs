using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    [CreateAssetMenu(fileName = "ExecutorSO", menuName = "CommandPattern/Executor", order = 2)]

    public class ExecutorBaseSO : ScriptableObject
    {
        [SerializeField] private ActionBaseSO[] _actionsSO;
        [SerializeField] private ConditionBaseSO _conditionSO;

        public void Execute(object data = null)
        {
            if (_conditionSO == null || _conditionSO.Check())
            {
                foreach (var action in _actionsSO)
                {
                    action.Execute(data);
                }
            }
        }
    }
}