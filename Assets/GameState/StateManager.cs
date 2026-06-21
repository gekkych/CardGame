using GameState;
using UnityEngine;

public enum GameStateKind {MENU, EXPLORE, SHOP}

public class StateManager : MonoBehaviour
{
    MenuState menuState = new MenuState();
    ExploreState exploreState = new ExploreState();
    ShopState shopState = new ShopState();
    private IGameState _currGameState;

    public void Initialize()
    {
        changeState(GameStateKind.MENU);
    }
    
    public IGameState getGameState()
    {
        return _currGameState;
    }

    public void changeState(GameStateKind newState)
    {
        _currGameState?.OnStateExit();
        
        switch (newState)
        {
            case GameStateKind.MENU:
                _currGameState = menuState;
                break;
            case GameStateKind.EXPLORE:
                _currGameState = exploreState;
                break;
            case GameStateKind.SHOP:
                _currGameState = shopState;
                break;
        }
        
        _currGameState?.OnStateEnter();
    }
    
    void Update()
    {
        _currGameState?.StateUpdate();
    }
}
