using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof (CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Player _player;
   
    //private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restart.onClick.AddListener(OnRestart);
        _mainMenu.onClick.AddListener(OnMainMenu);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restart.onClick.RemoveListener(OnRestart);
        _mainMenu.onClick.RemoveListener(OnMainMenu);
    }

    //private void Start()
    //{
    //    _gameOverGroup = GetComponent<CanvasGroup>();
    //    //_gameOverGroup.alpha = 0;
    //}
    private void OnDied()
    {
        //_gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestart()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
    private void OnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
