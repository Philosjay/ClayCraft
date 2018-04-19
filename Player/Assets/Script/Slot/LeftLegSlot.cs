using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLegSlot : BodypartSlot{
    private LeftLeg leftleg;

    public override Buff GetBuff()
    {
        return new SpeedBuff(+10);
    }

}
