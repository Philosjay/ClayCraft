using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmSlot : BodypartSlot{
    private LeftArm leftarm;

    public override Buff GetBuff()
    {
        return new AttackBuff(+20);
    }

}
