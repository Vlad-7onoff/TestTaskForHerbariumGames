using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SkinSelector _skinSelector;
    [SerializeField] private Button _start;
    [SerializeField] private Button _skinSelect;
    [SerializeField] private Button _exit;

    private void OnEnable()
    {
        _start.onClick.AddListener(OnStartButtonClick);
        _skinSelect.onClick.AddListener(OnSkinSelectorButtonClick);
        _exit.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _start.onClick.RemoveListener(OnStartButtonClick);
        _skinSelect.onClick.RemoveListener(OnSkinSelectorButtonClick);
        _exit.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Awake()
    {
        if (PlayerPrefs.GetInt("FirstStart") == 0)
        {
            PlayerPrefs.SetInt("FirstStart", 1);
            PlayerPrefs.SetInt("Skin", 0);
        }
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    private void OnSkinSelectorButtonClick()
    {
        _skinSelector.OpenPanel();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
