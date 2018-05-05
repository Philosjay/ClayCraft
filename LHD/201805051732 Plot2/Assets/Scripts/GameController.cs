using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    VedioController vedioController;
    LightController lightController;
    UIController uiController;
    DialogueController dialogueController;
    TimelineController timelineController;
    PlayerController playerController;

    private int currentPlot = 1;

	// Use this for initialization
	void Start () {
        lightController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LightController>();
        vedioController = GameObject.FindGameObjectWithTag("GameController").GetComponent<VedioController>();
        uiController = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>();
        dialogueController = GameObject.FindGameObjectWithTag("GameController").GetComponent<DialogueController>();
        timelineController = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimelineController>();
        playerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();


        StartCoroutine(WaitAndStart(0.1f));

    }

    // Update is called once per frame
    void Update () {
        ShowTime();
	}

    IEnumerator WaitAndStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        uiController.TurnOffTextPanel();
        lightController.TurnOffLight();
    }

    public void ShowTime()
    {
        //Debug.Log(currentPlot);
        switch (currentPlot)
        {
            case 1:
                Plot1();
                break;
            case 2:
                Plot2();
                break;
            case 3:
                break;
            default:
                break;
        }
    }

    void Plot1()
    {
        //鼠标点击淡出
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("当点击屏幕的时候可以触发跳转场景等一些事件");
            vedioController.FadeOut();
            StartCoroutine(lightController.WaitAndTurnOnTheLight(3.0f));
            //StartCoroutine(dialogueController.WaitAndPrint(6.0f));
            currentPlot += 1;
            Debug.Log(currentPlot);
        }
    }

    void Plot2()
    {
        Debug.Log(dialogueController.currentDialogue);
        StartCoroutine(dialogueController.WaitAndPrint(6.0f));
        timelineController.PlayPlot();
        StartCoroutine(playerController.WaitAndEnable(16.0f));

        currentPlot += 1;

    }


}
