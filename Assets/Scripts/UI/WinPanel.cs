using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class WinPanel : MonoBehaviour
{
    [SerializeField] private Treasure _treasure;
    [SerializeField] private Button _nextLevel;
    [SerializeField] private Button _menu;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _nextLevel.onClick.AddListener(NextLevelButtonClick);
        _menu.onClick.AddListener(BackToMenuButtonClick);
        _treasure.Collected += Win;
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveListener(NextLevelButtonClick);
        _menu.onClick.AddListener(BackToMenuButtonClick);
        _treasure.Collected -= Win;
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void BackToMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevelButtonClick()
    {
        Debug.Log("Переход на следующий уровень");
    }

    private void Win()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
}
