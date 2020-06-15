using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileMenu : MonoBehaviour
{
    public Image m_image;
    public GameObject m_container;
    public Sprite[] m_sprites;
    public GameObject m_fragment;
    private void Awake()
    {
        StartCoroutine(Display());
    }

    private void Start()
    {
        foreach (Sprite sprite in m_sprites)
        {
            GameObject fragment = Instantiate(m_fragment, m_container.transform);
            fragment.GetComponent<Image>().sprite = sprite;
            fragment.GetComponent<ProfileFragment>().m_image = m_image;
            fragment.GetComponent<ProfileFragment>().m_imageName = sprite.name;
        }
    }

    IEnumerator Display()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBMenager.username);
        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/getProfile.php", form);

        yield return www;


        if (www.text[0] == '0')
        {
            string[] info = www.text.Split('\t');
            Debug.Log("IKONA o nazwie: " + info[1]);
            Sprite sprite = Resources.Load<Sprite>("Icons/" + info[1]);
            m_image.sprite = sprite;
            m_image.preserveAspect = true;
        }
        else
        {
            Debug.Log("Coś nie tak");
        }
    }

    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
