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
    public GameObject m_playGameButton;
    public GameObject m_logInButton;
    public GameObject m_registerButton;
    public GameObject m_logOutButton;

    private void Start()
    {



        StartCoroutine(AutoLogIn());


    }
    public void GoToRegister()
    {
        SceneManager.LoadScene("RegisterMenu");
    }
    public void GoToLogIn()
    {
        SceneManager.LoadScene("LogInMenu");
    }

    public void LogOut()
    {
        DBMenager.LogOut();
        Application.Quit();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToQustionCreator()
    {
        SceneManager.LoadScene("QuestionCreator");
    }

    public IEnumerator AutoLogIn()
    {
        if (!DBMenager.LoggedIn)
        {
            if (PlayerPrefs.HasKey("username"))
            {
                Debug.Log("AutoLogin");
                WWWForm form = new WWWForm();

                form.AddField("name", PlayerPrefs.GetString("username"));
                form.AddField("password", PlayerPrefs.GetString("password"));

                WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/login.php", form);

                yield return www;
                DBMenager.username = PlayerPrefs.GetString("username");
            }
        }

        if (DBMenager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBMenager.username;

        }
        m_quizCreatorButton.SetActive(DBMenager.LoggedIn);
        m_playGameButton.SetActive(DBMenager.LoggedIn);
        m_logOutButton.SetActive(DBMenager.LoggedIn);
        m_logInButton.SetActive(!DBMenager.LoggedIn);
        m_registerButton.SetActive(!DBMenager.LoggedIn);
    }
}
