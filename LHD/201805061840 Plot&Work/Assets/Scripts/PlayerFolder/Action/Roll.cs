using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : ActionWithCD{

    void Start()
    {
        CD = 5f;
        triggerKey = KeyCode.T;
        parent = gameObject.GetComponentInParent<Player>();
    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }

    protected override void BeginEffect()
    {
        print("roll");
    }

    protected override void CooledEffect()
    {
        print("roll cooled");
    }
}
