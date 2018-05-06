using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : Skill {

    //判断是否落地
    private bool grounded = true;
    Rigidbody playerRigidbody;

    void Start()
    {
        effectiveTime = 2f;
        CD = 5f;
        triggerKey = KeyCode.Alpha4;
    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }

    protected override void BeginEffect()
    {
        //暂时修改玩家状态
        print("dodge");
        if (grounded == true)
        {
            playerRigidbody = GetComponent<Rigidbody>();
            playerRigidbody.velocity += new Vector3(0, 10, 0); //添加加速度
            playerRigidbody.AddForce(Vector3.up * 50); //给刚体一个向上的力，力的大小为Vector3.up*mJumpSpeed
            grounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    protected override void CooledEffect()
    {
        print("dodge cooled");
    }

    protected override void EndEffect()
    {
        //还原玩家状态
        print("dodge end");
        
    }
}
