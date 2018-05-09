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
            // 递归最里层创建一个同status 的实例
            buffed = new PlayerStatus(status);
        }
        buffed.attack+= effectValue;
        return buffed;
    }

}
