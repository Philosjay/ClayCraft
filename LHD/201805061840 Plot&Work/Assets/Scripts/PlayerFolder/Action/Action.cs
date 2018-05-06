using UnityEngine;
using UnityEditor;

public class Action : MonoBehaviour
{
    protected KeyCode triggerKey;           //触发该动作
    protected Player parent;         //作用的目标Player

    // 动作触发时的响应
    virtual protected void BeginEffect()
    {
        print("actionBegin");
    }


    protected void Update()
    {
        // 是否被触发
        if (TestTriggered())
        {
            BeginEffect();
        }
    }
        
    // 为不同的触发方式保留扩展
    virtual protected bool TestTriggered()
    {
        // 默认按键按下
        return Input.GetKeyDown(triggerKey);
    }
}