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
        SceneManager.LoadScene(1);
    }
    public void SwampAttackGame()
    {
        SceneManager.LoadScene(2);
    }
    public void FlappyBirdGame()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
