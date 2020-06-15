using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public int m_currentAnswered = 0;
    public int m_goodAnsewers = 0;
    public string m_currentCategory = "";
    private List<string> m_questionsInCurrentQuiz = new List<string>();

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
        if (m_currentAnswered == 5)
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
        m_goodAnsewers = 0;
        m_currentAnswered = 0;
    }

    public void AddCurrentQuestionToList(string idq)
    {
        m_questionsInCurrentQuiz.Add(idq);
    }

    public void DeleteKeyFromQuestionList(string idq)
    {
        m_questionsInCurrentQuiz.Remove(idq);
    }

    public bool IsNotRepeating(string idq)
    {
        if(m_questionsInCurrentQuiz.Count==0)
        {
            return true;
        }
        if (m_questionsInCurrentQuiz.Contains(idq))
            return false;

        return true;
    }

    public void ClearQuizList()
    {
        m_questionsInCurrentQuiz.Clear();
    }

    public void DeleteKey(int id)
    {
        m_questionsInCurrentQuiz.RemoveAt(id);
    }

    public void SetCurrentCategory(string s)
    {
        m_currentCategory = s;
    }

    public string GetCurrentCategory()
    {
        return m_currentCategory;
    }


}
