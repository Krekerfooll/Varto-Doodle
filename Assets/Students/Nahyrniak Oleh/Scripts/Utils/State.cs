using System.Collections.Generic;
using UnityEngine;

namespace Doodle.Utils
{
    public class State : MonoBehaviour
    {
        public enum States
        {
            Enter = 1, 
            Hold = 2, 
            Exit = 3, 
            Reverse = 4
        }

        [Header("Executor based on Condition")]
        [SerializeField] private Condition _condition;

        [SerializeField] private List<Action> _executeOnEnter;
        [SerializeField] private List<Action> _executeOnHold;
        [SerializeField] private List<Action> _executeOnExit;
        [SerializeField] private List<Action> _executeOnReverse;

        private bool _conditionPrevious;
        private bool _conditionCurrent;

        public States CurrentState { get; protected set; }
        protected virtual void CalcStateOnCondition()
        {
            if(!_condition)
            {
                CurrentState = States.Hold;
                return;
            }

            _conditionPrevious = _conditionCurrent;
            _conditionCurrent = _condition.Check();

            switch ((_conditionPrevious, _conditionCurrent))
            {
                case (true, true): CurrentState = States.Hold; break;
                case (false, true): CurrentState = States.Enter; break;
                case (true, false): CurrentState = States.Exit; break;
                case (false, false): CurrentState = States.Reverse; break;
            }
        }

        private void Update()
        {
            CalcStateOnCondition();

            switch (CurrentState)
            {
                case States.Enter: EnterState(); break;
                case States.Exit: ExitState(); break;
                case States.Hold: HoldState(); break;
                case States.Reverse: ReverseState(); break;
            }
        }

        protected virtual void EnterState()
        {
            foreach (var action in _executeOnEnter) { action.Execute(); }
        }
        protected virtual void HoldState()
        {
            foreach (var action in _executeOnHold) { action.Execute(); }
        }
        protected virtual void ExitState()
        {
            foreach (var action in _executeOnExit) { action.Execute(); }
        }
        protected virtual void ReverseState()
        {
            foreach (var action in _executeOnReverse) { action.Execute(); }
        }
    }
}
