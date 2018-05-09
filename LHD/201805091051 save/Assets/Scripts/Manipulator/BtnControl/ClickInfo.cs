using System;

public class ClickInfo
{
    bool isInPoint = false;
    bool isInJoint = false;
    bool isInPair = false;
    bool isActivate = false;

    int pointIndex;


    UIBtnManager.Part curPart = UIBtnManager.Part.count;


    UIBtnManager.JointPair pair;
    UIBtnManager.Joint curjoint = 0;


    public void SetPair(UIBtnManager.JointPair pair)
    {
        this.pair = pair;

        isInJoint = false;
        isInPoint = false;
        isInPair = true;
    }
    public UIBtnManager.JointPair getPair()
    {
        return pair;
    }


    public void SetPart(UIBtnManager.Part part)
    {
        curPart = part;

    }

    public void setPoint(int n)
    {
        pointIndex = n;

        isInJoint = false;
        isInPoint = true;
        isInPair = false;
    }

    public void setJoint(UIBtnManager.Joint n)
    {
        curjoint = n;

        isInJoint = true;
        isInPoint = false;
        isInPair = false;
    }

    public int getPoinIndex()
    {
        return pointIndex;
    }
    public UIBtnManager.Part getPartIndex()
    {
        return curPart;
    }

    public UIBtnManager.Joint getJointIndex()
    {
        return curjoint;
    }

    public bool isPointChoosen()
    {
        return isInPoint;
    }

    public bool isJointChoosen()
    {
        return isInJoint;
    }

    public bool isPairChoosen()
    {
        return isInPair;
    }

    public void setActivate()
    {
        isActivate = true;
    }

    public bool isActive()
    {
        return isActivate;
    }
}
