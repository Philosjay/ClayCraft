using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSlot : BodypartSlot {

    public override Buff GetBuff()
    {
        if (connectedPart.GetClayValue() > 2)
        {
            return new HPBuff(+15);
        }
        else if(connectedPart.GetClayValue() > 1)
        {
            return new HPBuff(+10);
        }

        else
        {
            return new HPBuff(+5);
        }

    }
}
