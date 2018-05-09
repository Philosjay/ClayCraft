
class BodyBtnGroup : BtnGroup
{
    public enum BtBodyBtn
    {
        body0,
        body1,
        body2,
        body3,
        body4,
        body5,
        body6,
        body7,
        body,

        count,
    }

    public override void hideGroup()
    {
        for (int i = 0; i < btnGroupHolder.Length; i++)
        {
            if (btnGroupHolder[i] != null)
            {
                if (i!=(int)BtBodyBtn.body) btnGroupHolder[i].SetActive(false);
            }
            
        }
    }

    public BodyBtnGroup()
    {
        btnGroupHolder = new UnityEngine.GameObject[(int)BtBodyBtn.count];
    }
    public override void showMonitor()
    {
        btnGroupHolder[(int )BtBodyBtn.body].SetActive(true);
    }
    public override void hideMonitor()
    {
        btnGroupHolder[(int)BtBodyBtn.body].SetActive(false);
    }
}

