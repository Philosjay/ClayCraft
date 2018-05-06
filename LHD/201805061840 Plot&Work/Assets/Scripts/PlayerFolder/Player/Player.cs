using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private PlayerStatus status;
    private PlayerStatus buffedStatus;

    private Dictionary<string, BodypartSlot> partslot;
    private List<Skill> activeSkill;

    private HeadSlot headslot;
    private BodySlot bodyslot;
    private LeftArmSlot larmslot;
    private RightArmSlot rarmslot;
    private LeftLegSlot llegslot;
    private RightLegSlot rlegslot;

    private List<Action> actions;




    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        // 通过部件buff更新Player Status数值
        LoadSlotBuff();

    }
    public void UpdateParts()
    {
    }


    public void Init()
    {
        // 初始化、连接身体部件
        PrepareBodyParts();




 //       gameObject.AddComponent<Sensor>();

        // 注册可用Action
        //gameObject.AddComponent<MoveLeft>();
        //gameObject.AddComponent<MoveRight>();
        //gameObject.AddComponent<MoveForward>();
        //gameObject.AddComponent<MoveBackward>();
        gameObject.AddComponent<Punch>();
        gameObject.AddComponent<Roll>();
        gameObject.AddComponent<Boost>();
        gameObject.AddComponent<Flash>();
        gameObject.AddComponent<Dodge>();
        gameObject.AddComponent<PickUp>();
        

        // 通过部件buff初始化Player Status数值
        LoadSlotBuff();

        print("speed " + buffedStatus.speed);
        print("HP " + buffedStatus.HP);
        print("attack " + buffedStatus.attack);
    }

    private void OnDestroy()
    {
        Destroy(gameObject.GetComponent<SensorHolder>());
        
    }

    void PrepareBodyParts()
    {
        status = new PlayerStatus();

        headslot = new HeadSlot();
        bodyslot = new BodySlot();
        larmslot = new LeftArmSlot();
        rarmslot = new RightArmSlot();
        llegslot = new LeftLegSlot();
        rlegslot = new RightLegSlot();

        partslot = new Dictionary<string, BodypartSlot> {
            { "head", headslot },
            { "body", bodyslot },
            { "leftarm", larmslot },
            { "rightarm", rarmslot },
            { "leftleg", llegslot },
            { "rightleg", rlegslot } };


        //int headClay = (int)GameObjectHolder.head.GetComponent<Block>().GetBlockSize() * 10;
        //int bodyClay = (int)GameObjectHolder.body.GetComponent<Block>().GetBlockSize() * 10;
        //int lArmClay = (int)GameObjectHolder.lArm.GetComponent<Block>().GetBlockSize() * 10;
        //int rArmClay = (int)GameObjectHolder.rArm.GetComponent<Block>().GetBlockSize() * 10;
        //int lLegClay = (int)GameObjectHolder.lLeg.GetComponent<Block>().GetBlockSize() * 10;
        //int rLegClay = (int)GameObjectHolder.rLeg.GetComponent<Block>().GetBlockSize() * 10;



        //headslot.ConnectPart(new Head(headClay));
        //bodyslot.ConnectPart(new Body(bodyClay));
        //larmslot.ConnectPart(new LeftArm(lArmClay));
        //rarmslot.ConnectPart(new RightArm(rArmClay));
        //llegslot.ConnectPart(new LeftLeg(lLegClay));
        //rlegslot.ConnectPart(new RightLeg(rLegClay));

        //Debug.Log("head" + headClay);
        //Debug.Log("body" + bodyClay);
        //Debug.Log("lArm" + lArmClay);
        //Debug.Log("rArm" + rArmClay);
        //Debug.Log("lLeg" + lLegClay);
        //Debug.Log("rLeg" + rLegClay);

        StartCoroutine(WaitAndGet(1.0f));

    }

    public void damageHead()
    {
        bodyslot.DamagePart(1);
    }

    void LoadSlotBuff()
    {
        Buff buff = null;
        
        if (headslot.GetBuff() != null)
        {
            if (buff == null)
            {
                buff = headslot.GetBuff();
            }
            else
            {
                headslot.GetBuff().WrapBuff(buff);
            }

        }
        
        if (bodyslot.GetBuff() != null)
        {
            if (buff == null)
            {
                buff = bodyslot.GetBuff();
            }
            else
            {
                buff.WrapBuff(bodyslot.GetBuff());
            }

        }
        if (llegslot.GetBuff() != null)
        {
            if (buff == null)
            {
                buff = llegslot.GetBuff();
            }
            else
            {
                buff.WrapBuff(llegslot.GetBuff());
            }

        }
        if (rlegslot.GetBuff() != null)
        {
            if (buff == null)
            {
                buff = rlegslot.GetBuff();
            }
            else
            {
                buff.WrapBuff(rlegslot.GetBuff());
            }

        }
        if (rarmslot.GetBuff() != null)
        {
            if (buff == null)
            {
                buff = rarmslot.GetBuff();
            }
            else
            {
                buff.WrapBuff(rarmslot.GetBuff());
            }

        }
        if (larmslot.GetBuff() != null)
        {
            if (buff == null)
            {
                buff = larmslot.GetBuff();
            }
            else
            {
                buff.WrapBuff(larmslot.GetBuff());
            }

        }

        buffedStatus = buff.Effect(status);
    }

    public PlayerStatus GetPlayerBuffedStatus()
    {
        return buffedStatus;
    }
    public PlayerStatus GetPlayerStatus()
    {
        return status;
    }
    public void SetPlayerStatus(PlayerStatus newStauts)
    {
        status = newStauts;
    }

    public void removeAllAction()
    {
        //Destroy(gameObject.GetComponent<MoveLeft>());
        //Destroy(gameObject.GetComponent<MoveRight>());
        //Destroy(gameObject.GetComponent<MoveForward>());
        //Destroy(gameObject.GetComponent<MoveBackward>());
        Destroy(gameObject.GetComponent<Punch>());
        Destroy(gameObject.GetComponent<Roll>());
        Destroy(gameObject.GetComponent<Boost>());
        Destroy(gameObject.GetComponent<Flash>());
        Destroy(gameObject.GetComponent<Dodge>());
        Destroy(gameObject.GetComponent<PickUp>());
    }

    IEnumerator WaitAndGet(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        int headClay = (int)GameObjectHolder.head.GetComponent<Block>().GetBlockSize() * 10;
        int bodyClay = (int)GameObjectHolder.body.GetComponent<Block>().GetBlockSize() * 10;
        int lArmClay = (int)GameObjectHolder.lArm.GetComponent<Block>().GetBlockSize() * 10;
        int rArmClay = (int)GameObjectHolder.rArm.GetComponent<Block>().GetBlockSize() * 10;
        int lLegClay = (int)GameObjectHolder.lLeg.GetComponent<Block>().GetBlockSize() * 10;
        int rLegClay = (int)GameObjectHolder.rLeg.GetComponent<Block>().GetBlockSize() * 10;



        headslot.ConnectPart(new Head(headClay));
        bodyslot.ConnectPart(new Body(bodyClay));
        larmslot.ConnectPart(new LeftArm(lArmClay));
        rarmslot.ConnectPart(new RightArm(rArmClay));
        llegslot.ConnectPart(new LeftLeg(lLegClay));
        rlegslot.ConnectPart(new RightLeg(rLegClay));

        Debug.Log("head" + headClay);
        Debug.Log("body" + bodyClay);
        Debug.Log("lArm" + lArmClay);
        Debug.Log("rArm" + rArmClay);
        Debug.Log("lLeg" + lLegClay);
        Debug.Log("rLeg" + rLegClay);

    }

}
