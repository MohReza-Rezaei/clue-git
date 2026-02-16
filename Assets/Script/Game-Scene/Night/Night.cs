using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Interactions;



public class Night : MonoBehaviour
{
    public string[] clues = new string[7];
    public int endgame = 18;
    public Person police = new("Police");
    public Person Doctor = new("Doctor");
    public Person Chef = new("Chef");
    public Person Commissioner = new("Commissioner");
    public Person Ambassador = new("Ambassador");
    public Person GunSmith = new("GunSmith");
    public Person TorchSmith = new("TorchSmith");
    public Person KeySmith = new("KeySmith");
    public Person NoOne = new ("NoOne");
    public Person Killer = new("Killer");
    public int KillerHome;
    public int KillerTargetHome;
    readonly Person[] citizens = new Person[10];
    public House[] houses = new House[36];
    public GameObject[] lockIcon = new GameObject[36];

    public PoliceFile policeFile;
    public PlayerData1 playerData;

    List<string> items = new List<string>(); // 130

  
    void Start()
    {
        /// note! : NightUiSetUp() should be fixed (range of the loop is just for city 5)

    HousesInstance(); // create house objects
    CitizenInstance(); // create citizen objects
    CreateList(); // create list of items (random)
    GameSetUp(); // choose houses' roles (random)
    SetItems(); // set items into each house 
    NightUiSetUp(); // setup UI of the game
    MakeTag(); 
    ////
    // setup all clues 
    ClueSetUp();

    }


    void OnEnable()
    {
        if(endgame > 0)
        StartCoroutine(KillHeal());
    }
    ////////////////////////////////////////////////

    void CreateList()
    {
        AddItem("coin",50);
        AddItem("gun",3);
        AddItem("bullet",7);
        AddItem("key",10);
        AddItem("torch",10);
        AddItem("food",10);
        AddItem("clue",7);
        AddItem("empty",33);

        Shuffle(items);

    }
    
    void AddItem(string str,int num)
    {
        for(int i =0;i < num; i++)
        {
            items.Add(str);
        }
    }

        void Shuffle(List<string> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            int randomIndex = UnityEngine.Random.Range(0, i + 1);

            string temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void ShowList()
    {
        for(int i =0;i < items.Count ; i++)
        {
             print(items[i]);
        }
    }


    ////////////////////////////////////////////////
    void GameSetUp()
    {
       int[] notReapetedRoleHouse = new int[]{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
       int repeatCounter = 0;
       int counter = 0;
       bool permission;

       // for roles 

       while(counter < notReapetedRoleHouse.Length)
        {
            permission = true;
            int random = UnityEngine.Random.Range(1,37);
            for(int i = 0; i < notReapetedRoleHouse.Length; i++)
            {
                if(random == notReapetedRoleHouse[i])
                {
                    permission = false;
                    break;
                }   
            }


            if (permission)
            {   
                // repeat control
                notReapetedRoleHouse[repeatCounter] = random;
                repeatCounter++;
                //

                ///// main duty

                //print("house :"+ random);
                // chose role
                bool permissionRole = true;
                do
                {
                  int randomRole = UnityEngine.Random.Range(1,11);  
                  if(randomRole == 1 && !Killer.selected)
                    {
                    
                    houses[random-1].SetOwner(Killer);
                    houses[random-1].IsLocked = true;
                    Killer.selected = true;
                    permissionRole = false;
                    KillerHome = random-1;
                 //   print("Killer");
                    }else if (randomRole == 2 && !police.selected)
                    {

                    houses[random-1].SetOwner(police);
                    houses[random-1].IsLocked = true;
                    police.selected = true;
                    permissionRole = false;
                 //   print("Police");                       

                    }else if (randomRole == 3 && !Doctor.selected)
                    {

                    houses[random-1].SetOwner(Doctor);
                    houses[random-1].IsLocked = true;
                    Doctor.selected = true;
                    permissionRole = false;  
                 //   print("Doctor");                     

                    }else if (randomRole == 4 && !Chef.selected)
                    {

                    houses[random-1].SetOwner(Chef);
                    houses[random-1].IsLocked = true;
                    Chef.selected=true;
                    permissionRole = false;
                 //   print("Chef");                       

                    }else if (randomRole == 5 && !Commissioner.selected)
                    {

                    houses[random-1].SetOwner(Commissioner);
                    houses[random-1].IsLocked = true;
                    Commissioner.selected = true;
                    permissionRole = false;  
                 //    print("Commissioner");                     

                    }else if (randomRole == 6 && !Ambassador.selected)
                    {

                    houses[random-1].SetOwner(Ambassador);
                    houses[random-1].IsLocked = true;
                    Ambassador.selected = true;
                    permissionRole = false;  
                 //    print("Ambassador");                     

                    }else if (randomRole == 7 && !GunSmith.selected)
                    {

                    houses[random-1].SetOwner(GunSmith);
                    houses[random-1].IsLocked = true;
                    GunSmith.selected = true;
                    permissionRole = false;  
                //     print("GunSmith");                     

                    }else if (randomRole == 8 && !TorchSmith.selected)
                    {

                    houses[random-1].SetOwner(TorchSmith);
                    houses[random-1].IsLocked = true;
                    TorchSmith.selected = true;
                    permissionRole = false;    
                 //    print("TorchSmith");                   

                    }else if (randomRole == 9 && !KeySmith.selected)
                    {

                    houses[random-1].SetOwner(KeySmith);
                    houses[random-1].IsLocked = true;
                    KeySmith.selected = true;
                    permissionRole = false;   
                //   print("KeySmith");                    

                    }else if (randomRole == 10 && !NoOne.selected)
                    {
                        
                    houses[random-1].SetOwner(NoOne);
                    houses[random-1].IsLocked = true;
                    NoOne.selected = true;
                    permissionRole = false;
                //     print("NoOne"); 

                    }
                  
                }while(permissionRole);

                //end loop control
                counter++;
            }

        }
        
        // for citizens
        
        int[] notReapetedCitizenHouse = new int[]{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
        counter = 0;
        repeatCounter=0;
        int CitizenCounter=0;
        
        while(counter < notReapetedCitizenHouse.Length)
        {
            permission = true;
            int random = UnityEngine.Random.Range(1,37);
            for(int i = 0; i < notReapetedCitizenHouse.Length; i++)
            {
                if(random == notReapetedCitizenHouse[i])
                {
                    permission = false;
                    break;
                }   
            }
            for(int i = 0; i < notReapetedRoleHouse.Length; i++)
            {
                if(random == notReapetedRoleHouse[i])
                {
                    permission = false;
                    break;
                }   
            }


            if (permission)
            {   
                // repeat control
                notReapetedCitizenHouse[repeatCounter] = random;
                repeatCounter++;
                
                ///// main duty

                houses[random-1].SetOwner(citizens[CitizenCounter]);
                CitizenCounter++;
                //end loop control
                counter++;
            }

        }

    }

    


    void SetItems()
    {   

    
    int counter = 0;

    for(int i = 0;i < 36; i++)
    {
        

       if(houses[i].GetOwner() != null && houses[i].GetOwner().GetRole() != "Citizen")
       continue; // skip the house 

      string[] name = new string[5];

       for(int j = 0;j < 5; j++) // name.length = 5 
        {
         name[j] = items[counter];
         counter++;       
        }     

        houses[i].SetItems(name);
    }  



    }

    void NightUiSetUp()
    {
        // lock icon
        for(int i = 0; i < houses.Length ; i++)
        {
            if(houses[i].GetOwner() != null && houses[i].GetOwner().GetRole() != "Citizen")
            lockIcon[i].SetActive(true);
        }
    }
///////////////////////////////////////////////////

    void ClueSetUp()
    {
       Clue1();

    }

    void Clue1()
    {
        int range=-1;

        for(int i = 0; i < houses.Length; i++)
        {
            if (houses[i].GetOwner() != null)
            {
                if(houses[i].GetOwner().GetRole() == "Killer")
                {
                print("Killer is in house : "+ (i+1));
                 range = i;   
                }
            }
        }


        bool check = true;
        do
        {
        int rand = UnityEngine.Random.Range(1,7);

        if(rand == 1 && range > 5)
        {
        clues[0] = "City 1 is safe";
        check = false;
        }else if(rand == 2 && (range > 11 || range < 5))
        {
        clues[0] = "City 2 is safe";
        check = false;        
        }else if(rand == 3 && (range > 17 || range < 11))
        {
        clues[0] = "City 3 is safe";
        check = false;        
        }else if(rand == 4 && (range > 23 || range < 1))
        {
        clues[0] = "City 4 is safe";
        check = false;        
        }else if(rand == 5 && (range > 30 || range < 23))
        {
        clues[0] = "City 5 is safe";
        check = false;        
        }else if(rand == 6 && range < 30)
        {
        clues[0] = "City 6 is safe";
        check = false;        
        }


        }while(check);
        print(clues[0]);

    }

    void Clue2()
    {
        print(houses[KillerHome].GetTag(0));
    }

    public int Clue3()
    {
        int[] suspect = new int[3];
        int susCount = 0;
        for(int i = 0;i < 35; i++)
        {
            if(houses[i].GetOwner() == null || houses[i].GetOwner().GetRole() == "Citizen")
            {
               for(int j = 0;j < 5; j++)
               {
                if(houses[i].GetItem(j) == "gun")
                    {
                     suspect[susCount] = i+1;  
                     susCount++; 
                    }
               } 
            }
         }
            
        int random = UnityEngine.Random.Range(0,3);

        return suspect[random];
       
    }

    public void Clue4()
    {
     print(houses[KillerHome].GetTag(1));   
    }

    public void Clue5()
    {
     int target =(KillerTargetHome / 6) +1;
     print(" city " + target + " is dangerous tonight");    
    }

    void Clue6()
    {
     print(houses[KillerHome].GetTag(2));   
    }

    void Clue7()
    {
        if((KillerHome+1) % 2 == 0)
        {
        print("Even Houses are Suspicious");
        }
        else
        {
        print("Odd Houses are suspicious");
        }
    }

    void MakeTag()
    {
   string[][] combinations =
{
    new string[] { "luxury", "old", "damaged" },
    new string[] { "luxury", "old", "small" },
    new string[] { "luxury", "old", "furnished" },
    new string[] { "luxury", "damaged", "small" },
    new string[] { "luxury", "damaged", "furnished" },
    new string[] { "luxury", "small", "furnished" },
    new string[] { "old", "damaged", "small" },
    new string[] { "old", "damaged", "furnished" },
    new string[] { "old", "small", "furnished" },
    new string[] { "damaged", "small", "furnished" }
};


for (int i = combinations.Length - 1; i > 0; i--)
{
    int randomIndex = UnityEngine.Random.Range(0, i + 1);

    string[] temp = combinations[i];
    combinations[i] = combinations[randomIndex];
    combinations[randomIndex] = temp;
}


        int counter = 0;

        for(int j = 0; j < houses.Length; j++)
        {
            if (houses[j].IsLocked)
            {
                houses[j].hasTag = true;
                houses[j].SetTag(combinations[counter]);
                counter++;
            }
        }

    }

    ///////////////////////////////////////////

    void HousesInstance()
    {
        for(int i = 0;i < houses.Length; i++)
        {
            houses[i] = new House();
        }
    }

    void CitizenInstance()
    {
        for(int i =0; i < citizens.Length; i++)
        {
            citizens[i] = new Person();
        }
    }

////////////////////////////////
 
void KillAndHeal()
{

    //// kill
   int random;
   bool permission = true;
    do
    {
      random = UnityEngine.Random.Range(0,36); 

      if(houses[random].GetOwner() != null && houses[random].GetOwner().IsAlive() && houses[random].GetOwner().GetRole() != "NoOne" && houses[random].GetOwner().GetRole()!="Killer")
      {
      KillerTargetHome = random;
      print(houses[random].GetOwner().GetRole()+ " was Killed . House " + (random+1));
      policeFile.message[playerData.Nights-1] = houses[random].GetOwner().GetRole() + " was killed. House: " + (random+1).ToString();
      permission = false;
      endgame--;        
      }

    }while(permission);
   

   ///heal
    if(Doctor.IsAlive())
    Heal(random);
   

}
  
void Heal(int attackedHouse)
    {
   int random;
   bool permission = true;
    do
    {
      random = UnityEngine.Random.Range(0,36); 

      if(houses[random].GetOwner() != null && houses[random].GetOwner().IsAlive() &&  houses[random].GetOwner().GetRole() != "NoOne")
      {
      print(houses[random].GetOwner().GetRole()+ " was saved . House " + (random+1));
      permission=false;
      if(random == attackedHouse)
        {
            endgame++;
            policeFile.message[playerData.Nights-1] = houses[random].GetOwner().GetRole() + " was Saved by Doctor.";
            
            print("wow");
        }
        else
        {
          houses[attackedHouse].GetOwner().SwapAliveStatus();          
        }         
      }

    }while(permission);  
    }

IEnumerator KillHeal()
    {
        yield return new WaitForSeconds(1);
        KillAndHeal();
    }


///////////////////////////////
}

public class Person{
    private string role;
    private bool alive;
    public bool selected;
    public Person(string r)
    {
        role = r;
        alive= true;
        selected = false;
    }

    public Person()
    {
        role = "Citizen";
        alive = true;
        selected = false;
    }
    //////////////////////////
    public void Set(string r)
    {
     role = r;
     alive = true;
     selected = false; 
    }
    ///////////////////////////
    public string GetRole()
    {
        return role;
    }
    ///////////////////////////
    public bool IsAlive()
    {
        return alive;
    }
    
    public void SwapAliveStatus()
    {
        if (alive)
        {
            alive = false;
        }
        else
        {
            alive = true;
        }  
    }
   
    
}


public class House
{
    private Person owner;
    private string[] items = new string[5];
    public bool IsLocked;
    public bool hasTag;
    private string[] Tags = new string[3];

    public House()
    {
        owner = null;
        IsLocked = false;
        hasTag = false;
        
        for(int i = 0;i < items.Length; i++)
        {
            items[i] = "empty";
        }
    }

/// /////////////////////////////////

    public void SetOwner(Person p)
    {
        owner = p;
    }
    public Person GetOwner()
    {
        return owner;
    }
/////////////////////////////////////
    public void SetItems(string[] n)
    {
    items = n;    
    }

    public void SetOneItem(string n,int i)
    {
    items[i] = n;   
    }

    public string GetItem(int index)
    {
        return items[index];
    }

    public int Items_size()
    {
        return items.Length;
    }

    //////////////////////////////////////
    
    public void SetTag(string[] tags)
    {

      for(int i =0;i < 3; i++)
        {
            Tags[i] = tags[i];
        }

    }

    public string GetTag(int i)
    {
    return Tags[i];    
    }

}