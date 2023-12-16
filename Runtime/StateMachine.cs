using System.Collections.Generic;
using System.Linq;

namespace MyStateMachine
{
    public class StateMachine<TState, TComand>
    {
        private TState currentState;
        private List<Transition<TState, TComand>> transitions = new List<Transition<TState, TComand>>();
        private Dictionary<TState, IState> states = new Dictionary<TState, IState>();

        
        /// <summary>
        /// Example initialization:
        /// List<Transition<EnemyMoveStateEnum, EnemyCommand>> transitions = new List<Transition<EnemyMoveStateEnum, EnemyCommand>>()
        // {
        //     new Transition<EnemyMoveStateEnum, EnemyCommand>(EnemyMoveStateEnum.Idle,EnemyMoveStateEnum.Idle,EnemyCommand.Idle),
        // };

        // Dictionary<EnemyMoveStateEnum, IState> states = new Dictionary<EnemyMoveStateEnum, IState>();
        // states.Add(EnemyMoveStateEnum.Idle, new IdleEnemyState(this));

        // moveLayerStateMachine = new StateMachine<EnemyMoveStateEnum, EnemyCommand>(states, transitions);
        /// </summary>
        /// <param name="states"></param>
        /// <param name="transitions"></param>
        public StateMachine(Dictionary<TState, IState> states, List<Transition<TState, TComand>> transitions)
        {
            this.states = states;
            this.transitions = transitions;
        }

        public TState CurrentState { get => currentState; }

        private TState GetNextState(TComand command)
        {
            var v = transitions.FirstOrDefault(x => command.Equals(x.command) && currentState.Equals(x.currentState));
            if (v == null)
            {
                return default;
            }
            return v.nextState;
        }

        private IState GetState(TState state)
        {
            return states[state];
        }

        public IState GetNextStateByCommand(TComand command)
        {
            TState stateEnum = GetNextState(command);
            IState nextState = GetState(stateEnum);
            currentState = stateEnum;
            return nextState;
        }

    }
}


