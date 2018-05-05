using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour {

    private GameObject plot1;

    // Use this for initialization
    void Start () {
        plot1 = GameObject.FindGameObjectWithTag("PlotTextPanel");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOnTextPanel()
    {
        plot1.SetActive(true);
        //plotText.DOText("我是谁？你知道我的名字吗？", 3);
    }

    public void TurnOffTextPanel()
    {
        plot1.SetActive(false);
    }





}
