using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodypartSlot : MonoBehaviour {
    private Bodypart connectedPart;
	
    public void ConnectPart(Bodypart bodypart)
    {
        connectedPart = bodypart;
    }

    public void DropPart()
    {

    }

    public void DamagePart(int damage)
    {
    }

    public int GetPartClay()
    {
        return 0;
    }

    virtual public Buff GetBuff()
    {
        return null;
    }

    public Skill GetSkill()
    {
        return null;
    }
}
