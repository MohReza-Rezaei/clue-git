using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class Starttime : MonoBehaviour
{
  private string level;
  
  public void Getname(string name)
    {
       level = name; 
    }


 IEnumerator Time(int n)
    {
        for(int i = 0;i < n; i++)
        {
            yield return new WaitForSeconds(1f);
            print(i+1);
        }
        SceneManager.LoadScene(level);
    }


 

public void DoTime(int n)
    {
        StartCoroutine(Time(n));
    }

}
