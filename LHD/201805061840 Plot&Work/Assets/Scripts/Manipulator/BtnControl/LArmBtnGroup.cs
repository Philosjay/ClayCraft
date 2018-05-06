
class LArmBtnGroup : BtnGroup
{
    public enum LArmBtn
    {
        lArm0,
        lArm1,
        lArm2,
        lArm3,
        lArm4,
        lArm5,
        lArm6,
        lArm7,
        lArm,

        count,
    }

    public override void hideGroup()
    {
        for (int i = 0; i < btnGroupHolder.Length; i++)
        {
            if (btnGroupHolder[i] != null)
            {
                if (i != (int)LArmBtn.lArm) btnGroupHolder[i].SetActive(false);
            }
            
        }
    }

    public LArmBtnGroup()
    {
        btnGroupHolder = new UnityEngine.GameObject[(int)LArmBtn.count];
    }
    public override void showMonitor()
    {
        btnGroupHolder[(int)LArmBtn.lArm].SetActive(true);
    }

    public override void hideMonitor()
    {
        btnGroupHolder[(int)LArmBtn.lArm].SetActive(false);
    }
}
