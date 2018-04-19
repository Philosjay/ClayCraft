using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySlot : BodypartSlot{
    private Body body;

    public override Buff GetBuff()
    {
        Buff health = new HPBuff(150);
        return new SpeedBuff(-10,health);
    }
}
