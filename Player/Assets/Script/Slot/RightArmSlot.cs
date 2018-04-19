using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmSlot : BodypartSlot{
    private RightArm rightarm;

    public override Buff GetBuff()
    {
        return new AttackBuff(+20);
    }

}
