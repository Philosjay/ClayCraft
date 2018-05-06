using UnityEngine;
using UnityEditor;

public class ActionWithCD : Action
{
    protected float CD = 0;                 // 冷却时间
    protected float timeSinceActivate = 0;  // 触发后计时，与CD作比较
    protected bool isActivate = false;


    // 动作冷却后的响应 一个动作周期结束
    virtual protected void CooledEffect()
    {
        print("actionEnd");
    }


    new void Update()
    {


        if (isActivate)
        {
            timeSinceActivate += Time.deltaTime;

            // CD是否跑完
            if (timeSinceActivate > CD)
            {
                timeSinceActivate = 0;
                isActivate = false;
                CooledEffect();
            }
        }


        // 是否被触发
        if (TestTriggered())
        {
            // 是否已经冷却
            if (timeSinceActivate == 0)
            {
                BeginEffect();
                timeSinceActivate = 0;
                isActivate = true;
            }

        }
    }

}