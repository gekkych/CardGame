namespace GameState
{
    public interface IGameState
    {
        void OnStateEnter();
        void OnStateExit();
        void StateUpdate();
    }
}