using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodypart  {
    protected int MAXCLAY;

    protected int currentClay;

    public int GetClayValue()
    {
        return currentClay;
    }

    public void SetClayValue(int val)
    {
        currentClay = val;
    }

    public void ChangeClayValue(int delta)
    {
        currentClay += delta;
    }

}
