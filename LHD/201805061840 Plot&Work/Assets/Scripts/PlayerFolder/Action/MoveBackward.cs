using UnityEngine;
using System.Collections;

public class MoveBackward : Action
{
    void Start()
    {
        triggerKey = KeyCode.S;

        
        parent = gameObject.GetComponentInParent<Player>();
    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }


    protected override void BeginEffect()
    {
        parent.transform.position += new Vector3(0, 0, -parent.GetPlayerBuffedStatus().speed * Time.deltaTime);
    }


}


