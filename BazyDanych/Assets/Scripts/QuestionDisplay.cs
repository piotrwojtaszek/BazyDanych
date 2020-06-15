using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QuestionDisplay : MonoBehaviour
{
    // 1 - idq
    // 2 - idp
    // 3 - time
    // 4 - idc
    // 5 - content
    // 6 - correct
    // 7 -> a   8 -> b  9 -> c  10 -> d

    public TextMeshProUGUI m_content;
    public TextMeshProUGUI m_a;
    public TextMeshProUGUI m_b;
    public TextMeshProUGUI m_c;
    public TextMeshProUGUI m_d;
    public string m_correct;
    public Image m_left;
    public Image m_right;
    public string m_idq;
    public string[] questionDetails;
    private float m_maxTime = 0f;
    IEnumerator m_corutin;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generator());
    }

    public IEnumerator Generator()
    {
        WWWForm form = new WWWForm();

        form.AddField("name", DBMenager.username);
        form.AddField("category", GameMenager.Instance.GetCurrentCategory());
        WWW www;
        www = new WWW("http://zaliczeniesqlunity.5v.pl/randomQuestion.php",form);
        yield return www;

        while (true)
        {
            if (www.text[0] == '0')
            {
                questionDetails = www.text.Split('\t');

                if (GameMenager.Instance.IsNotRepeating(questionDetails[1]) == false)
                {
                    www = new WWW("http://zaliczeniesqlunity.5v.pl/randomQuestion.php",form);
                    yield return www;
                    Debug.Log("Powtorzenie");
                }
                else
                {
                    GameMenager.Instance.AddCurrentQuestionToList(questionDetails[1]);
                    break;
                }

            }
        }

        if (www.text[0] == '0')
        {
            m_idq = questionDetails[1];

            m_maxTime = int.Parse(questionDetails[3]);

            m_content.text = questionDetails[5];
            m_correct = questionDetails[6];
            m_a.text = questionDetails[7];
            m_b.text = questionDetails[8];
            m_c.text = questionDetails[9];
            m_d.text = questionDetails[10];


        }
        else
        {
            Debug.Log("Downloading question goes wrong");
        }
        StopAllCoroutines();
        StartCoroutine(TimeCounter());

    }

    public IEnumerator TimeCounter()
    {
        float m_currTime = 0f;
        while (m_currTime <= m_maxTime)
        {

            m_currTime += Time.deltaTime;

            m_left.fillAmount = 1f - m_currTime / m_maxTime;
            m_right.fillAmount = 1f - m_currTime / m_maxTime;
            yield return null;
        }
        GetComponent<AnswerQuestion>().SetAnswer("e");

    }

}
