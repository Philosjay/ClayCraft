 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff {
    // Buff使用 装饰者模式 实现多Buff的叠加

    protected int effectValue = 0;
    protected Buff otherBuff = null;
    public virtual PlayerStatus Effect(PlayerStatus status)
    {
        return new PlayerStatus();
    }

    public Buff AddBuff(Buff other)
    {
        this.otherBuff = other;
        return this;
    }
   
}
