using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{   
    //////////////
    private int AzayeOmoomi=0;
    //////////////
    public GameObject ConfirmBuyMusic,DeclineBuyMusic;
    public GameObject PoliceActiveDoor,PoliceOffDoor;
    public GameObject DinerActiveDoor,DinerOffDoor;
    public GameObject AmbassadorActiveDoor,AmbassadorOffDoor;
    public GameObject CommissionerActiveDoor,CommissionerOffDoor;
    public GameObject GunSalerActiveDorr,GunSalerOffDoor;
    public GameObject keySmithActiveDoor,KeySmithOffDoor;
    public GameObject TorchSmithActiveDoor,TorchSmithOffDoor;
    public GameObject ClinicActiveDoor,ClinicOffDoor;
    //////////////////////////
    int hungerDay_count = 0;
    ////////////////////////////
    public Night night_script;
    public PlayerData1 playerData;
    public Slider food_slider , health_slider;
    public VictoryDefeat victoryscript;
    ////////////////////////////
    public TextMeshProUGUI burger_text , hotdog_text , pizza_text , medicine_text , medkit_text;
    public TextMeshProUGUI Day_field , coin_field,personAlive_field ;
    public TextMeshProUGUI coin_inventory , burger_inventory , pizza_inventory , hotdog_inventory , medicine_inventory , medkit_inventory , gun_inventory , bullet_inventory , key_inventory , torch_inventory , clue_inventory ;
    ///////////////////////////////////

    void OnEnable() {
    playerData.Days+=1;
    ItemsUpdate();
    Hunger_Update();
    Store_Update();
    CheckAmbassador();
    victoryscript.Check();
    }

/// ////////////////////////////////////////////////////////////////
   public void EnterStore()
    {
        if (night_script.police.IsAlive())
        {
            PoliceActiveDoor.SetActive(false);
        }
        else
        {
            PoliceOffDoor.SetActive(false);
        }

        if (night_script.Chef.IsAlive())
        {
            DinerActiveDoor.SetActive(false);
        }
        else
        {
            DinerOffDoor.SetActive(false);
        }

        if (night_script.Ambassador.IsAlive())
        {
            AmbassadorActiveDoor.SetActive(false);
        }
        else
        {
            AmbassadorOffDoor.SetActive(false);
        }

        if (night_script.Commissioner.IsAlive())
        {
            CommissionerActiveDoor.SetActive(false);
        }
        else
        {
            CommissionerOffDoor.SetActive(false);
        }

        if (night_script.GunSmith.IsAlive())
        {
            GunSalerActiveDorr.SetActive(false);
        }
        else
        {
            GunSalerOffDoor.SetActive(false);
        }

        if (night_script.KeySmith.IsAlive())
        {
            keySmithActiveDoor.SetActive(false);
        }
        else
        {
            KeySmithOffDoor.SetActive(false);
        }

        if (night_script.TorchSmith.IsAlive())
        {
            TorchSmithActiveDoor.SetActive(false);
        }
        else
        {
            TorchSmithOffDoor.SetActive(false);
        }

        if (night_script.Doctor.IsAlive())
        {
            ClinicActiveDoor.SetActive(false);
        }
        else
        {
            ClinicOffDoor.SetActive(false);
        }
    }

   public void ExitStore()
    {
        if (night_script.police.IsAlive())
        {
            PoliceActiveDoor.SetActive(true);
        }
        else
        {
            PoliceOffDoor.SetActive(true);
        }

        if (night_script.Chef.IsAlive())
        {
            DinerActiveDoor.SetActive(true);
        }
        else
        {
            DinerOffDoor.SetActive(true);
        }

        if (night_script.Ambassador.IsAlive())
        {
            AmbassadorActiveDoor.SetActive(true);
        }
        else
        {
            AmbassadorOffDoor.SetActive(true);
        }

        if (night_script.Commissioner.IsAlive())
        {
            CommissionerActiveDoor.SetActive(true);
        }
        else
        {
            CommissionerOffDoor.SetActive(true);
        }

        if (night_script.GunSmith.IsAlive())
        {
            GunSalerActiveDorr.SetActive(true);
        }
        else
        {
            GunSalerOffDoor.SetActive(true);
        }

        if (night_script.KeySmith.IsAlive())
        {
            keySmithActiveDoor.SetActive(true);
        }
        else
        {
            KeySmithOffDoor.SetActive(true);
        }

        if (night_script.TorchSmith.IsAlive())
        {
            TorchSmithActiveDoor.SetActive(true);
        }
        else
        {
            TorchSmithOffDoor.SetActive(true);
        }

        if (night_script.Doctor.IsAlive())
        {
            ClinicActiveDoor.SetActive(true);
        }
        else
        {
            ClinicOffDoor.SetActive(true);
        }
    }

    /// <summary>
    void CheckAmbassador()
    {
        if (AzayeOmoomi == 0 && !night_script.Ambassador.IsAlive())
        {
            PoliceOffDoor.SetActive(true);
            PoliceActiveDoor.SetActive(false);
            DinerOffDoor.SetActive(true);
            DinerActiveDoor.SetActive(false);
            CommissionerOffDoor.SetActive(true);
            CommissionerActiveDoor.SetActive(false);
            AmbassadorOffDoor.SetActive(true);
            AmbassadorActiveDoor.SetActive(false);
            GunSalerOffDoor.SetActive(true);
            GunSalerActiveDorr.SetActive(false);
            KeySmithOffDoor.SetActive(true);
            keySmithActiveDoor.SetActive(false);
            TorchSmithOffDoor.SetActive(true);
            TorchSmithActiveDoor.SetActive(false);
            ClinicOffDoor.SetActive(true);
            ClinicActiveDoor.SetActive(false);
            AzayeOmoomi++;
        }
    }
   
   
   
   /// </summary>
/////////////////////////////////////////////////////////////////////

    void ItemsUpdate()
    {
        // players item
    Day_field.text = "#" + playerData.Days.ToString();
    coin_field.text =  playerData.Coin.ToString();
    personAlive_field.text = playerData.PersonAlive.ToString();

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
//////////////////////////////////////////////////////////////////////////

    void Hunger_Update()
    {
    hungerDay_count+=1;

    if(hungerDay_count%2 == 1 && hungerDay_count !=1)
        {
            food_slider.value -= 0.33f;
        }

        if (food_slider.value < 0.13f)
        {
            health_slider.value -= 0.5f;
        }

    }
///////////////////////////////////////////////////////////////////////////

  void Store_Update()
    {
        if (!night_script.police.IsAlive())
        {
        PoliceActiveDoor.SetActive(false);
        PoliceOffDoor.SetActive(true);    
        }
        else
        {
            PoliceActiveDoor.SetActive(true);
            PoliceOffDoor.SetActive(false);  
        }
        if (!night_script.Chef.IsAlive())
        {
        DinerActiveDoor.SetActive(false);
        DinerOffDoor.SetActive(true);
        }
        else
        {
            DinerActiveDoor.SetActive(true);
            DinerOffDoor.SetActive(false);
        }
        if (!night_script.Ambassador.IsAlive())
        {
        AmbassadorActiveDoor.SetActive(false);
        AmbassadorOffDoor.SetActive(true);
        }
        else
        {
            AmbassadorActiveDoor.SetActive(true);
            AmbassadorOffDoor.SetActive(false);
        }
         if (!night_script.Commissioner.IsAlive())
        {
        CommissionerActiveDoor.SetActive(false);
        CommissionerOffDoor.SetActive(true);
        }
         else
         {
             CommissionerActiveDoor.SetActive(true);
             CommissionerOffDoor.SetActive(false);
         }
         if (!night_script.GunSmith.IsAlive())
        {
        GunSalerActiveDorr.SetActive(false);
        GunSalerOffDoor.SetActive(true);
        }
         else
         {
             GunSalerActiveDorr.SetActive(true);
             GunSalerOffDoor.SetActive(false);
         }
         if (!night_script.KeySmith.IsAlive())
        {
        keySmithActiveDoor.SetActive(false);
        KeySmithOffDoor.SetActive(true);
        }
         else
         {
             keySmithActiveDoor.SetActive(true);
             KeySmithOffDoor.SetActive(false);
         }
         if (!night_script.TorchSmith.IsAlive())
        {
        TorchSmithActiveDoor.SetActive(false);
        TorchSmithOffDoor.SetActive(true);
        }
         else
         {
             TorchSmithActiveDoor.SetActive(true);
             TorchSmithOffDoor.SetActive(false);
         }
         if (!night_script.Doctor.IsAlive())
        {
        ClinicActiveDoor.SetActive(false);
        ClinicOffDoor.SetActive(true);
        }
         else
         {
             ClinicActiveDoor.SetActive(true);
             ClinicOffDoor.SetActive(false);
         }
    }


/// //////////////////////////////////  inventorty - consume /////////////

   public void Consume_burger(){
        if(playerData.Hamburger > 0 && food_slider.value < 0.67){
         playerData.Hamburger -= 1;
         burger_text.text = "#" +  playerData.Hamburger.ToString();
         food_slider.value += 0.66f;
         //
                // playerprefs update;
         //
        }
   }

   public void Consume_hotdog(){
        if( playerData.Hotdog > 1 && food_slider.value < 0.67){
         playerData.Hotdog -= 2;
         hotdog_text.text = "#" + playerData.Hotdog.ToString();
         food_slider.value += 0.66f;
         //
                // playerprefs update;
         //
        }
    
   }
   public void Consume_pizza(){
        if(playerData.Pizza > 1 && food_slider.value < 0.67){
         playerData.Pizza -= 2;
         pizza_text.text = "#" + playerData.Pizza.ToString();
         food_slider.value += 0.33f;
         //
                // playerprefs update;
         //
        }
    
   }

   public void Consume_Medicine(){
        if(playerData.Medicine > 0 && health_slider.value < 0.51){
         playerData.Medicine -= 1;
         medicine_text.text = "#" + playerData.Medicine.ToString();
         health_slider.value += 0.5f;
         //
                // playerprefs update;
         //
        }
    
   }


public void Consume_Medkit(){
        if(playerData.Medkit > 0 && health_slider.value < 0.51){
         playerData.Medkit -= 1;
         medkit_text.text = "#" + playerData.Medkit.ToString();
         health_slider.value = 1;
         //
                // playerprefs update;
         //
        }
    
   }

   
/////////////////////////// Diner Buy //////////////////

    public void Buy_burger()
    {
        if(playerData.Coin >= 5)
        {
            ConfirmBuyMusic.GetComponent<AudioSource>().Play();
            playerData.Hamburger += 1;
            playerData.Coin -= 5;
            ItemsUpdate();
        }
        else
        {
            DeclineBuyMusic.GetComponent<AudioSource>().Play();
        }
    }

    public void Buy_hotdog()
    {
        if(playerData.Coin >= 3)
        {
            ConfirmBuyMusic.GetComponent<AudioSource>().Play();
            playerData.Hotdog += 1;
            playerData.Coin -= 3;
            ItemsUpdate();
        }
        else
        {
            DeclineBuyMusic.GetComponent<AudioSource>().Play();
        }
    }

    public void Buy_pizza()
    {
        if(playerData.Coin >= 1)
        {
            ConfirmBuyMusic.GetComponent<AudioSource>().Play();
            playerData.Pizza += 1;
            playerData.Coin -= 1;
            ItemsUpdate();
        }
        else
        {
            DeclineBuyMusic.GetComponent<AudioSource>().Play();
        }
    }
/////////////////////// gun shop //////////
  
   public void Buy_gun()
    {
        if(playerData.Coin >= 15)
        {
            ConfirmBuyMusic.GetComponent<AudioSource>().Play();
            playerData.Coin -= 15;
            playerData.Gun += 1;
            ItemsUpdate();
        }
        else
        {
            DeclineBuyMusic.GetComponent<AudioSource>().Play();
        }
    }

    public void Buy_bullet()
    {
        if(playerData.Coin >= 2)
        {
            ConfirmBuyMusic.GetComponent<AudioSource>().Play();
            playerData.Coin -= 2;
            playerData.Bullet += 1;
            ItemsUpdate();
        }
        else
        {
            DeclineBuyMusic.GetComponent<AudioSource>().Play();
        }
    }
////////////////////////////////////

public void Buy_key(){
    if(playerData.Coin >= 7){
        ConfirmBuyMusic.GetComponent<AudioSource>().Play();
        playerData.Coin -= 7;
        playerData.Key += 1;
       ItemsUpdate();
    }
    else
    {
        DeclineBuyMusic.GetComponent<AudioSource>().Play();
    }
}
//////////////////////////////////
public void Buy_Medicine(){
    if(playerData.Coin >= 4){
        ConfirmBuyMusic.GetComponent<AudioSource>().Play();
        playerData.Coin -= 4;
        playerData.Medicine += 1;
       ItemsUpdate();
    }
    else
    {
        DeclineBuyMusic.GetComponent<AudioSource>().Play();
    }
}

public void Buy_Medkit(){
    if(playerData.Coin >= 6){
        ConfirmBuyMusic.GetComponent<AudioSource>().Play();
        playerData.Coin -= 6;
        playerData.Medkit += 1;
       ItemsUpdate();
    }
    else
    {
        DeclineBuyMusic.GetComponent<AudioSource>().Play();
    }
    
}

////////////////////////////////////

 public void Buy_Torch(){
    if(playerData.Coin >= 3){
        ConfirmBuyMusic.GetComponent<AudioSource>().Play();
        playerData.Coin -= 3;
        playerData.Torch += 1;
       ItemsUpdate();
    }
    else
    {
        DeclineBuyMusic.GetComponent<AudioSource>().Play();
    }
}
 /////////////////
 public void Buy_Clue()
 {
     if (playerData.Coin >= 6)
     {
         ConfirmBuyMusic.GetComponent<AudioSource>().Play();
         playerData.Coin -= 6;
         playerData.Clue += 1;
         ItemsUpdate();
     }
     else
     {
         DeclineBuyMusic.GetComponent<AudioSource>().Play();
     }
 }

}
