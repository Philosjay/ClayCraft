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
            // 递归最里层创建一个同status 的实例
            buffed = new PlayerStatus(status);
        }
        buffed.HP += effectValue;
        return buffed;
    }
}