using UnityEngine;
using UnityEditor;

public class SpeedBuff : Buff
{
    public SpeedBuff(int speed, Buff other=null)
    {
        otherBuff = other;
        effectValue = speed;
    }
    
    public override PlayerStatus Effect(PlayerStatus status)
    {
        PlayerStatus buffed;
        if (otherBuff != null)
        {
            buffed = otherBuff.Effect(status);
        }
        else
        {
            buffed = new PlayerStatus();
        }
        buffed.speed += effectValue;
        return buffed;
    }

}