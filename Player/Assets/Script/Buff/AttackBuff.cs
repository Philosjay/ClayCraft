using UnityEngine;
using UnityEditor;

public class AttackBuff : Buff
{
    public AttackBuff(int harm)
    {
        effectValue = harm;
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
        buffed.attack+= effectValue;
        return buffed;
    }

}
