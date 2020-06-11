using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI playerDisplay;
    public GameObject m_quizCreatorButton;
    private void Start()
    {
        if (DBMenager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBMenager.username;

        }
        m_quizCreatorButton.SetActive(DBMenager.LoggedIn);
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

    public void GoToQustionCreator()
    {
        SceneManager.LoadScene("QuestionCreator");
    }
}
