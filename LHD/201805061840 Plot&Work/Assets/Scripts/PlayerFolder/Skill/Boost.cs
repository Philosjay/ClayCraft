using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : Skill {

    void Start()
    {
        effectiveTime = 3f;
        CD = 10f;
        triggerKey = KeyCode.Alpha1;
        parent = gameObject.GetComponentInParent<Player>();
    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }

    protected override void BeginEffect()
    {
        //暂时修改玩家状态
        print("boost");
        PlayerStatus status = parent.GetPlayerStatus();
        status.speed += 30;
        parent.SetPlayerStatus(status);
    }

    protected override void CooledEffect()
    {
        print("boost cooled");
    }

    protected override void EndEffect()
    {
        //还原玩家状态
        print("boost end");
        PlayerStatus status = parent.GetPlayerStatus();
        status.speed -= 30;
        parent.SetPlayerStatus(status);
    }


}
