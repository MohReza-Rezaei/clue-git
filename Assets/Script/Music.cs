using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Slider slider;
    public AudioSource MenuMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     MenuMusic.volume = slider.value;   
    }
}
