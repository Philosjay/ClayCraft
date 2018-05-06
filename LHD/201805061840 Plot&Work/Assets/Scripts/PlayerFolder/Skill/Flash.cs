using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : Skill {
    
    //一次闪现距离
    float flashDistance = 7f;
    // KeyCode leftmouse = KeyCode.Mouse0;

    void Start()
    {
        effectiveTime = 3f;
        CD = 10f;
        triggerKey = KeyCode.Alpha2;
        parent = gameObject.GetComponentInParent<Player>();

        
    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }

    protected override void BeginEffect()
    {
        //暂时修改玩家状态
        print("flash");

        //闪现 闪现方向->鼠标点击方向
        if(true)
        {
            print("getmouse");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit = new RaycastHit();
           if(Physics.Raycast(ray,out hit))
           {              
               if(hit.transform.CompareTag("Plane"))
               {
                Vector3 hitPos = hit.point;
                Vector3 playerPos = transform.position;
                //统一y  dir只在xz平面
                playerPos.y = hitPos.y;
                Vector3 dir = hitPos - playerPos;
                //dir归一
                dir = dir.normalized;
                Vector3 targetPos = transform.position + dir * flashDistance;
                //现在有个问题：闪现后的地面高度y不一样怎么解决
                //targetPos.y = hitPos.y;
                transform.position = targetPos;
       
               }
           }
        }

    }

    protected override void CooledEffect()
    {
        print("flash cooled");
    }

    protected override void EndEffect()
    {

        print("flash end");
   
    }
}
