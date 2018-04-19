using UnityEngine;
using UnityEditor;

public class HPBuff : Buff
{

    public HPBuff(int health)
    {
        effectValue = health;
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
        buffed.HP += effectValue;
        return buffed;
    }
}