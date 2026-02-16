using System.Collections;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    int Choose;
    public GameObject night , day , house , GroupSelect , killmusic , night_scene;
    public PlayerData1 playerData;
    public Night Night_script;
    public Achivement achivement_script;
    public GameObject[] items = new GameObject[5];

    public GameObject info , coinPrize , gunPrize , bulletPrize , pizzaPrize , hotdogPrize , hamburgerPrize , medicinePrize , medkitPrize , keyPrize , torchPrize , cluePrize , nothingPrize;

    void OnEnable()
    {
        Choose = 3;

        for(int i = 0;i < items.Length; i++)
        {
         items[i].SetActive(true);   
        }

        StartCoroutine(Pause());
        
    }

    IEnumerator Pause()
    {
        yield return new WaitUntil(()=> Choose <= 0);
        night_scene.SetActive(true);
        killmusic.GetComponent<AudioSource>().Play();
        
        yield return new WaitForSeconds(7);
        print("here");
        night.SetActive(false);
        day.SetActive(true);
        night_scene.SetActive(false);
        house.SetActive(false);
    }


public void Select(int i)
{
 print("Current house: " + achivement_script.CurrentHouse);
 string item = Night_script.houses[achivement_script.CurrentHouse].GetItem(i);

 GroupSelect.SetActive(false);
 
 Earn(item);

 StartCoroutine(Found(item));

}

void Earn(string item)
{
  if(item == "coin")
 {
  playerData.Coin += 2;
  print("Coin Found!");          
 }else if(item == "gun")
 {
  playerData.Gun += 1;
  print("Gun Found!");        
 }else if(item == "bullet")
 {
  playerData.Bullet+=1;
  print("Bullet Found!");     
 }else if(item == "food")
    {
      int randomFood = UnityEngine.Random.Range(1,4);
      if(randomFood == 1)
            {
                playerData.Pizza +=1;
                print("Pizza Found!");
            }else if(randomFood == 2)
            {
                playerData.Hotdog += 1;
                print("Hotdog Found!");
            }else if(randomFood == 3)
            {
                playerData.Hamburger += 1;
                print("Hamburger Found!");
            }
    }else if(item == "medicine")
        {
            int randomMedicine = UnityEngine.Random.Range(1,3);
            if(randomMedicine == 1)
            {
                playerData.Medicine += 1;
                print("Medicine Found!");
            }else if(randomMedicine == 2)
            {
                playerData.Medkit +=1;
                print("MedKit Found!");
            }
        }else if(item == "torch")
        {
            playerData.Torch+=1;
            print("Torch Found!");
        }else if(item == "key")
        {
            playerData.Key += 1;
            print("Key Found!");
        }else if (item == "clue")
        {
            playerData.Clue += 1;
            print("Clue Found!");
        }
        else
        {
            print("Empty !");
        }

 

}



IEnumerator Found(string item)
    {
     info.SetActive(true);
     if(item == "coin")
     coinPrize.SetActive(true);
     else if(item == "gun")
     gunPrize.SetActive(true);
     else if(item == "bullet")
     bulletPrize.SetActive(true);
     else if(item == "pizza")
     pizzaPrize.SetActive(true);
     else if(item == "hotdog")
     hotdogPrize.SetActive(true);
     else if(item == "hamburger")
     hamburgerPrize.SetActive(true);
     else if(item == "medicine")
     medicinePrize.SetActive(true);
     else if(item == "medkit")
     medkitPrize.SetActive(true);
     else if(item == "key")
     keyPrize.SetActive(true);
     else if(item == "torch")
     torchPrize.SetActive(true);
     else if(item == "clue")
     cluePrize.SetActive(true);
     else if(item == "empty")
     nothingPrize.SetActive(true);

     yield return new WaitForSeconds(1);

     coinPrize.SetActive(false);
     gunPrize.SetActive(false);
     bulletPrize.SetActive(false);
     pizzaPrize.SetActive(false);
     hotdogPrize.SetActive(false);
     hamburgerPrize.SetActive(false);
     medicinePrize.SetActive(false);
     medkitPrize.SetActive(false);
     keyPrize.SetActive(false);
     torchPrize.SetActive(false);
     cluePrize.SetActive(false);
     nothingPrize.SetActive(false);
     info.SetActive(false);

     Choose--;
     GroupSelect.SetActive(true);

    }


}
