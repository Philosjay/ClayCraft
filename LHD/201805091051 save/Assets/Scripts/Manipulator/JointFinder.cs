using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointFinder : MonoBehaviour {
    Vector3 head;
    Transform modelRef;
    Transform hip;
    Transform spine2;

    // Use this for initialization
    void Start () {
        Debug.Log("start jf");
        modelRef = transform.Find("/SceneGameObjects/Player").Find("Character1_Reference");
        hip = modelRef.Find("Character1_Hips");
        spine2 = hip.Find("Character1_Spine").Find("Character1_Spine1").Find("Character1_Spine2");

        head = spine2.Find("Character1_Neck").Find("Character1_Head").transform.position;
    }
	
	// Update is called once per frame
	void Update () {




        
	}

    public Vector3 getHeadJointPos()
    {
//        Debug.Log(head);
        return head;
    }
}
