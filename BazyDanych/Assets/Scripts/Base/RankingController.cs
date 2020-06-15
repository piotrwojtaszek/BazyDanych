using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//0 - username
//1 - odpowiedzi
//2 - poprawne
//3 - trafnosc
public class RankingController : MonoBehaviour
{
    public GameObject m_conteiner;
    public GameObject m_fragment;
    public string m_filtr;
    private IEnumerator Start()
    {
        string[] info;
        string[] separator = { "&**&" };
        WWWForm form = new WWWForm();

        m_filtr = "players.username";
        form.AddField("filtr", m_filtr);

        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/ranking.php",form);

        yield return www;
        if (www.text[0] == '0')
        {
            info = www.text.Split(separator, int.MaxValue, StringSplitOptions.None);
            for (int i = 1; i < info.Length; i++)
            {
                string[] details = info[i].Split('\t');
                GameObject fragment = Instantiate(m_fragment, m_conteiner.transform) as GameObject;

                for (int j = 0; j < details.Length; j++)
                {
                    if (details[j] == "")
                        details[j] = "0";
                }

                fragment.GetComponent<RankingPlayerController>().SetValues(details[0], details[1], details[2], details[3]);
            }
        }
        else
        {
            Debug.Log("Coś nie tak");
        }
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
