using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI playerDisplay;
    private void Start()
    {
        if(DBMenager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBMenager.username;
        }
    }
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
