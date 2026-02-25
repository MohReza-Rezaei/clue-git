using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI cointext, gemtext;

    void OnEnable()
    {
        cointext.text=PlayerPrefs.GetInt("Coin").ToString();
        gemtext.text=PlayerPrefs.GetInt("Gem").ToString();
    }
}
