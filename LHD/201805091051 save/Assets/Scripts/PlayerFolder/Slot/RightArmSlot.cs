using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmSlot : BodypartSlot{

    public override Buff GetBuff()
    {
        if (connectedPart.GetClayValue() > 10)
        {
            return new AttackBuff(+20);
        }
        else
        {
            return new AttackBuff(+10);
        }
    }

}
