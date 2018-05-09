
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Manipulator : MonoBehaviour
{

    //射线检测用
    //public Camera ca;

    public GameObject mainCamera;

    public Block body;
    public Block head;
    public Block lLeg;
    public Block rLeg;
    public Block lArm;
    public Block rArm;


    UIBtnManager uiMng;

    //拖拽用
    bool isComplete = false;
    bool isGrabbing = false;
    Block[] blockHolder = new Block[8];

    
    GameObject[] jointHolder;
    JointPairHolder[] jointPairHolder;

    int curBlockIndex ;

    // Use this for initialization
    void Start() {

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        head = GameObject.FindGameObjectWithTag("Head").GetComponent<Block>();
        body = GameObject.FindGameObjectWithTag("Body").GetComponent<Block>();
        lArm = GameObject.FindGameObjectWithTag("LArm").GetComponent<Block>();
        rArm = GameObject.FindGameObjectWithTag("RArm").GetComponent<Block>();
        lLeg = GameObject.FindGameObjectWithTag("LLeg").GetComponent<Block>();
        rLeg = GameObject.FindGameObjectWithTag("RLeg").GetComponent<Block>();

        StartCoroutine(LoadResources(1f));


        isComplete = false;
        isGrabbing = false;
        blockHolder = new Block[6];
        curBlockIndex = 0;

        jointPairHolder = new JointPairHolder[(int)UIBtnManager.JointPair.count];
        jointHolder = new GameObject[(int)UIBtnManager.Joint.count];

        gameObject.AddComponent<UIBtnManager>();
        uiMng = (UIBtnManager)gameObject.GetComponent<UIBtnManager>();

        print("start mani");
        blockHolder[0] = head;
        blockHolder[1] = body;
        blockHolder[2] = lArm;
        blockHolder[3] = rArm;
        blockHolder[4] = lLeg;
        blockHolder[5] = rLeg;


        jointPairHolder[(int)UIBtnManager.JointPair.body_lLeg] = new JointPairHolder();
        jointPairHolder[(int)UIBtnManager.JointPair.body_lLeg].SetPair(GameObjectHolder.playerModel_lLeg, body, 0);
        jointPairHolder[(int)UIBtnManager.JointPair.body_rLeg] = new JointPairHolder();
        jointPairHolder[(int)UIBtnManager.JointPair.body_rLeg].SetPair(GameObjectHolder.playerModel_rLeg, body, 4);
        jointPairHolder[(int)UIBtnManager.JointPair.body_lArm] = new JointPairHolder();
        jointPairHolder[(int)UIBtnManager.JointPair.body_lArm].SetPair(GameObjectHolder.playerModel_lShoulder, body, new int[2] { 2, 3 });
        jointPairHolder[(int)UIBtnManager.JointPair.body_rArm] = new JointPairHolder();
        jointPairHolder[(int)UIBtnManager.JointPair.body_rArm].SetPair(GameObjectHolder.playerModel_rShoulder, body, new int[2] { 6, 7 });

        Debug.Log("Maniplt load complete");
    }


    // Update is called once per frame
    void Update() {
        //Debug.Log(mainCamera.name);

        // 鼠标右键选择block
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
        curBlockIndex = GetBlockIndex();
        SetMarkerIndex(curBlockIndex);

        uiMng.showUI();
        
        // 开启/关闭拖拽模式
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isGrabbing = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isGrabbing = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
        }

        // 不在拖拽模式则尝试选中marker
        if (!isGrabbing)
        {
            
        }
        else
        {
          
            // 在拖拽模式进行拖拽
            var x = Input.GetAxis("Mouse X") * 20 * Time.deltaTime;
            var y = Input.GetAxis("Mouse Y") * 20 * Time.deltaTime;
            var z = Input.GetAxis("Mouse ScrollWheel") * 2f;

            Vector3 delta = new Vector3(x, y, z);

            uiMng.processInput(delta);
            
            if (uiMng.getClick().isPointChoosen())
            {
                if (mainCamera.transform.position.z < 0)
                {
                    x = -x;
                    z = -z;
                }
                // 改变参考点位置
                blockHolder[curBlockIndex].Drag(x, y, z);


            }
            else if (uiMng.getClick().isJointChoosen())
            {
                // 单个关节被选中
                jointHolder[(int)uiMng.getClick().getJointIndex()].transform.position += new Vector3(x, y, z)*0.4f;
                
            }else if (uiMng.getClick().isPairChoosen())
            {
                //关节组被选中
                switch (uiMng.getClick().getPair())
                {
                    case UIBtnManager.JointPair.body_lLeg:
                    case UIBtnManager.JointPair.body_rLeg:
                        jointPairHolder[(int)uiMng.getClick().getPair()].moveJoint1(new Vector3(x * 0.25f, 0, z * 0.3f));
                        if (mainCamera.transform.position.z < 0)
                        {
                            x = -x;
                            z = -z;
                        }
                        jointPairHolder[(int)uiMng.getClick().getPair()].moveJoint2(new Vector3(x, 0, z));
                        break;
                    case UIBtnManager.JointPair.body_lArm:
                    case UIBtnManager.JointPair.body_rArm:
                        jointPairHolder[(int)uiMng.getClick().getPair()].moveJoint1(new Vector3(x * 0.35f, 0, z * 0.3f));
                        if (mainCamera.transform.position.z < 0)
                        {
                            x = -x;
                            z = -z;
                        }
                        jointPairHolder[(int)uiMng.getClick().getPair()].moveJoint2(new Vector3(x*0.9f, 0, z));
                        break;
                    case UIBtnManager.JointPair.count:
                        break;
                }


            }
        }

    }

    public void SetBlockIndex(int n)
    {
        curBlockIndex = n;
    }

    int GetBlockIndex()
    {
        return (int)uiMng.getClick().getPartIndex(); ;
    }

    void  SetMarkerIndex(int blockIndex)
    {
        if (uiMng.getClick().isActive())
            blockHolder[blockIndex].SetCurMarkerIndex(uiMng.getClick().getPoinIndex());
    }

    Vector3 ModifyCameraPosition(Vector3 obj)
    {
        return new Vector3(obj.x + mainCamera.transform.position.x, obj.y - mainCamera.transform.position.y, obj.z + mainCamera.transform.position.z);
    }

    public bool IsComplet()
    {
        return isComplete;
    }

    public GameObject getHead()
    {
        return head.gameObject;
    }

    IEnumerator LoadResources(float time)
    {
        yield return new WaitForSeconds(time);

        //获得关节的引用
        Transform hip = GameObjectHolder.playerModel_hip.transform;
        Transform spine2 = GameObjectHolder.playerModel_spine2.transform;

        jointHolder[(int)UIBtnManager.Joint.spine2] = spine2.gameObject;

        jointPairHolder[(int)UIBtnManager.JointPair.body_lLeg] = new JointPairHolder();
        jointPairHolder[(int)UIBtnManager.JointPair.body_lLeg].SetPair(GameObjectHolder.playerModel_lLeg, body, 0);
        jointPairHolder[(int)UIBtnManager.JointPair.body_rLeg] = new JointPairHolder();
        jointPairHolder[(int)UIBtnManager.JointPair.body_rLeg].SetPair(GameObjectHolder.playerModel_rLeg, body, 4);
        jointPairHolder[(int)UIBtnManager.JointPair.body_lArm] = new JointPairHolder();
        jointPairHolder[(int)UIBtnManager.JointPair.body_lArm].SetPair(GameObjectHolder.playerModel_lShoulder, body, new int[2] { 2, 3 });
        jointPairHolder[(int)UIBtnManager.JointPair.body_rArm] = new JointPairHolder();
        jointPairHolder[(int)UIBtnManager.JointPair.body_rArm].SetPair(GameObjectHolder.playerModel_rShoulder, body, new int[2] { 6, 7 });

        Debug.Log("Maniplt load complete");
    }

    public IEnumerator LoadWorkCamera(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        mainCamera = GameObject.FindGameObjectWithTag("WorkCamera");

    }

}
