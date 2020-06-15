using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CategoryPicker : MonoBehaviour
{
    public TMP_Dropdown m_dropdown;

    public void StratGame()
    {
        GameMenager.Instance.SetCurrentCategory(m_dropdown.options[m_dropdown.value].text);
        Debug.Log("TAKA KATGORIA ZOSRALA WYBRANA: "+GameMenager.Instance.GetCurrentCategory());
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
