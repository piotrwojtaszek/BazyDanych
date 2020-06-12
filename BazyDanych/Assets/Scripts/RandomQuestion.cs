using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomQuestion : MonoBehaviour
{
    public IEnumerator Generator()
    {
        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/randomQuestion.php");
        yield return www;
        if (www.text[0] == '0')
        {
            string[] catList = www.text.Split('\t');
            for (int i = 0; i < catList.Length; i++)
            {
                Debug.Log(catList[i]);
            }

        }
        else
        {
            Debug.Log("Coś poszło nie tak :( ");
        }
    }
}
