using System.Collections.Generic;
using UnityEngine;

namespace Room
{

    // This is a very important class
    // Its purpose to manage all infinity room system
    public class RoomManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _roomPrefabs;
        [SerializeField] private int _poolSizePerPrefab = 3;
        private List<RoomController> _pool = new List<RoomController>();
        private RoomController _lastRoom;
        private RoomController _currentRoom; 
        private bool active = false;
        
        private void InitializePool()
        {
            int idCounter = 0;
            foreach (var prefab in _roomPrefabs)
            {
                for (int i = 0; i < _poolSizePerPrefab; i++)
                {
                    GameObject instance = Instantiate(prefab);
                    RoomController room = instance.GetComponentInChildren<RoomController>();
                    room.Id = idCounter++;
                    room.onEnter += OnPlayerEnteredRoom;
                    room.ReturnToDepo(); 
                    _pool.Add(room);
                }
            }
        }

        private void OnPlayerEnteredRoom(RoomController room)
        {
            if (!active) {return;}
            if (room == _currentRoom) return;
            if (_lastRoom != null && _lastRoom != room)
            {
                _lastRoom.ReturnToDepo();
            }
            _lastRoom = _currentRoom;
            _currentRoom = room;
            SpawnNext();
        }
        
        private void SpawnNext()
        {
            RoomController next = GetRandomFreeRoom();
            next.gameObject.SetActive(true);
            next.Teleport(_currentRoom.Exit);
        }
        
        private RoomController GetRandomFreeRoom()
        {
            var freeRooms = _pool.FindAll(r => !r.IsEntered && r != _currentRoom);
            return freeRooms[Random.Range(0, freeRooms.Count)];
        }

        public void Init()
        {
            InitializePool();
        }

        public void On()
        {
            active = true;
            _currentRoom = GetRandomFreeRoom();
            _currentRoom.gameObject.SetActive(true);
            _currentRoom.transform.position = Vector3.zero;
            SpawnNext();
        }

        public void Off()
        {
            active = false;
            _currentRoom = null;
        }
    }
}