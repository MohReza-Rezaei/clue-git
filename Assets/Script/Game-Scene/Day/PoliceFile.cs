using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PoliceFile : MonoBehaviour
{
    public string[] message = new string[20];
    public GameObject[] off = new GameObject[20];
    public TextMeshProUGUI text;
    public PlayerData1 playerData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {

      
      for(int i = 0; i < playerData.Nights; i++)
        {
            off[i].SetActive(false);
        }

       
    }

    public void ShowText(int number)
    {
      text.text = message[number];  
    }
    
}
