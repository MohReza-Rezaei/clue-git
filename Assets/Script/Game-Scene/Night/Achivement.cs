using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using System.Collections;

public class Achivement : MonoBehaviour
{
    public Inventory Inventory_script;
   public GameObject day , night;
   public GameObject[] insideHouse = new GameObject[6];
   public GameObject[] CheckHouse = new GameObject[36];
   public Night Night_script;
   public PlayerData1 playerData;
   public GameObject NotAllowed;
   public GameObject HandNotAllowed;
   public GameObject GunNotAllowed;
   public GameObject BulletNotAllowed;
   public GameObject LockedNotAllowed , citizenLockedNotAllowed;
   public GameObject TorchNotAllowed;
   public GameObject keyNotAllowed;
   public GameObject unlockNotAllowed;
   public TextMeshProUGUI Night_field,coin_inventory,burger_inventory,pizza_inventory,hotdog_inventory,medicine_inventory,medkit_inventory,gun_inventory,bullet_inventory,key_inventory,torch_inventory,clue_inventory;
    public TextMeshProUGUI[] founditemstext=new TextMeshProUGUI[5];
   public int CurrentHouse;
   public GameObject KillerinHouse;
   public GameObject itemsfoundbyshot; 
   public GameObject MyGunShot_music;
   public GameObject OpenLock_music;
   public Sprite unlocked;
   public GameObject TorchSeek;
   public TextMeshProUGUI torchseektext;
   public GameObject HouseTags,Luxury, Old, Damaged, Small,Furnished;
   public PickItem PickItem_script;
   public GameObject PoliceInCity;
   public int MyShootIndex;
    void OnEnable()
    {
        playerData.Nights+=1;
        ItemsUpdate();
    }

     void ItemsUpdate()
    {
        // players item
    Night_field.text = "#" + playerData.Nights.ToString();

        // inventory

    coin_inventory.text = "#" + playerData.Coin.ToString();
    burger_inventory.text = "#" + playerData.Hamburger.ToString();
    pizza_inventory.text = "#" + playerData.Pizza.ToString();
    hotdog_inventory.text = "#" + playerData.Hotdog.ToString();
    medicine_inventory.text = "#" + playerData.Medicine.ToString();
    medkit_inventory.text = "#" + playerData.Medkit.ToString();
    gun_inventory.text = "#" + playerData.Gun.ToString();
    bullet_inventory.text = "#" + playerData.Bullet.ToString();
    key_inventory.text = "#" + playerData.Key.ToString();
    torch_inventory.text = "#" + playerData.Torch.ToString();
    clue_inventory.text = "#" + playerData.Clue.ToString();
    }
    /// <summary>
    /// //////////////////////////////////////
    /// </summary>//
    public bool handMode = true , gunMode = false , keyMode = false , torchMode = false;

 public void HandMode()
    {
     handMode = true;
     gunMode = false;
     torchMode = false;
     keyMode = false;
    }

    public void GunMode()
    {
     handMode = false;
     gunMode = true;
     torchMode = false;
     keyMode = false;
    }

    public void TorchMode()
    {
     handMode = false;
     gunMode = false;
     torchMode = true;
     keyMode = false;
    }

    public void KeyMode()
    {
     handMode = false;
     gunMode = false;
     torchMode = false;
     keyMode = true;
    }
    ///////////////////////////////////////////////////////////////
    ///
   
 string Select(int i)
{

 string item = Night_script.houses[CurrentHouse].GetItem(i);
 //print("test : " + item);
 
 Earn(item);
 return item;


}
    IEnumerator TorchShowInfo()
    {
        // Show torch result
        TorchSeek.SetActive(true);

        // Wait 3 seconds
        yield return new WaitForSeconds(3f);

        // Hide torch result
        TorchSeek.SetActive(false);
        StartCoroutine(PickItem_script.TorchPause());
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
    /// 
    void Shoot(int index)
    {
        if (index == Night_script.KillerTargetHome)
        {
            //win
            Night_script.Killer.SwapAliveStatus();
        }
        print("Shoot index " + index);
        MyShootIndex=index;
        if(Night_script.houses[index].GetOwner() == null || Night_script.houses[index].GetOwner().GetRole() == "Citizen")
        {
            for(int i = 0; i < 5; i++)
            {
                founditemstext[i].text = Select(i);
            }
            itemsfoundbyshot.SetActive(true);
            if(Night_script.houses[index].GetOwner()!=null)
            { 
             MyGunShot_music.GetComponent<AudioSource>().Play();
             Night_script.houses[index].GetOwner().SwapAliveStatus();
             print("You Killed a Citizen");
             Night_script.endgame--;
             playerData.PersonAlive--;
            }
          

        }
        else
        {
            MyGunShot_music.GetComponent<AudioSource>().Play();
          if(Night_script.houses[index].GetOwner().GetRole() == "Killer")
            {
                //win
                Night_script.Killer.SwapAliveStatus();
            }
            else
            {
                Night_script.houses[index].GetOwner().SwapAliveStatus();
                print("You killed " +Night_script.houses[index].GetOwner().GetRole());
                playerData.PersonAlive--;
                Night_script.endgame--;
            }
            day.SetActive(true);
            night.SetActive(false);
        }

        playerData.Bullet-=1;
    }
 ////////////////////////////////////////////////////////////////


   public void Action(int index)
    {
        if (handMode)
        {
         if((Night_script.houses[index].GetOwner() == null || Night_script.houses[index].GetOwner().GetRole() == "Citizen") && !Night_script.houses[index].visited)
            {
                if (index == Night_script.KillerTargetHome)
                {
                    Inventory_script.health_slider.value -= 0.5f;
                    KillerinHouse.SetActive(true);
                }
                if(index < 6)
                {
                insideHouse[0].SetActive(true); 
                }else if(index >= 6 && index < 12)
                {
                insideHouse[1].SetActive(true);
                }else if(index >= 12 && index < 18)
                {
                insideHouse[2].SetActive(true);
                }else if(index >= 18 && index < 24)
                {
                insideHouse[3].SetActive(true);
                }else if(index >= 24 && index < 30)
                {
                insideHouse[4].SetActive(true);
                }else if(index >= 30)
                {
                insideHouse[5].SetActive(true);
                }
                if (((index / 6) == (Night_script.PoliceHomeIndex / 6)) && Night_script.police.IsAlive())
                {
                    Inventory_script.health_slider.value -= 0.5f;
                    PoliceInCity.SetActive(true);
                }
                CheckHouse[index].SetActive(true);
                Night_script.houses[index].visited=true;
               CurrentHouse = index;
            }
         else
         {
             string[] Alltags = new string[3];
             if (Night_script.houses[index].IsLocked == true)
             {
                 HandNotAllowed.SetActive(true);
                 NotAllowed.SetActive(true);
             }
             else
             {
                 HouseTags.SetActive(true);
                 Alltags = Night_script.houses[index].GetAlltags();
                 for (int i = 0; i < 3; i++)
                 {
                     if (Alltags[i] == "luxury")
                     {
                         Luxury.SetActive(true);
                     }
                     else if (Alltags[i] == "old")
                     {
                         Old.SetActive(true);
                     }
                     else if (Alltags[i] == "damaged")
                     {
                         Damaged.SetActive(true);
                     }
                     else if (Alltags[i] == "small")
                     {
                         Small.SetActive(true);
                     }
                     else if (Alltags[i] == "furnished")
                     {
                         Furnished.SetActive(true);
                     }
                 }
             }
         }
            
        }else if (gunMode)
        {
            if(playerData.Gun > 0&&playerData.Bullet > 0&& !Night_script.houses[index].IsLocked && !Night_script.houses[index].visited)
            {   
                CurrentHouse = index;
                Shoot(index);
                CheckHouse[index].SetActive(true);
                Night_script.houses[index].visited = true;
            }else if(playerData.Gun <= 0)
            {
            NotAllowed.SetActive(true);
            GunNotAllowed.SetActive(true); 
            }else if(playerData.Bullet <= 0)
            {
             NotAllowed.SetActive(true);
            BulletNotAllowed.SetActive(true);   
            }else if (Night_script.houses[index].IsLocked)
            {
            NotAllowed.SetActive(true);
            LockedNotAllowed.SetActive(true); 
            }
            else if (Night_script.houses[index].visited)
            {
                //already  visited UI!
            }
        }else if (torchMode)
        {
            if(playerData.Torch > 0&& !Night_script.houses[index].IsLocked && Night_script.houses[index].GetOwner()!=null && Night_script.houses[index].GetOwner().GetRole() != "Citizen")
            {
                torchseektext.text = "Oh... you see the " + Night_script.houses[index].GetOwner().GetRole() + "! ";
                playerData.Torch--;
                StartCoroutine(TorchShowInfo());
            }else if(playerData.Torch <= 0)
            {
            NotAllowed.SetActive(true);
            TorchNotAllowed.SetActive(true); 
            }else if (Night_script.houses[index].IsLocked)
            {
            NotAllowed.SetActive(true);
            LockedNotAllowed.SetActive(true);
            }
            else
            {
            NotAllowed.SetActive(true);
            citizenLockedNotAllowed.SetActive(true);
            }
        }else if (keyMode)
        {
            if(playerData.Key > 0&& Night_script.houses[index].IsLocked)
            {
                OpenLock_music.GetComponent<AudioSource>().Play();
                Night_script.houses[index].IsLocked = false;
                playerData.Key--;
                Night_script.lockIcon[index].GetComponent<Image>().sprite = unlocked;
                Night_script.lockIcon[index].GetComponent<Image>().SetNativeSize();
            }else if(playerData.Key <= 0)
            {
            NotAllowed.SetActive(true);
            keyNotAllowed.SetActive(true); 
            }else if (!Night_script.houses[index].IsLocked)
            {
            NotAllowed.SetActive(true);
            unlockNotAllowed.SetActive(true); 
            }
        }
    }

///////////////////////////////////////////////////////////////

}
