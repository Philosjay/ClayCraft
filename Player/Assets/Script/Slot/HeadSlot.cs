using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSlot : BodypartSlot {
    private Head head;

    public override Buff GetBuff()
    {
        if(head.GetClayValue() > 80)
            return new HPBuff(+15);
        else if(head.GetClayValue() > 50)
            return new HPBuff(+10);
        else
            return new HPBuff(+5);

    }
}
