using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ActionWithCD {
    
    private bool isEffective = false;  
    protected float effectiveTime;      // 增加效果时间，注意区别于CD，effectiveTime小于等于CD

    // 增加效果结束后的响应
    virtual protected  void EndEffect()
    {
        print("skill end");
    }

    new void Update()
    {
        if (isActivate)
        {
            timeSinceActivate += Time.deltaTime;

            if (isEffective)
            {
                // 效果时间结束
                if (timeSinceActivate > effectiveTime)
                {
                    EndEffect();
                    isEffective = false;
                }
            }


            // CD是跑完
            if (timeSinceActivate > CD)
            {
                CooledEffect();
                timeSinceActivate = 0;
                isActivate = false;
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
                isEffective = true;
            }

        }
    }
}
