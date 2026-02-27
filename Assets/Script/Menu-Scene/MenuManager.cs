using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI cointext, gemtext;
    public TMP_Dropdown language_dropdown;

    void OnEnable()
    {
        cointext.text=PlayerPrefs.GetInt("Coin").ToString();
        gemtext.text=PlayerPrefs.GetInt("Gem").ToString();
    }

    public void Language_change()
    {
        English[] english_texts = FindObjectsOfType<English>(true);
        Persian[] perisan_texts = FindObjectsOfType<Persian>(true);
        if(language_dropdown.value == 0)
        {
            // switch to english
           foreach (var t in english_texts)
            {
            t.gameObject.SetActive(true);
            }

            foreach (var t in perisan_texts)
            {
            t.gameObject.SetActive(false);
            } 

            
        }else if(language_dropdown.value == 1)
        {
            // switch to farsi

            foreach (var t in perisan_texts)
            {
            t.gameObject.SetActive(true);
            }
             foreach (var t in english_texts)
            {
            t.gameObject.SetActive(false);
            } 

        }   
    }
}
