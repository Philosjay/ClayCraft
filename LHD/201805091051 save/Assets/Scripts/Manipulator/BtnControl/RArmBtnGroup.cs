
class RArmBtnGroup : BtnGroup
{
    public enum RArmBtn
    {

        rArm0,
        rArm1,
        rArm2,
        rArm3,
        rArm4,
        rArm5,
        rArm6,
        rArm7,
        rArm,

        count,
    }

    public override void hideGroup()
    {
        for (int i = 0; i < btnGroupHolder.Length; i++)
        {
            if (btnGroupHolder[i] != null)
            {
                if (i != (int)RArmBtn.rArm) btnGroupHolder[i].SetActive(false);
            }
            
        }
    }

    public RArmBtnGroup()
    {
        btnGroupHolder = new UnityEngine.GameObject[(int)RArmBtn.count];
    }
    public override void showMonitor()
    {
        btnGroupHolder[(int)RArmBtn.rArm].SetActive(true);
    }

    public override void hideMonitor()
    {
        btnGroupHolder[(int)RArmBtn.rArm].SetActive(false);
    }
}

