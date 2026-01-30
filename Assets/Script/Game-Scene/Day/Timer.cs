using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject day , night;
    public TextMeshProUGUI clock;
    void OnEnable()
    {
     StartCoroutine(TimerClock(90));   
    }

    IEnumerator TimerClock(int second)
    {
     while(second > 0)
    {
      int min = second / 60;
      int sec = second % 60;
      clock.text = min.ToString() + ":" + sec.ToString(); 
      yield return new WaitForSeconds(1);
      second--;   
    }
    
    day.SetActive(false);
    night.SetActive(true);
    
    }
    

}
