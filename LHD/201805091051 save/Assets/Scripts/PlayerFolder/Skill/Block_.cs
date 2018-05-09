using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_ : Skill {

    void Start()
    {
        effectiveTime = 1f;
        CD = 5f;
        triggerKey = KeyCode.Alpha3;
        parent = gameObject.GetComponentInParent<Player>();
    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }

    protected override void BeginEffect()
    {
        //暂时修改玩家状态
        print("block");
        PlayerStatus status = parent.GetPlayerStatus();
        status.speed += 10;
        parent.SetPlayerStatus(status);
    }

    protected override void CooledEffect()
    {
        print("block cooled");
    }

    protected override void EndEffect()
    {
        //还原玩家状态
        print("block end");
        PlayerStatus status = parent.GetPlayerStatus();
        status.speed -= 10;
        parent.SetPlayerStatus(status);
    }
}
