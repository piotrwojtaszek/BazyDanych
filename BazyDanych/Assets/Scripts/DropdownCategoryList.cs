using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DropdownCategoryList : MonoBehaviour
{
    private IEnumerator Start()
    {

        WWW www = new WWW("http://zaliczeniesqlunity.5v.pl/categoryList.php");
        yield return www;
        if (www.text[0] == '0')
        {
            TMP_Dropdown m_dropdown = GetComponent<TMP_Dropdown>();
            string[] catList = www.text.Split('\t');
            for (int i = 1; i < catList.Length; i++)
            {
                m_dropdown.options.Add(new TMP_Dropdown.OptionData() { text = catList[i] });
            }

            m_dropdown.value = 1;
            m_dropdown.value = m_dropdown.options.FindIndex(option => option.text == "Różne");

        }
        else
        {
            Debug.Log("Coś poszło nie tak :( ");
        }


    }
}
