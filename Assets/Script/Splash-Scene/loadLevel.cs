using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class loadLevel : MonoBehaviour
{
   public string LevelName ;

   public void GetName(string name)
    {
        LevelName = name;
    }

   public void Doload()
    {
      SceneManager.LoadScene(LevelName);  
    }


}
