using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodypart : MonoBehaviour {
    protected int MAXCLAY;

    protected int currentClay;

    public int GetClayValue()
    {
        return currentClay;
    }

    public void ChangeClayValue(int delta)
    {
    }

}
