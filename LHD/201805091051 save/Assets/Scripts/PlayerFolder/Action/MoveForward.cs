using UnityEngine;
using System.Collections;

public class MoveForward : Action
{
    void Start()
    {
        triggerKey = KeyCode.W;
        parent = gameObject.GetComponentInParent<Player>();
    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }


    protected override void BeginEffect()
    {
        parent.transform.position += new Vector3(0, 0, parent.GetPlayerBuffedStatus().speed * Time.deltaTime);
    }


}

