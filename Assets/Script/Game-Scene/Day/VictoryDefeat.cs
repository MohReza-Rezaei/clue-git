using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDefeat : MonoBehaviour
{
    public PlayerData1 PlayerData;
    public Inventory PlayerInventory;
    public GameObject VictoryScreen,DefeatScreen;
    public TextMeshProUGUI cointext, Survivedtext;
    public Night nightscript;
    public GameObject victoryDefeatGO;
    public void ReturnHome()
    {
        SceneManager.LoadScene("Menu");
    }
    //Check for winning or loosing
    public void Check()
    {
        if (PlayerData.PersonAlive == 0 || PlayerInventory.health_slider.value < 0.12f)
        {
            //Defeat Mode
            victoryDefeatGO.SetActive(true);
            DefeatScreen.SetActive(true);
        }
        else if(!nightscript.Killer.IsAlive())
        {
            //Victory Mode
            victoryDefeatGO.SetActive(true);
            VictoryScreen.SetActive(true);
            int coin = PlayerPrefs.GetInt("Coin");
            cointext.text="+ "+PlayerData.Coin.ToString();
            //reward coin
            coin += PlayerData.Coin;
            PlayerPrefs.SetInt("Coin", coin);
            //////////////////////////////////////////////
            int gem=PlayerPrefs.GetInt("Gem");
            //reward gem
            gem+=1;
            PlayerPrefs.SetInt("Gem",gem);
            /////////////////////////////////////////////
            Survivedtext.text = PlayerData.PersonAlive.ToString();
        }
    }
    
}
