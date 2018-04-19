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


    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {

        LoadSlotBuff();

  //    transform.Translate(0, 0.01, 0);

    }
    public void UpdateParts()
    {

    }

    public void Init()
    {
        // 初始化、连接身体部件
        PrepareBodyParts();

        // 通过部件buff初始化Player Status数值
        LoadSlotBuff();

        print("speed " + buffedStatus.speed);
        print("HP " + buffedStatus.HP);
        print("attack " + buffedStatus.attack);




    }
    public int Get()
    {
        return 0;
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

        headslot.ConnectPart(new Head());
        bodyslot.ConnectPart(new Body());
        larmslot.ConnectPart(new LeftArm());
        rarmslot.ConnectPart(new RightArm());
        llegslot.ConnectPart(new LeftLeg());
        rlegslot.ConnectPart(new RightLeg());
    }

    void LoadSlotBuff()
    {
        Buff buff = null;
        if (bodyslot.GetBuff() != null)
        {
            if (buff == null)
            {
                buff = bodyslot.GetBuff();
            }
            else
            {
                buff = bodyslot.GetBuff().AddBuff(buff);
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
                buff = llegslot.GetBuff().AddBuff(buff);
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
                buff = rlegslot.GetBuff().AddBuff(buff);
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
                buff = rarmslot.GetBuff().AddBuff(buff);
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
                buff = larmslot.GetBuff().AddBuff(buff);
            }

        }

        buffedStatus = buff.Effect(status);
    }
}
