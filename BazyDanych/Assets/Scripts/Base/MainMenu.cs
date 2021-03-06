﻿using System.Collections;
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
    public GameObject m_rankingButton;
    public GameObject m_profileButton;
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
        StartCoroutine(AutoLogIn());
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("CategoryPicker");
    }

    public void GoToQustionCreator()
    {
        SceneManager.LoadScene("QuestionCreator");
    }

    public void GoToRank()
    {
        SceneManager.LoadScene("Ranking");
    }

    public void GoToProfile()
    {
        SceneManager.LoadScene("ProfileMenu");
    }

    public IEnumerator AutoLogIn()
    {
        if (!DBMenager.LoggedIn)
        {
            if (PlayerPrefs.HasKey("username"))
            {
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
        else
        {
            playerDisplay.text = "No user logged in";
        }

        m_quizCreatorButton.SetActive(DBMenager.LoggedIn);
        m_playGameButton.SetActive(DBMenager.LoggedIn);
        m_rankingButton.SetActive(DBMenager.LoggedIn);
        m_logOutButton.SetActive(DBMenager.LoggedIn);
        m_profileButton.SetActive(DBMenager.LoggedIn);
        m_logInButton.SetActive(!DBMenager.LoggedIn);
        m_registerButton.SetActive(!DBMenager.LoggedIn);
    }
}
