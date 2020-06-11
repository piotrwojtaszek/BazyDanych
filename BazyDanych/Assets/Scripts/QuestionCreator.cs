using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestionCreator : MonoBehaviour
{
    public TMP_InputField categoryField;
    public TMP_InputField contentField;
    public TMP_InputField timeField;
    public TMP_InputField correctField;
    public TMP_InputField aField;
    public TMP_InputField bField;
    public TMP_InputField cField;
    public TMP_InputField dField;

    public Button submitButton;
    public void CallCreator()
    {
        StartCoroutine(Question());
    }

    private IEnumerator Question()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBMenager.username);
        form.AddField("category", categoryField.text);
        form.AddField("content", contentField.text);
        form.AddField("time", timeField.text);
        form.AddField("correct", correctField.text);
        form.AddField("aa", aField.text);
        form.AddField("ab", bField.text);
        form.AddField("ac", cField.text);
        form.AddField("ad", dField.text);

        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/question.php", form);

        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created successfully!");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (contentField.text.Length >= 2);
    }
}
