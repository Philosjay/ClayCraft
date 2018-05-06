using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickResponsor : MonoBehaviour{

    ClickInfoHolder info;

    // Use this for initialization
    void Start () {
        info = new ClickInfoHolder();
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void OnHeadClick()
    {
        info.get().SetPart(UIBtnManager.Part.Head);
        info.get().setActivate();
    }

    public void OnHead0Click()
    {      
        info.get().setPoint(0);
    }
    public void OnHead1Click()
    {
        info.get().setPoint(1);
    }
    public void OnHead2Click()
    {
        info.get().setPoint(2);
    }
    public void OnHead3Click()
    {
        info.get().setPoint(3);
    }
    public void OnHead4Click()
    {
        info.get().setPoint(4);
    }
    public void OnHead5Click()
    {
        info.get().setPoint(5);
    }
    public void OnHead6Click()
    {
        info.get().setPoint(6);
    }
    public void OnHead7Click()
    {
        info.get().setPoint(7);
    }


    public void OnBodyClick()
    {
        info.get().SetPart(UIBtnManager.Part.Body);
        info.get().setActivate();
    }
    public void OnBody0Click()
    {
        info.get().SetPair(UIBtnManager.JointPair.body_lLeg);
    }
    public void OnBody1Click()
    {
        info.get().setPoint(1);
    }
    public void OnBody2Click()
    {
        info.get().SetPair(UIBtnManager.JointPair.body_lArm);
    }
    public void OnBody3Click()
    {
        info.get().setPoint(3);
    }
    public void OnBody4Click()
    {
        info.get().SetPair(UIBtnManager.JointPair.body_rLeg);
    }
    public void OnBody5Click()
    {
        info.get().setPoint(5);
    }
    public void OnBody6Click()
    {
        info.get().SetPair(UIBtnManager.JointPair.body_rArm);
    }
    public void OnBody7Click()
    {
        info.get().setPoint(7);
    }


    public void OnLArmClick()
    {
        info.get().SetPart(UIBtnManager.Part.LArm);
        info.get().setActivate();
    }
    public void OnLArm0Click()
    {
        info.get().setPoint(0);
    }
    public void OnLArm1Click()
    {
        info.get().setPoint(1);
    }
    public void OnLArm2Click()
    {
        info.get().setPoint(2);
    }
    public void OnLArm3Click()
    {
        info.get().setPoint(3);
    }
    public void OnLArm4Click()
    {
        info.get().setPoint(4);
    }
    public void OnLArm5Click()
    {
        info.get().setPoint(5);
    }
    public void OnLArm6Click()
    {
        info.get().setPoint(6);
    }
    public void OnLArm7Click()
    {
        info.get().setPoint(7);
    }


    public void OnRArmClick()
    {
        info.get().SetPart(UIBtnManager.Part.RArm);
        info.get().setActivate();
    }
    public void OnRArm0Click()
    {
        info.get().setPoint(0);
    }
    public void OnRArm1Click()
    {
        info.get().setPoint(1);
    }
    public void OnRArm2Click()
    {
        info.get().setPoint(2);
    }
    public void OnRArm3Click()
    {
        info.get().setPoint(3);
    }
    public void OnRArm4Click()
    {
        info.get().setPoint(4);
    }
    public void OnRArm5Click()
    {
        info.get().setPoint(5);
    }
    public void OnRArm6Click()
    {
        info.get().setPoint(6);
    }
    public void OnRArm7Click()
    {
        info.get().setPoint(7);
    }

    public void OnLLegClick()
    {
        info.get().SetPart(UIBtnManager.Part.LLeg);
        info.get().setActivate();
    }
    public void OnLLeg0Click()
    {
        info.get().setPoint(0);
    }
    public void OnLLeg1Click()
    {
        info.get().setPoint(1);
    }
    public void OnLLeg2Click()
    {
        info.get().setPoint(2);
    }
    public void OnLLeg3Click()
    {
        info.get().setPoint(3);
    }
    public void OnLLeg4Click()
    {
        info.get().setPoint(4);
    }
    public void OnLLeg5Click()
    {
        info.get().setPoint(5);
    }
    public void OnLLeg6Click()
    {
        info.get().setPoint(6);
    }
    public void OnLLeg7Click()
    {
        info.get().setPoint(7);
    }


    public void OnRLegClick()
    {
        info.get().SetPart(UIBtnManager.Part.RLeg);
        info.get().setActivate();
    }
    public void OnRLeg0Click()
    {
        info.get().setPoint(0);
    }
    public void OnRLeg1Click()
    {
        info.get().setPoint(1);
    }
    public void OnRLeg2Click()
    {
        info.get().setPoint(2);
    }
    public void OnRLeg3Click()
    {
        info.get().setPoint(3);
    }
    public void OnRLeg4Click()
    {
        info.get().setPoint(4);
    }
    public void OnRLeg5Click()
    {
        info.get().setPoint(5);
    }
    public void OnRLeg6Click()
    {
        info.get().setPoint(6);
    }
    public void OnRLeg7Click()
    {
        info.get().setPoint(7);
    }




    public void OnJointSpine2Click()
    {
        info.get().setJoint(UIBtnManager.Joint.spine2);
    }
    public void OnJointSpineClick()
    {

    }
}
