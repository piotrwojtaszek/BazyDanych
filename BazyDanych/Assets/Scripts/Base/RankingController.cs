using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//0 - username
//1 - odpowiedzi
//2 - poprawne
//3 - trafnosc
public class RankingController : MonoBehaviour
{
    public GameObject m_conteiner;
    public GameObject m_fragment;
    public Image[] m_backgorundLabel;
    public string m_filtr = "username";
    [SerializeField]
    private Color32 m_baseColor;
    [SerializeField]
    private Color32 m_hightlightColor;
    private void Start() 
    {
        StartCoroutine(Display(m_filtr));

    }

    private IEnumerator Display(string _filtr)
    {
        
        string[] info;
        string[] separator = { "&**&" };
        WWWForm form = new WWWForm();
        form.AddField("filtr", _filtr);

        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/ranking.php",form);

        yield return www;


        if (www.text[0] == '0')
        {
            foreach (Transform tran in m_conteiner.transform)
            {
                Destroy(tran.gameObject);
            }

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
            Debug.Log("Ranking według: " + _filtr);
        }
        else
        {
            Debug.Log("Coś nie tak");
        }
    }

    public void ChangeFiltr(string filtr)
    {
        //m_filtr = filtr;
        StartCoroutine(Display(filtr));
    }

    public void ColorChange(Image obj)
    {
        foreach(Image image in m_backgorundLabel)
        {
            image.color = m_baseColor;
        }

        obj.color = m_hightlightColor;

    }



    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
