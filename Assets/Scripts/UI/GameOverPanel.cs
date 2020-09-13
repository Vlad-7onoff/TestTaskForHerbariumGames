using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private float _delayGameOver;
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _menu;

    private Player _player;
    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _menu.onClick.AddListener(OnMenuButtonClick);
        _restart.onClick.AddListener(OnRestartClick);
        _playerSpawner.PlayerSpawned += InitPlayer;
    }

    private void OnDisable()
    {
        _menu.onClick.RemoveListener(OnMenuButtonClick);
        _restart.onClick.RemoveListener(OnRestartClick);
        _player.Died -= GameOver;
        _playerSpawner.PlayerSpawned -= InitPlayer;
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.interactable = false;
        _gameOverGroup.blocksRaycasts = false;
    }

    private void InitPlayer(Player player)
    {
        _player = player;
        _player.Died += GameOver;
    }

    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnRestartClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void GameOver()
    {
        StartCoroutine(DelayGameOver());
    }

    private IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(_delayGameOver);
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;
        _gameOverGroup.blocksRaycasts = true;
    }
}
