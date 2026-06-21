namespace GameState
{
    public class MenuState : IGameState
    {
        public void OnStateEnter()
        {
            GameContext.Instance.UIManager.ShowMenuPanel();
        }

        public void OnStateExit()
        {
            
        }

        public void StateUpdate()
        {
            
        }
    }
}