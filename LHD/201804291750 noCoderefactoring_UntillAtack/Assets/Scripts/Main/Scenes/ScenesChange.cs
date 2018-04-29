using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ChangeSceneToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ChangeSceneToMultiMode()
    {
        SceneManager.LoadScene("MultiMode");
        if(Input.GetButton("Fire1"))
        {
            Debug.Log("Click");
        }
    }


}
