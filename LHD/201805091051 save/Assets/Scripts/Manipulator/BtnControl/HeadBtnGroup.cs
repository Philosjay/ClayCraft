

class HeadBtnGroup : BtnGroup
{
    public enum HeadBtn{
        head0,
        head1,
        head2,
        head3,
        head4,
        head5,
        head6,
        head7,
        head,

        count,
    }

    public override void hideGroup()
    {
        for (int i = 0; i < btnGroupHolder.Length; i++)
        {
            if (i != (int)HeadBtn.head) btnGroupHolder[i].SetActive(false);
        }
    }

    public HeadBtnGroup()
    {
        btnGroupHolder = new UnityEngine.GameObject[(int)HeadBtn.count];
    }
    public override void showMonitor()
    {
        btnGroupHolder[(int)HeadBtn.head].SetActive(true);
    }

    public override void hideMonitor()
    {
        btnGroupHolder[(int)HeadBtn.head].SetActive(false);
    }
}

