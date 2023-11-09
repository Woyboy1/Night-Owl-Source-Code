using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const string mainMenu = "MainMenu";
    private const string endingMenu = "Ending";
    private const string gameScene = "Game";

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void LoadEnding()
    {
        SceneManager.LoadScene(endingMenu);
    }

    public void LoadGame()
    {
        Cursor.lockState = CursorLockMode.Locked;   
        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
