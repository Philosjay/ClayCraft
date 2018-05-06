
class LLegBtnGroup : BtnGroup
{
    public enum LLegBtn
    {

        lLeg0,
        lLeg1,
        lLeg2,
        lLeg3,
        lLeg4,
        lLeg5,
        lLeg6,
        lLeg7,
        lLeg,

        count,
    }

    public override void hideGroup()
    {
        for (int i = 0; i < btnGroupHolder.Length; i++)
        {
            if (btnGroupHolder[i] != null)
            {
                if (i != (int)LLegBtn.lLeg) btnGroupHolder[i].SetActive(false);
            }

        }
    }

    public LLegBtnGroup()
    {
        btnGroupHolder = new UnityEngine.GameObject[(int)LLegBtn.count];
    }
    public override void showMonitor()
    {
        btnGroupHolder[(int)LLegBtn.lLeg].SetActive(true);
    }

    public override void hideMonitor()
    {
        btnGroupHolder[(int)LLegBtn.lLeg].SetActive(false);
    }
}
