using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProfileFragment : MonoBehaviour, IPointerClickHandler
{

    public Image m_image;
    public string m_imageName;

    public void OnPointerClick(PointerEventData eventData)
    {
        m_image.sprite = Resources.Load<Sprite>("Icons/" + m_imageName);
        StartCoroutine(Display(m_imageName));
    }

    IEnumerator Display(string imageName)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBMenager.username);
        form.AddField("icon", imageName);
        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/updateProfile.php", form);

        yield return www;

        if (www.text[0] == '0')
        {
            Debug.Log("Udalo sie zrobic update");
        }
        else
        {
            Debug.Log("Coś nie tak" + www.text);
        }
    }
}
