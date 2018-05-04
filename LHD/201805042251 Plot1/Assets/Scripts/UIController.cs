using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour {

    private GameObject plot1;
    private Text plotText;

    //打字机效果相关
    public float letterPause = 0.2f;
    //private AudioSource printAudio;
    private string tempWord;
    private string text = "我是谁？你知道我的名字吗？";
    //public AudioClip printClip;
    

	// Use this for initialization
	void Start () {
        plot1 = GameObject.FindGameObjectWithTag("PlotTextPanel");
        plotText = plot1.GetComponentInChildren<Text>();

        tempWord = text;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOnTextPanel()
    {
        plot1.SetActive(true);
        plotText.DOText("我是谁？你知道我的名字吗？", 3);
    }

    public void TurnOffTextPanel()
    {
        plot1.SetActive(false);
    }

    //一段时间后显示文字
    public IEnumerator WaitAndPrint(float waitTime)
    {
        //yield return new WaitForSeconds(waitTime);
        //plot1.SetActive(true);
        //plotText.DOText("我是谁？", 3);
        //plotText.DOText("我是谁？你知道我的名字吗？", 5);

        yield return new WaitForSeconds(waitTime);
        plot1.SetActive(true);

        foreach (char letter in tempWord.ToCharArray())
        {
            plotText.text += letter;
            //if (clip)
            //{
            //    source.PlayOneShot(clip);
            //}
            yield return new WaitForSeconds(letterPause);
        }
    }


}
