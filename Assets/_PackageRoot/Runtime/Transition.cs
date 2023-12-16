namespace MyStateMachine
{
    public class Transition<TState, TComand>
    {
        public TState currentState;
        public TState nextState;
        public TComand command;

        public Transition(TState currentState, TState nextState, TComand command)
        {
            this.currentState = currentState;
            this.nextState = nextState;
            this.command = command;
        }
    }
}
