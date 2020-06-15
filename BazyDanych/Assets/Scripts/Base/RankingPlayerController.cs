using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RankingPlayerController : MonoBehaviour
{
    private string m_username;
    private string m_odpowiedzi;
    private string m_poprawne;
    private string m_trafnosc;

    [SerializeField]
    private TextMeshProUGUI m_usernameText;
    [SerializeField]
    private TextMeshProUGUI m_odpowiedziText;
    [SerializeField]
    private TextMeshProUGUI m_poprawneText;
    [SerializeField]
    private TextMeshProUGUI m_trafnoscText;

    [SerializeField]
    private Color32 m_baseColor;
    [SerializeField]
    private Color32 m_userColor;
    private void Start()
    {
        m_usernameText.text = m_username;
        m_odpowiedziText.text = m_odpowiedzi;
        m_poprawneText.text = m_poprawne;
        m_trafnoscText.text = m_trafnosc;
    }

    public void SetValues(string username,string odpowiedzi, string poprawne, string trafnosc)
    {
        if(DBMenager.username ==username)
        {
            GetComponent<Image>().color = m_userColor;
        }
        else
        {
            GetComponent<Image>().color = m_baseColor;
        }
        m_username = username;
        m_odpowiedzi = odpowiedzi;
        m_poprawne = poprawne;
        if (trafnosc.Length > 5)
            trafnosc = trafnosc.Substring(2, 2);
        m_trafnosc = trafnosc + " %";
    }

}
