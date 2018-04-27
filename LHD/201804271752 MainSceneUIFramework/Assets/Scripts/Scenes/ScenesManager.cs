using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour {

    public GameObject Bt_SinglePlayer;
    public GameObject Bt_MultiPlayer;
    public GameObject Bt_Settings;
    public GameObject Bt_About;
    public GameObject Bt_SettingsPanel;
    public GameObject Bt_AboutPanel;
    public GameObject Bt_Back;

    // Use this for initialization
    void Start () {
        Bt_SinglePlayer = GameObject.Find("Singleplayer mode");
        Bt_MultiPlayer = GameObject.Find("Multiplayer mode");
        Bt_Settings = GameObject.Find("Settings");
        Bt_About = GameObject.Find("About us");
        Bt_SettingsPanel = GameObject.Find("SettingsPanel");
        Bt_AboutPanel = GameObject.Find("AboutPanel");
        Bt_Back = GameObject.Find("Back");

        Bt_SettingsPanel.SetActive(false);
        Bt_AboutPanel.SetActive(false);
        Bt_Back.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SettingsClick()
    {
        //hide the other buttons
        Bt_SinglePlayer.SetActive(false);
        Bt_MultiPlayer.SetActive(false);
        Bt_Settings.SetActive(false);
        Bt_About.SetActive(false);

        //show the SettingsPanel
        Bt_SettingsPanel.SetActive(true);
        Bt_Back.SetActive(true);
    }

    public void AboutClick()
    {
        //hide the other buttons
        Bt_SinglePlayer.SetActive(false);
        Bt_MultiPlayer.SetActive(false);
        Bt_Settings.SetActive(false);
        Bt_About.SetActive(false);

        //show the SettingsPanel
        Bt_AboutPanel.SetActive(true);
        Bt_Back.SetActive(true);
    }

    public void BackClick()
    {
        //show the other buttons
        Bt_SinglePlayer.SetActive(true);
        Bt_MultiPlayer.SetActive(true);
        Bt_Settings.SetActive(true);
        Bt_About.SetActive(true);

        //hide
        Bt_SettingsPanel.SetActive(false);
        Bt_AboutPanel.SetActive(false);
        Bt_Back.SetActive(false);
    }


}
