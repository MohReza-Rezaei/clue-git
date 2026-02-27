using System.Diagnostics;
using UnityEngine;

public class Shop : MonoBehaviour
{
   public GameObject[] Items = new GameObject[10];
   public GameObject[] Explain = new GameObject[20];
   public GameObject[] Inspector = new GameObject[20];

   public void Change()
    {
        foreach (var item in Items)
        {
        if(item != null)
        item.SetActive(false);  
        }

        foreach (var e in Explain)
        {
        if(e != null)
        e.SetActive(false);  
        }
        
        foreach (var i in Inspector)
        {
        if(i!= null)
        i.SetActive(false);   
        }

    }
}
