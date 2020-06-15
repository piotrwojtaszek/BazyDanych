using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerQuestion : MonoBehaviour
{
    public string m_answer = "e";

    public void SetAnswer(string option)
    {
        m_answer = option;
        StartCoroutine(Answer());

    }

    public IEnumerator Answer()
    {
        WWWForm form = new WWWForm();

        form.AddField("username", DBMenager.username);
        form.AddField("question", GetComponent<QuestionDisplay>().m_idq);

        if (m_answer == GetComponent<QuestionDisplay>().m_correct)
        {
            GameMenager.Instance.GoodAnswer();
            form.AddField("playerAnswer", 1);
        }
        else
        {
            form.AddField("playerAnswer", 0);
        }
        GameMenager.Instance.AddAnswered();
        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/answerQuestion.php", form);
        yield return www;

        if (www.text == "0")
        {


        }
        else
        {
            Debug.Log("Inserting history failed# "+www.text);
        }



        m_answer = "e";
        StartCoroutine(GetComponent<QuestionDisplay>().Generator());
    }
}
