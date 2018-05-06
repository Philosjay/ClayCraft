using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

    private GameObject plot1;
    private Text plotText;

    public enum dialogueText
    {
        我是谁,
        你知道我的名字吗,
        我感觉身体很痛,
        你能帮助我重塑身体吗,
        地上有一些散落的材料可以用于重塑我的身体,
        让我们捡一些带回去吧,
        按下C键进行拾取,
        让我们带着黏土回到工坊吧
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
            #region case1
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
            #endregion 

            #region case2
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
            #endregion

            #region case3
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
            #endregion

            #region case4
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
            #endregion

            #region case5
            case 5:

                yield return new WaitForSeconds(5.0f);
                plotText.text = "";

                tempWord = dialogueText.地上有一些散落的材料可以用于重塑我的身体.ToString();
                foreach (char letter in tempWord.ToCharArray())
                {
                    plotText.text += letter;
                    //if (clip)
                    //{
                    //    source.PlayOneShot(clip);
                    //}
                    yield return new WaitForSeconds(letterPause);
                }
                plotText.text = "地上有一些散落的材料可以用于重塑我的身体...";
                currentDialogue += 1;
                goto case 6;
            #endregion

            #region case6
            case 6:
                yield return new WaitForSeconds(1.0f);
                tempWord = dialogueText.让我们捡一些带回去吧.ToString();
                foreach (char letter in tempWord.ToCharArray())
                {
                    plotText.text += letter;
                    //if (clip)
                    //{
                    //    source.PlayOneShot(clip);
                    //}
                    yield return new WaitForSeconds(letterPause);
                }
                plotText.text = "地上有一些散落的材料可以用于重塑我的身体...让我们捡一些带回去吧!";
                currentDialogue += 1;
                goto case 7;
            #endregion

            #region case7
            case 7:
                yield return new WaitForSeconds(1.0f);
                plotText.text = "";

                tempWord = dialogueText.按下C键进行拾取.ToString();
                foreach (char letter in tempWord.ToCharArray())
                {
                    plotText.text += letter;
                    //if (clip)
                    //{
                    //    source.PlayOneShot(clip);
                    //}
                    yield return new WaitForSeconds(letterPause);
                }
                plotText.text = "按下C键进行拾取...";
                currentDialogue += 1;
                goto case 8;
            #endregion

            #region case8
            case 8:
                yield return new WaitForSeconds(1.0f);

                tempWord = dialogueText.让我们带着黏土回到工坊吧.ToString();
                foreach (char letter in tempWord.ToCharArray())
                {
                    plotText.text += letter;
                    //if (clip)
                    //{
                    //    source.PlayOneShot(clip);
                    //}
                    yield return new WaitForSeconds(letterPause);
                }
                plotText.text = "按下C键进行拾取...让我们带着黏土回到工坊吧!";
                currentDialogue += 1;
                break;
            #endregion
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
