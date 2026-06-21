using Room;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private GameObject playerPrefab;
    private void Awake()
    {
        GameContext gameContext = new GameObject("GameContext").AddComponent<GameContext>();
        
        GameObject uiInstance = Instantiate(uiPrefab);
        UIManager uiManager = uiInstance.GetComponentInChildren<UIManager>();
        
        GameObject roomInstance = Instantiate(roomPrefab);
        RoomManager roomManager = roomInstance.GetComponentInChildren<RoomManager>();

        GameObject player = Instantiate(playerPrefab);
        
        StateManager stateManager = new GameObject("StateManager").AddComponent<StateManager>();
        
        gameContext.SetStateManager(stateManager);
        gameContext.SetUIManager(uiManager);
        gameContext.SetRoomManager(roomManager);
        gameContext.SetPlayer(player);
        
        player.SetActive(false);
        uiManager.Initialize();
        stateManager.Initialize();
        roomManager.Init();
    }
}
