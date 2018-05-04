using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

    private GameObject plot1;
    private Text plotText;

    [System.Serializable]
    public enum dialogueText
    {
        我是谁,
        你知道我的名字吗,
        我感觉身体很痛,
        你能帮助我重塑身体吗
     }

    //打字机效果相关
    public float letterPause = 0.2f;
    //private AudioSource printAudio;
    public int currentDialogue = 1;
    private string tempWord;
    private string text = "我是谁?你知道我的名字吗?";
    //public AudioClip printClip;

    // Use this for initialization
    void Start () {
        plot1 = GameObject.FindGameObjectWithTag("PlotTextPanel");

        plotText = plot1.GetComponentInChildren<Text>();

        tempWord = text;
    }

    //一段时间后显示文字
    public IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        plot1.SetActive(true);

        switch (currentDialogue)
        {
            case 1:          
                tempWord = dialogueText.我是谁.ToString();
                foreach (char letter in tempWord.ToCharArray())
                {
                    plotText.text += letter;
                    //if (clip)
                    //{
                    //    source.PlayOneShot(clip);
                    //}
                    yield return new WaitForSeconds(letterPause);
                }
                plotText.text = "我是谁?";
                currentDialogue += 1;
                goto case 2;
                
            case 2:
                yield return new WaitForSeconds(1.0f);
                tempWord = dialogueText.你知道我的名字吗.ToString();
                foreach (char letter in tempWord.ToCharArray())
                {
                    plotText.text += letter;
                    //if (clip)
                    //{
                    //    source.PlayOneShot(clip);
                    //}
                    yield return new WaitForSeconds(letterPause);
                }
                plotText.text = "我是谁?你知道我的名字吗?";
                currentDialogue += 1;
                break;
            case 3:
                tempWord = dialogueText.我感觉身体很痛.ToString();
                foreach (char letter in tempWord.ToCharArray())
                {
                    plotText.text += letter;
                    //if (clip)
                    //{
                    //    source.PlayOneShot(clip);
                    //}
                    yield return new WaitForSeconds(letterPause);
                }
                plotText.text = "我感觉身体很痛...";
                currentDialogue += 1;
                goto case 4;
            case 4:
                yield return new WaitForSeconds(1.0f);
                tempWord = dialogueText.你能帮助我重塑身体吗.ToString();
                foreach (char letter in tempWord.ToCharArray())
                {
                    plotText.text += letter;
                    //if (clip)
                    //{
                    //    source.PlayOneShot(clip);
                    //}
                    yield return new WaitForSeconds(letterPause);
                }
                plotText.text = "我感觉身体很痛...你能帮助我重塑身体吗?";
                currentDialogue += 1;
                break;
            default:
                break;
        }
        //foreach (char letter in tempWord.ToCharArray())
        //{
        //    plotText.text += letter;
        //    //if (clip)
        //    //{
        //    //    source.PlayOneShot(clip);
        //    //}
        //    yield return new WaitForSeconds(letterPause);
        //}
    }
}
