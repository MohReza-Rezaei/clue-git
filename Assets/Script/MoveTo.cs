using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Camera mainCam;
    public AudioListener mainListener;
    public Camera settingsCam;
    public AudioListener settingListener;

    void Start()
    {
        SwitchToMain();
    }

    public void SwitchToMain()
    {
        mainCam.enabled = true;
        mainListener.enabled = true;
         /////
        settingsCam.enabled = false;
        settingListener.enabled = false;
    }

    public void SwitchToMenu()
    {
        mainCam.enabled = false;
    //    menuCam.enabled = true;
        settingsCam.enabled = false;
    }

    public void SwitchToSettings()
    {
        mainCam.enabled = false;
        mainListener.enabled = false;
        ////
        settingsCam.enabled = true;
        settingListener.enabled = true;
    }
}

