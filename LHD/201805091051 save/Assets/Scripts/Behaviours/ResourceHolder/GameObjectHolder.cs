using UnityEngine;

public  class GameObjectHolder : MonoBehaviour
{
    public static GameObject playerModel;
    public static GameObject playerModel_hip;
    public static GameObject playerModel_spine2 ;
    public static GameObject playerModel_lLeg ;
    public static GameObject playerModel_rLeg;
    public static GameObject playerModel_lShoulder;
    public static GameObject playerModel_rShoulder;

    public static GameObject head ;
    public static GameObject body  ;
    public static GameObject lArm ;
    public static GameObject rArm ;
    public static GameObject lLeg ;
    public static GameObject rLeg ;

    public static GameObject playYard;

    // 按钮

    public static GameObject BtnForManipulator ;
    public static GameObject Btn_Head  ;
    public static GameObject Btn_Body  ;
    public static GameObject Btn_LArm  ;
    public static GameObject Btn_RArm  ;
    public static GameObject Btn_LLeg  ;
    public static GameObject Btn_RLeg  ;

    public static GameObject Btn_Head_headMonitorBtn;
    public static GameObject[] Btn_Head_headBtn;

    public static GameObject Btn_Body_bodyMonitorBtn;
    public static GameObject[] Btn_Body_bodyBtn;
    public static GameObject Btn_Body_spine2;

    public static GameObject Btn_LArm_lArmMonitorBtn;
    public static GameObject[] Btn_LArm_lArmBtn;

    public static GameObject Btn_RArm_rArmMonitorBtn;
    public static GameObject[] Btn_RArm_rArmBtn;

    public static GameObject Btn_LLeg_lLegMonitorBtn;
    public static GameObject[] Btn_LLeg_lLegBtn;

    public static GameObject Btn_RLeg_rLegMonitorBtn;
    public static GameObject[] Btn_RLeg_rLegBtn;

    static bool isLoadComplete = false;

    private void Start()
    {
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
        playerModel_hip = GameObject.FindGameObjectWithTag("Character1_Hips");
        playerModel_spine2 = GameObject.FindGameObjectWithTag("Character1_Spine2");
        playerModel_lLeg = GameObject.FindGameObjectWithTag("Character1_LeftUpLeg");
        playerModel_rLeg = GameObject.FindGameObjectWithTag("Character1_RightUpLeg");
        playerModel_lShoulder = GameObject.FindGameObjectWithTag("Character1_LeftShoulder");
        playerModel_rShoulder = GameObject.FindGameObjectWithTag("Character1_RightShoulder");

        head = GameObject.FindGameObjectWithTag("Head");
        Debug.Log(head.name);
        body = GameObject.FindGameObjectWithTag("Body");
        lArm = GameObject.FindGameObjectWithTag("LArm");
        rArm = GameObject.FindGameObjectWithTag("RArm");
        lLeg = GameObject.FindGameObjectWithTag("LLeg");
        rLeg = GameObject.FindGameObjectWithTag("RLeg");


        //playYard = GameObject.Find("/PlayYard");

        BtnForManipulator = GameObject.FindGameObjectWithTag("BtnForManipulator");
        Btn_Head = GameObject.FindGameObjectWithTag("HeadBtn");
        Btn_Body = GameObject.FindGameObjectWithTag("BodyBtn");
        Btn_LArm = GameObject.FindGameObjectWithTag("LArmBtn");
        Btn_RArm = GameObject.FindGameObjectWithTag("RArmBtn");
        Btn_LLeg = GameObject.FindGameObjectWithTag("LLegBtn");
        Btn_RLeg = GameObject.FindGameObjectWithTag("RLegBtn");



        // 头部
        Btn_Head_headMonitorBtn = Btn_Head.transform.Find("headBtn").gameObject;
        Btn_Head_headBtn = new GameObject[(int)HeadBtnGroup.HeadBtn.count];
        for (int i = 0; i < 8; i++)
        {
            Btn_Head_headBtn[i] = Btn_Head.transform.Find("head" + i + "Btn").gameObject;
        }


        // 身体
        Btn_Body_bodyMonitorBtn = Btn_Body.transform.Find("bodyBtn").gameObject;
        Btn_Body_bodyBtn = new GameObject[(int)BodyBtnGroup.BtBodyBtn.count];
        for (int i = 0; i < (int)BodyBtnGroup.BtBodyBtn.count; i++)
        {
            Transform btn = Btn_Body.transform.Find("body" + i + "Btn");
            if (btn != null)
            {
                Btn_Body_bodyBtn[i] = btn.gameObject;
            }

        }
        Btn_Body_spine2 = Btn_Body.transform.transform.Find("spine2Btn").gameObject;

        // 左臂
        Btn_LArm_lArmMonitorBtn = Btn_LArm.transform.Find("lArmBtn").gameObject;
        Btn_LArm_lArmBtn = new GameObject[(int)LArmBtnGroup.LArmBtn.count];
        for (int i = 0; i < (int)LArmBtnGroup.LArmBtn.count; i++)
        {
            Transform btn = Btn_LArm.transform.Find("lArm" + i + "Btn");
            if (btn != null)
            {
                Btn_LArm_lArmBtn[i] = btn.gameObject;
            }

        }

        // 右臂
        Btn_RArm_rArmMonitorBtn = Btn_RArm.transform.Find("rArmBtn").gameObject;
        Btn_RArm_rArmBtn = new GameObject[(int)RArmBtnGroup.RArmBtn.count];
        for (int i = 0; i < (int)RArmBtnGroup.RArmBtn.count; i++)
        {
            Transform btn = Btn_RArm.transform.Find("rArm" + i + "Btn");
            if (btn != null)
            {
                Btn_RArm_rArmBtn[i] = btn.gameObject;
            }

        }

        // 左腿
        Btn_LLeg_lLegBtn = new GameObject[(int)LLegBtnGroup.LLegBtn.count];
        Btn_LLeg_lLegMonitorBtn = Btn_LLeg.transform.Find("lLegBtn").gameObject;
        for (int i = 0; i < (int)LLegBtnGroup.LLegBtn.count; i++)
        {
            Transform btn = Btn_LLeg.transform.Find("lLeg" + i + "Btn");
            if (btn != null)
            {
                Btn_LLeg_lLegBtn[i] = btn.gameObject;
            }
        }

        // 右腿
        Btn_RLeg_rLegBtn = new GameObject[(int)RLegBtnGroup.RLegBtn.count];
        Btn_RLeg_rLegMonitorBtn = Btn_RLeg.transform.Find("rLegBtn").gameObject;
        for (int i = 0; i < (int)RLegBtnGroup.RLegBtn.count; i++)
        {
            Transform btn = Btn_RLeg.transform.Find("rLeg" + i + "Btn");
            if (btn != null)
            {
                Btn_RLeg_rLegBtn[i] = btn.gameObject;
            }
        }


        isLoadComplete = true;

    }


    static public bool isComplete()
    {
        return isLoadComplete;
    }

}
