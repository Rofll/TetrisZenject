using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Zenject;

public class UIController : MonoBehaviour {

    [SerializeField] private GameObject _gamePanel;

    [Inject]
    private GameController _gameController;

#if UNITY_EDITOR
    private void OnValidate()
    {
        _gamePanel = transform.Find("GamePanel").gameObject;
    }
#endif

    public void ShowGamePanel()
    {
        _gamePanel.SetActive(true);
    }

    public void HideGamePanel()
    {
        _gamePanel.SetActive(false);
    }

    public void OnRestartButtonClicked()
    {

    }
}