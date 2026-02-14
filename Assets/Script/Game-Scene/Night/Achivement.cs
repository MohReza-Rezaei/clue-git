using TMPro;
using UnityEngine;

public class Achivement : MonoBehaviour
{
   public GameObject day , night;
   public GameObject[] insideHouse = new GameObject[6];

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

   public int CurrentHouse;

   public GameObject MyGunShot_music;

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
 void Select(int i)
{

 string item = Night_script.houses[CurrentHouse].GetItem(i);
 print("test : " + item);
 
 Earn(item);

 

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
        print("Shoot index " + index);
        if(Night_script.houses[index].GetOwner() == null || Night_script.houses[index].GetOwner().GetRole() == "Citizen")
        {
            for(int i = 0; i < 5; i++)
            {
              Select(i);  
            }
            
            if(Night_script.houses[index].GetOwner()!=null)
            {
             Night_script.houses[index].GetOwner().SwapAliveStatus();
             print("You Killed a Citizen");
             Night_script.endgame--;  
            }
          MyGunShot_music.GetComponent<AudioSource>().Play();

        }
        else
        {
          if(Night_script.houses[index].GetOwner().GetRole() == "Killer")
            {
                //win
            }
            else
            {
                Night_script.houses[index].GetOwner().SwapAliveStatus();
                print("You killed " +Night_script.houses[index].GetOwner().GetRole());
            }
        }

        playerData.Bullet-=1;
        day.SetActive(true);
        night.SetActive(false);
    }
 ////////////////////////////////////////////////////////////////


   public void Action(int index)
    {
        if (handMode)
        {
         if(Night_script.houses[index].GetOwner() == null || Night_script.houses[index].GetOwner().GetRole() == "Citizen")
            {
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
                
               CurrentHouse = index;
            }
         else
         {
            HandNotAllowed.SetActive(true);
            NotAllowed.SetActive(true);
         }
            
        }else if (gunMode)
        {
            if(playerData.Gun > 0&&playerData.Bullet > 0&& !Night_script.houses[index].IsLocked)
            {   
                CurrentHouse = index;
                Shoot(index);
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
        }else if (torchMode)
        {
            if(playerData.Torch > 0&& !Night_script.houses[index].IsLocked && Night_script.houses[index].GetOwner()!=null && Night_script.houses[index].GetOwner().GetRole() != "Citizen")
            {
                print("Ohh!! you see "+ Night_script.houses[index].GetOwner().GetRole());
                playerData.Torch--;
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
                Night_script.houses[index].IsLocked = false;
                playerData.Key--;
            }else if(playerData.Torch <= 0)
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
