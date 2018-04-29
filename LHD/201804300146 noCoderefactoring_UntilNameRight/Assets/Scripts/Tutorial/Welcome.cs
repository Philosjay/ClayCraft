using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welcome : MonoBehaviour {

    //欢迎面板
    private GameObject WelcomePanel;

    //角色姓名传递
    private GameObject nameInputField;
    private InputField nameIf;
    private GameObject player;
    public string name;

    

    //public GameObject welcomePanelPrefab;

	// Use this for initialization
	void Start () {
        WelcomePanel = GameObject.Find("WelcomePanel");
        nameInputField = GameObject.FindGameObjectWithTag("InputField");
        nameIf = nameInputField.GetComponent<InputField>();
        player = GameObject.FindGameObjectWithTag("Player");
        

        //GameObject welcomePanel = GameObject.Instantiate(welcomePanelPrefab) as GameObject;
        //RectTransform welcomePanelRtf = welcomePanel.transform as RectTransform;
        //welcomePanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        //SetRect(welcomePanelRtf, 0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OkClick()
    {
        //获取输入的角色名
        name = nameIf.text;

        //添加血条脚本
        BloodPlayer blPlayer =  player.AddComponent<BloodPlayer>();
        blPlayer.name = name;
        blPlayer.blood_red = (Texture2D)Resources.Load("Textures/blood_red");
        blPlayer.blood_black = (Texture2D)Resources.Load("Textures/blood_black");




        WelcomePanel.SetActive(false);
        //GameObject player = GameObject.Instantiate(playerPrefab) as GameObject;
        //player.transform.position = new Vector3(10,20,10);

    }

    //public static void SetRect(RectTransform trs, float left, float top, float right, float bottom)
    //{
    //    trs.offsetMin = new Vector2(left, bottom);
    //    trs.offsetMax = new Vector2(-right, -top);
    //}
}
