using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class GameController : MonoBehaviour {

    VedioController vedioController;
    LightController lightController;
    UIController uiController;
    DialogueController dialogueController;
    TimelineController timelineController;
    PlayerController playerController;
    SceneController sceneController;
    //Manipulator manipulator;

    GameObject audioController;
    VideoPlayer vedioPlayer;

    public int currentPlot = 1;

    // Use this for initialization
    void Start () {
        lightController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LightController>();
        vedioController = GameObject.FindGameObjectWithTag("GameController").GetComponent<VedioController>();
        uiController = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>();
        dialogueController = GameObject.FindGameObjectWithTag("GameController").GetComponent<DialogueController>();
        timelineController = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimelineController>();
        playerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();

        audioController = GameObject.FindGameObjectWithTag("PlotVedioController");
        vedioPlayer = audioController.GetComponent<VideoPlayer>();

        //if (SceneManager.GetActiveScene().name == "Work")
        //{
        //    Debug.Log(SceneManager.GetActiveScene().name);
        //    manipulator = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manipulator>();
        //}


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
        Debug.Log(currentPlot);
        switch (currentPlot)
        {
            case 1:
                Plot1();
                break;
            case 2:
                Plot2();
                break;
            case 3:
                Plot3();
                break;
            case 4:
                Plot4();
                break;
            case 5:
                Plot5();
                break;
            default:
                break;
        }
    }

    void Plot1()
    {
        if (SceneManager.GetActiveScene().name == "Work")
        { 
            currentPlot = 4;
        }
        //鼠标点击淡出
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("当点击屏幕的时候可以触发跳转场景等一些事件");
            vedioController.FadeOut();
            StartCoroutine(lightController.WaitAndTurnOnTheLight(3.0f));
            currentPlot += 1;
            Debug.Log(currentPlot);
        }
    }

    void Plot2()
    {
        Debug.Log(dialogueController.currentDialogue);

        StartCoroutine(dialogueController.WaitAndPrint(6.0f));
        timelineController.PlayPlot();

        StartCoroutine(lightController.WaitAndAjustTheLight(16.0f));

        StartCoroutine(playerController.WaitAndEnable(20.0f));
        StartCoroutine(sceneController.WaitAndBeSceneBox(20.0f));

        currentPlot += 1;

    }

    void Plot3()
    {
        StartCoroutine(dialogueController.WaitAndPrint(15.0f));
        currentPlot += 1;
    }

    void Plot4()
    {
        if (SceneManager.GetActiveScene().name == "Work")
        {
            Debug.Log("trying");
            //    //manipulator = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manipulator>();

            //    //StartCoroutine(manipulator.LoadWorkCamera(0.1f));
            currentPlot += 1;
        }
    }

    void Plot5()
    {
        if (SceneManager.GetActiveScene().name == "Plot1")
        {
            vedioPlayer.Stop();
        }
    }


}
