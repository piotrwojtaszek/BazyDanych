using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingController : MonoBehaviour
{
    public GameObject m_conteiner;

    private IEnumerator Start()
    {
        string[] info;
        string[] separator = { "\t" };
        //WWWForm form = new WWWForm();

        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/ranking.php");

        yield return www;
        if (www.text[0] == '0')
        {
            info = www.text.Split(separator,int.MaxValue, StringSplitOptions.None);
            foreach(string s in info)
            {
                Debug.Log(s);
            }
        }
        else
        {
            Debug.Log("Coś nie tak");
        }
    }
}
