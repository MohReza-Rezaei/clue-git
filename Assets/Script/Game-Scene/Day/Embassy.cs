using TMPro;
using UnityEngine;

public class Embassy : MonoBehaviour
{
    public GameObject Buttons , Firsttext , secondtext;
    public PlayerData1 playerData;
    bool buy = false;

    void OnEnable()
    {
        if (!buy && playerData.Days >= 3)
        {
            Buttons.SetActive(true);
            Firsttext.SetActive(false);
        }
    }


    public void GetGun(){
    playerData.Gun+=1;
    Buttons.SetActive(false);
    secondtext.SetActive(true);
    buy = true;
    }

    public void GetBullet(){
    playerData.Bullet+=3;
    Buttons.SetActive(false);
    secondtext.SetActive(true);
    buy = true;
    }

    public void GetCoin(){
    playerData.Coin+=10;
    Buttons.SetActive(false);
    secondtext.SetActive(true);
    buy = true;
    }

    public void GetTorch(){
    playerData.Torch+=2;
    Buttons.SetActive(false);
    secondtext.SetActive(true);
    buy = true;
    }

    public void GetKey(){
    playerData.Key+=2;
    Buttons.SetActive(false);
    secondtext.SetActive(true);
    buy = true;
    }

    public void GetMedkit(){
    playerData.Medkit+=2;
    Buttons.SetActive(false);
    secondtext.SetActive(true);
    buy = true;
    }

    public void GetFood(){
    playerData.Hamburger+=2;
    Buttons.SetActive(false);
    secondtext.SetActive(true);
    buy = true;
    }

    public void GetClue(){
    playerData.Clue+=2;
    Buttons.SetActive(false);
    secondtext.SetActive(true);
    buy = true;
    }
}
