using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void RunnerGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void SwampAttackGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void FlappyBirdGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
