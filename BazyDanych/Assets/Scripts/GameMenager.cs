using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public int m_currentAnswered = 0;
    public int m_goodAnsewers = 0;

    public static GameMenager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddAnswered()
    {
        m_currentAnswered++;
        if (m_currentAnswered==5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScore");
        }
    }
    public void GoodAnswer()
    {
        m_goodAnsewers++;
    }

    public void ResetAnswered()
    {
        m_currentAnswered = 0;
    }
}
