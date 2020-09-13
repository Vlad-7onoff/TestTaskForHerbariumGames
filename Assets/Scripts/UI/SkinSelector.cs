using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class SkinSelector : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(ClosePanel);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(ClosePanel);
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ClosePanel();
    }

    public void OpenPanel()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void ClosePanel()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void SetSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("Skin", skinIndex);
    }
}
