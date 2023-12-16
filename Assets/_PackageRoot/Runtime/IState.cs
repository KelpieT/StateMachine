namespace MyStateMachine
{
    public interface IState
    {
        void StartState();
        void UpdateState();
        void EndState();
    }
}