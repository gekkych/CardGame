using Room;
using UnityEngine;

public class GameContext : MonoBehaviour
{
    public static GameContext Instance { get; private set; }
    
    private StateManager _stateManager;
    private UIManager _uiManager;
    private RoomManager _roomManager;
    private GameObject _player;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void SetStateManager(StateManager stateManager) { _stateManager = stateManager; }
    public void SetUIManager(UIManager uiManager) { _uiManager = uiManager; }
    public void SetRoomManager(RoomManager roomManager) { _roomManager = roomManager; }
    public void SetPlayer(GameObject player) { _player = player; }
    
    public StateManager StateManager => _stateManager;
    public UIManager UIManager => _uiManager;
    public RoomManager RoomManager => _roomManager;
    public GameObject Player => _player;
}