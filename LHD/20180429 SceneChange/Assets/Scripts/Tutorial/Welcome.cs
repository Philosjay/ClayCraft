using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour {

    public GameObject WelcomePanel;
    //public GameObject welcomePanelPrefab;

	// Use this for initialization
	void Start () {
        WelcomePanel = GameObject.Find("WelcomePanel");
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
