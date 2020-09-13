using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerTracker _playerTracker;
    [SerializeField] private GameObject[] _playerPrefabs;
    [SerializeField] private int _indexSpawnBox;
    [SerializeField] private Path _path;

    private Transform _spawnPosition;
    private Player _player;

    public UnityAction<Player> PlayerSpawned;

    private void Start()
    {
        _spawnPosition = _path.PathPoints[_indexSpawnBox];
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject prefabPlayer = Instantiate(_playerPrefabs[PlayerPrefs.GetInt("Skin")], _spawnPosition.position, Quaternion.Euler(0, 90, 0));
        _player = prefabPlayer.GetComponent<Player>();
        _player.Init(_path, _indexSpawnBox, _joystick);
        _playerTracker.SetPlayerTransform(_player.transform);
        PlayerSpawned?.Invoke(_player);
    }
}
