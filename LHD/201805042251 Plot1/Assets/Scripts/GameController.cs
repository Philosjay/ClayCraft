using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    VedioController vedioController;
    LightController lightController;
    UIController uiController;

	// Use this for initialization
	void Start () {
        lightController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LightController>();
        vedioController = GameObject.FindGameObjectWithTag("GameController").GetComponent<VedioController>();
        uiController = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>();

        uiController.TurnOffTextPanel();
        lightController.TurnOffLight();

    }

    // Update is called once per frame
    void Update () {
        CheckClickAndFade();
	}

    void CheckClickAndFade()
    {
        //鼠标点击淡出
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("当点击屏幕的时候可以触发跳转场景等一些事件");
            vedioController.FadeOut();
            StartCoroutine(lightController.WaitAndTurnOnTheLight(3.0f));
            StartCoroutine(uiController.WaitAndPrint(6.0f));
        }
    }
}
