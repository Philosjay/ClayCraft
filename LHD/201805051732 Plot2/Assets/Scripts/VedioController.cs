using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class VedioController : MonoBehaviour {

    GameObject mainCamera;
    AudioSource mainSource;
    GameObject audioController;
    VideoPlayer vedioPlayer;

    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainSource = mainCamera.GetComponent<AudioSource>();
        audioController = GameObject.Find("Plot Vedio Controller");
        vedioPlayer = audioController.GetComponent<VideoPlayer>();

    }

    // Update is called once per frame
    void Update () {

    }

    public void FadeOut()
    {
        Debug.Log("fade");
        DOTween.To(() => vedioPlayer.targetCameraAlpha, x => vedioPlayer.targetCameraAlpha = x, 0, 1);
        DOTween.To(() => mainSource.volume, x => mainSource.volume = x, 0, 1);

        StartCoroutine(WaitAndStop(1.0f));

        //Debug.Log(vedioPlayer.targetCamera);
        //Debug.Log(vedioPlayer.targetCameraAlpha);
    }

    //一段时间后关闭视频
    IEnumerator WaitAndStop(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        vedioPlayer.Stop();
    }



}
