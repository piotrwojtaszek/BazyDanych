using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileMenu : MonoBehaviour
{
    public Image m_image;
    public Sprite[] m_pictures;
    private void Awake()
    {
        StartCoroutine(Display());
    }

    IEnumerator Display()
    {
        WWWForm form = new WWWForm();
        form.AddField("username",DBMenager.username);
        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/getProfile.php", form);

        yield return www;


        if (www.text[0] == '0')
        {
            string[] info = www.text.Split('\t');
            Debug.Log("IKONA o nazwie: " + info[1]);
        }
        else
        {
            Debug.Log("Coś nie tak");
        }
    }
}
