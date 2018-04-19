using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLegSlot : BodypartSlot{
    private RightLeg rightleg;

    public override Buff GetBuff()
    {
        return new SpeedBuff(+10);
    }
}
