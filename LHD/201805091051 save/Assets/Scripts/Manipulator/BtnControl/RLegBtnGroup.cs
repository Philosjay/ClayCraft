
class RLegBtnGroup : BtnGroup
{
    public enum RLegBtn
    {

        rLeg0,
        rLeg1,
        rLeg2,
        rLeg3,
        rLeg4,
        rLeg5,
        rLeg6,
        rLeg7,
        rLeg,

        count,
    }

    public override void hideGroup()
    {
        for (int i = 0; i < btnGroupHolder.Length; i++)
        {
            if (btnGroupHolder[i] != null)
            {
                if (i != (int)RLegBtn.rLeg) btnGroupHolder[i].SetActive(false);
            }

        }
    }

    public RLegBtnGroup()
    {
        btnGroupHolder = new UnityEngine.GameObject[(int)RLegBtn.count];
    }
    public override void showMonitor()
    {
        btnGroupHolder[(int)RLegBtn.rLeg].SetActive(true);
    }

    public override void hideMonitor()
    {
        btnGroupHolder[(int)RLegBtn.rLeg].SetActive(false);
    }
}
