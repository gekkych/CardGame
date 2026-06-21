using UnityEngine;

namespace GameState
{
    public class ExploreState : IGameState
    {
        public void OnStateEnter()
        {
            GameContext.Instance.UIManager.ShowGamePanel();
            GameContext.Instance.RoomManager.On();
            GameContext.Instance.Player.transform.position = new Vector3(5, 0, 5);
            GameContext.Instance.Player.SetActive(true);
        }

        public void OnStateExit()
        {
            GameContext.Instance.RoomManager.Off();
            GameContext.Instance.Player.SetActive(false);
        }

        public void StateUpdate()
        {
        }
    }
}