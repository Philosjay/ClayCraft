
public class UpBodyBtnGroup : BtnGroup
{
    public enum UpBodyBtn
    {
        body2,
        body6,
        spine2,

        count,
    }

    public UpBodyBtnGroup()
    {
        btnGroupHolder = new UnityEngine.GameObject[(int)UpBodyBtn.count];
    }
}
