using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    GameObject sceneLight;

    LightController lightController;


    // Use this for initialization
    void Start () {
        sceneLight = GameObject.FindGameObjectWithTag("Light");
        lightController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LightController>();

    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(sceneLight.name);
	}

    public void TurnOnLight()
    {
        sceneLight.SetActive(true);
    }

    public void TurnOffLight()
    {
        sceneLight.SetActive(false);
    }

    //一段时间后打开聚光灯
    public IEnumerator WaitAndTurnOnTheLight(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        lightController.TurnOnLight();
    }

    //一段时间后调整光源
    public IEnumerator WaitAndAjustTheLight(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        sceneLight.GetComponent<Light>().type = LightType.Directional;
        sceneLight.GetComponent<Light>().intensity = 2;
        sceneLight.transform.SetPositionAndRotation(Vector3.zero,Quaternion.Euler(40, -200, 0));
    }

}
