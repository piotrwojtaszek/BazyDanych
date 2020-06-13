using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI m_scoreText;
    private int m_score;

    // Start is called before the first frame update
    void Start()
    {
        m_score = GameMenager.Instance.m_goodAnsewers;

        GameMenager.Instance.ResetAnswered();

        m_scoreText.text = m_score.ToString();
    }

}
