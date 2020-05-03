using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void GoToRegister()
    {
        SceneManager.LoadScene("RegisterMenu");
    }
    public void GoToLogIn()
    {
        SceneManager.LoadScene("LogInMenu");
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
