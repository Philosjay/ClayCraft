using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UIBtnManager : MonoBehaviour
{
    BtnGroup[] btnGroupHolder;

    HeadBtnGroup headGroup;
    UpBodyBtnGroup upBodyGroup;
    BodyBtnGroup btBodyGroup;
    LArmBtnGroup lArmGroup;
    RArmBtnGroup rArmGroup;
    LLegBtnGroup lLegGroup;
    RLegBtnGroup rLegGroup;

    ClickInfoHolder clickInfo;

    int lastGroup, curGroup;

    public enum Part
    {
        Head,
        Body,
        LArm,
        RArm,
        LLeg,
        RLeg,
        count,
    }

    public enum btnGroup
    {
        Head,
        UpBody,
        BtBody,
        LArm,
        RArm,
        LLeg,
        RLeg,
        count,
    }

    public enum Joint
    {
        spine2,
        lForeArm,
        rForeArm,
        lUpLeg_lLeg,
        rUpLeg_rLeg,
        count,
    }
    public enum JointPair
    {
        body_lLeg,
        body_rLeg,
        body_lArm,
        body_rArm,

        count,
    }

    private void Start()
    {

        StartCoroutine(LoadResources(1f));

        clickInfo = new ClickInfoHolder();

        headGroup = new HeadBtnGroup();
        upBodyGroup = new UpBodyBtnGroup();
        btBodyGroup = new BodyBtnGroup();
        lArmGroup = new LArmBtnGroup();
        rArmGroup = new RArmBtnGroup();
        lLegGroup = new LLegBtnGroup();
        rLegGroup = new RLegBtnGroup();

        btnGroupHolder = new BtnGroup[(int)btnGroup.count];


        btnGroupHolder[(int)btnGroup.Head] = headGroup;
        btnGroupHolder[(int)btnGroup.UpBody] = upBodyGroup;
        btnGroupHolder[(int)btnGroup.BtBody] = btBodyGroup;
        btnGroupHolder[(int)btnGroup.LArm] = lArmGroup;
        btnGroupHolder[(int)btnGroup.RArm] = rArmGroup;
        btnGroupHolder[(int)btnGroup.LLeg] = lLegGroup;
        btnGroupHolder[(int)btnGroup.RLeg] = rLegGroup;

        // 获得按钮的引用

        Transform Head = GameObjectHolder.Btn_Head.transform;
        Transform Body = GameObjectHolder.Btn_Body.transform;
        Transform LArm = GameObjectHolder.Btn_LArm.transform;
        Transform RArm = GameObjectHolder.Btn_RArm.transform;
        Transform LLeg = GameObjectHolder.Btn_LLeg.transform;
        Transform RLeg = GameObjectHolder.Btn_RLeg.transform;

        // 头部
        for (int i = 0; i < (int)HeadBtnGroup.HeadBtn.count; i++)
        {
            headGroup.putBtn(i, GameObjectHolder.Btn_Head_headBtn[i]);
        }
        headGroup.putBtn((int)HeadBtnGroup.HeadBtn.head, GameObjectHolder.Btn_Head_headMonitorBtn);

        // 左臂
        for (int i = 0; i < (int)LArmBtnGroup.LArmBtn.count; i++)
        {
            lArmGroup.putBtn(i, GameObjectHolder.Btn_LArm_lArmBtn[i]);
        }
        lArmGroup.putBtn((int)LArmBtnGroup.LArmBtn.lArm, GameObjectHolder.Btn_LArm_lArmMonitorBtn);

        // 右臂
        for (int i = 0; i < (int)RArmBtnGroup.RArmBtn.count; i++)
        {
            rArmGroup.putBtn(i, GameObjectHolder.Btn_RArm_rArmBtn[i]);
        }
        rArmGroup.putBtn((int)RArmBtnGroup.RArmBtn.rArm, GameObjectHolder.Btn_RArm_rArmMonitorBtn);

        // 左腿
        for (int i = 0; i < (int)LLegBtnGroup.LLegBtn.count; i++)
        {
            lLegGroup.putBtn(i, GameObjectHolder.Btn_LLeg_lLegBtn[i]);
        }
        lLegGroup.putBtn((int)LLegBtnGroup.LLegBtn.lLeg, GameObjectHolder.Btn_LLeg_lLegMonitorBtn);

        // 右腿
        for (int i = 0; i < (int)RLegBtnGroup.RLegBtn.count; i++)
        {
            rLegGroup.putBtn(i, GameObjectHolder.Btn_RLeg_rLegBtn[i]);
        }
        rLegGroup.putBtn((int)RLegBtnGroup.RLegBtn.rLeg, GameObjectHolder.Btn_RLeg_rLegMonitorBtn);


        // 上身
        upBodyGroup.putBtn((int)UpBodyBtnGroup.UpBodyBtn.body2, GameObjectHolder.Btn_Body_bodyBtn[2].gameObject);
        upBodyGroup.putBtn((int)UpBodyBtnGroup.UpBodyBtn.body6, GameObjectHolder.Btn_Body_bodyBtn[6].gameObject);
        upBodyGroup.putBtn((int)UpBodyBtnGroup.UpBodyBtn.spine2, GameObjectHolder.Btn_Body_spine2.gameObject);

        // 下身
        btBodyGroup.putBtn((int)BodyBtnGroup.BtBodyBtn.body0, GameObjectHolder.Btn_Body_bodyBtn[0].gameObject);
        btBodyGroup.putBtn((int)BodyBtnGroup.BtBodyBtn.body4, GameObjectHolder.Btn_Body_bodyBtn[4].gameObject);
        btBodyGroup.putBtn((int)BodyBtnGroup.BtBodyBtn.body, GameObjectHolder.Btn_Body_bodyMonitorBtn.gameObject);

        headGroup.hideGroup();
        upBodyGroup.hideGroup();
        btBodyGroup.hideGroup();
        lArmGroup.hideGroup();
        rArmGroup.hideGroup();
        lLegGroup.hideGroup();
        rLegGroup.hideGroup();

        headGroup.showMonitor();
        btBodyGroup.showMonitor();
        lArmGroup.showMonitor();
        rArmGroup.showMonitor();
        lLegGroup.showMonitor();
        rLegGroup.showMonitor();

    }

    public void processInput(Vector3 delta)
    {

        if (clickInfo.get().isPointChoosen())
        {
            //参考点被选中
            switch (clickInfo.get().getPartIndex())
            {
                case Part.Head:
                    moveBtnInGroup(btnGroup.Head, clickInfo.get().getPoinIndex(), delta * 20);
                    break;
                case Part.Body:        
                    break;
                case Part.LArm:
                    moveBtnInGroup(btnGroup.LArm, clickInfo.get().getPoinIndex(), delta * 10);
                    break;
                case Part.RArm:
                    moveBtnInGroup(btnGroup.RArm, clickInfo.get().getPoinIndex(), delta * 10);
                    break;
                case Part.LLeg:
                    moveBtnInGroup(btnGroup.LLeg, clickInfo.get().getPoinIndex(), delta * 20);
                    break;
                case Part.RLeg:
                    moveBtnInGroup(btnGroup.RLeg, clickInfo.get().getPoinIndex(), delta * 20);
                    break;
            }

        }
        else if (clickInfo.get().isJointChoosen())
        {
            // 单个关节被选中
            switch (clickInfo.get().getJointIndex())
            {
                case Joint.spine2:
                    moveGroup(btnGroup.Head, delta * 40);
                    moveGroup(btnGroup.UpBody, delta * 40);
                    moveGroup(btnGroup.LArm, delta * 40);
                    moveGroup(btnGroup.RArm, delta * 40);
                    break;
                case Joint.lForeArm:
                    break;
                case Joint.rForeArm:
                    break;
                case Joint.lUpLeg_lLeg:
                    break;
                case Joint.rUpLeg_rLeg:
                    break;
                case Joint.count:
                    break;
            }

        }
        else if (clickInfo.get().isPairChoosen())
        {
            //关节组被选中


            switch (clickInfo.get().getPair())
            {
                case JointPair.body_lLeg:
                    moveBtnInGroup(btnGroup.BtBody, (int)BodyBtnGroup.BtBodyBtn.body0,
                        delta);
                    delta.y = 0;
                    moveGroup(btnGroup.LLeg, delta * 20);
                    break;
                case JointPair.body_rLeg:
                    moveBtnInGroup(btnGroup.BtBody, (int)BodyBtnGroup.BtBodyBtn.body4,
                        delta);
                    delta.y = 0;
                    moveGroup(btnGroup.RLeg, delta * 20);
                    break;
                case JointPair.body_lArm:
                    delta.y = 0;
                    moveBtnInGroup(btnGroup.UpBody, (int)UpBodyBtnGroup.UpBodyBtn.body2,
                        delta);
                    moveGroup(btnGroup.LArm, delta * 25);
                    break;
                case JointPair.body_rArm:
                    delta.y = 0;
                    moveBtnInGroup(btnGroup.UpBody, (int)UpBodyBtnGroup.UpBodyBtn.body6,
                        delta);
                    moveGroup(btnGroup.RArm, delta * 25);
                    break;
            }

        }

    }

    public void showUI()
    {

        switch (clickInfo.get().getPartIndex())
        {
            case Part.Head:
                switchActiveGroup(btnGroup.Head);
                btnGroupHolder[(int)btnGroup.Head].hideMonitor();
                curGroup = (int)btnGroup.Head;
                break;
            case Part.Body:
                switchActiveGroup(btnGroup.UpBody);
                showBtnGroup(btnGroup.BtBody);
                btnGroupHolder[(int)btnGroup.BtBody].hideMonitor();
                curGroup = (int)btnGroup.BtBody;
                break;
            case Part.LArm:
                switchActiveGroup(btnGroup.LArm);
                btnGroupHolder[(int)btnGroup.LArm].hideMonitor();
                curGroup = (int)btnGroup.LArm;
                break;
            case Part.RArm:
                switchActiveGroup(btnGroup.RArm);
                btnGroupHolder[(int)btnGroup.RArm].hideMonitor();
                curGroup = (int)btnGroup.RArm;
                break;
            case Part.LLeg:
                switchActiveGroup(btnGroup.LLeg);
                btnGroupHolder[(int)btnGroup.LLeg].hideMonitor();
                curGroup = (int)btnGroup.LLeg;
                break;
            case Part.RLeg:
                switchActiveGroup(btnGroup.RLeg);
                btnGroupHolder[(int)btnGroup.RLeg].hideMonitor();
                curGroup = (int)btnGroup.RLeg;
                break;
        }

        if (curGroup != lastGroup)
        {
            btnGroupHolder[lastGroup].showMonitor();
        }

        lastGroup = curGroup;

    }

    public ClickInfo getClick()
    {
        return clickInfo.get();
    }

    public void moveGroup(btnGroup group, Vector3 delta)
    {
        btnGroupHolder[(int)group].move(delta);

        
    }

    public void moveBtnInGroup(btnGroup group, int index , Vector3 delta)
    {
        Vector3 modified = new Vector3(delta.x, delta.y, delta.z);
        switch (group)
        {
            case btnGroup.Head:
                break;
            case btnGroup.UpBody:
            case btnGroup.BtBody:
                modified.y = 0;
                modified = modified * 25f;              
                break;
            case btnGroup.LArm:
                break;
            case btnGroup.count:
                break;
        }
        btnGroupHolder[(int)group].moveBtnInGroup(index, modified);

    }

    public void hideBtnGroup(Part group)
    {
        btnGroupHolder[(int)group].hideGroup();
    }

    public void hideBtnGroup(int index)
    {
        btnGroupHolder[index].hideGroup();
    }

    public void showBtnGroup(btnGroup group)
    {
        if (clickInfo.get().isActive())
        btnGroupHolder[(int)group].showGroup();

    }

    public void switchActiveGroup(btnGroup group)
    {
        for (int i=0; i < (int)btnGroup.count; i++)
        {
            if ((int)group == i)
            {
                showBtnGroup(group);
            }
            else
            {
                hideBtnGroup(i);
            }
        }
    }

    IEnumerator LoadResources(float time)
    {
        yield return new WaitForSeconds(time);

        // 获得按钮的引用

        Transform Head = GameObjectHolder.Btn_Head.transform;
        Transform Body = GameObjectHolder.Btn_Body.transform;
        Transform LArm = GameObjectHolder.Btn_LArm.transform;
        Transform RArm = GameObjectHolder.Btn_RArm.transform;
        Transform LLeg = GameObjectHolder.Btn_LLeg.transform;
        Transform RLeg = GameObjectHolder.Btn_RLeg.transform;

        // 头部
        for (int i = 0; i < (int)HeadBtnGroup.HeadBtn.count; i++)
        {
            headGroup.putBtn(i, GameObjectHolder.Btn_Head_headBtn[i]);
        }
        headGroup.putBtn((int)HeadBtnGroup.HeadBtn.head, GameObjectHolder.Btn_Head_headMonitorBtn);

        // 左臂
        for (int i = 0; i < (int)LArmBtnGroup.LArmBtn.count; i++)
        {
            lArmGroup.putBtn(i, GameObjectHolder.Btn_LArm_lArmBtn[i]);
        }
        lArmGroup.putBtn((int)LArmBtnGroup.LArmBtn.lArm, GameObjectHolder.Btn_LArm_lArmMonitorBtn);

        // 右臂
        for (int i = 0; i < (int)RArmBtnGroup.RArmBtn.count; i++)
        {
            rArmGroup.putBtn(i, GameObjectHolder.Btn_RArm_rArmBtn[i]);
        }
        rArmGroup.putBtn((int)RArmBtnGroup.RArmBtn.rArm, GameObjectHolder.Btn_RArm_rArmMonitorBtn);

        // 左腿
        for (int i = 0; i < (int)LLegBtnGroup.LLegBtn.count; i++)
        {
            lLegGroup.putBtn(i, GameObjectHolder.Btn_LLeg_lLegBtn[i]);
        }
        lLegGroup.putBtn((int)LLegBtnGroup.LLegBtn.lLeg, GameObjectHolder.Btn_LLeg_lLegMonitorBtn);

        // 右腿
        for (int i = 0; i < (int)RLegBtnGroup.RLegBtn.count; i++)
        {
            rLegGroup.putBtn(i, GameObjectHolder.Btn_RLeg_rLegBtn[i]);
        }
        rLegGroup.putBtn((int)RLegBtnGroup.RLegBtn.rLeg, GameObjectHolder.Btn_RLeg_rLegMonitorBtn);


        // 上身
        upBodyGroup.putBtn((int)UpBodyBtnGroup.UpBodyBtn.body2, GameObjectHolder.Btn_Body_bodyBtn[2].gameObject);
        upBodyGroup.putBtn((int)UpBodyBtnGroup.UpBodyBtn.body6, GameObjectHolder.Btn_Body_bodyBtn[6].gameObject);
        upBodyGroup.putBtn((int)UpBodyBtnGroup.UpBodyBtn.spine2, GameObjectHolder.Btn_Body_spine2.gameObject);

        // 下身
        btBodyGroup.putBtn((int)BodyBtnGroup.BtBodyBtn.body0, GameObjectHolder.Btn_Body_bodyBtn[0].gameObject);
        btBodyGroup.putBtn((int)BodyBtnGroup.BtBodyBtn.body4, GameObjectHolder.Btn_Body_bodyBtn[4].gameObject);
        btBodyGroup.putBtn((int)BodyBtnGroup.BtBodyBtn.body, GameObjectHolder.Btn_Body_bodyMonitorBtn.gameObject);

        headGroup.hideGroup();
        upBodyGroup.hideGroup();
        btBodyGroup.hideGroup();
        lArmGroup.hideGroup();
        rArmGroup.hideGroup();
        lLegGroup.hideGroup();
        rLegGroup.hideGroup();

        headGroup.showMonitor();
        btBodyGroup.showMonitor();
        lArmGroup.showMonitor();
        rArmGroup.showMonitor();
        lLegGroup.showMonitor();
        rLegGroup.showMonitor();

        Debug.Log("Btn load complete");
    }
}

