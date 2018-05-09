using System;
using UnityEngine;

public class MoveLeft : Action
{
    void Start()
    {
        triggerKey = KeyCode.A;
        parent = gameObject.GetComponentInParent<Player>();
    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }


    protected override void BeginEffect()
    {
        parent.transform.position += new Vector3(-parent.GetPlayerBuffedStatus().speed * Time.deltaTime, 0, 0);
    }


}
