using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySlot : BodypartSlot{

    public override Buff GetBuff()
    {

        if (connectedPart.GetClayValue() > 40)
        {
            SpeedBuff speed = new SpeedBuff(-30);
            speed.WrapBuff(new HPBuff(50));
            return speed;
        }
        else if(connectedPart.GetClayValue() > 30)
        {
            SpeedBuff speed = new SpeedBuff(-20);
            speed.WrapBuff(new HPBuff(30));
            return speed;
        }
        else if (connectedPart.GetClayValue() > 20)
        {
            SpeedBuff speed = new SpeedBuff(-10);
            speed.WrapBuff(new HPBuff(20));
            return speed;
        }
        else
        {
            SpeedBuff speed = new SpeedBuff(-5);
            speed.WrapBuff(new HPBuff(10));
            return speed;
        }
        
    }
}
