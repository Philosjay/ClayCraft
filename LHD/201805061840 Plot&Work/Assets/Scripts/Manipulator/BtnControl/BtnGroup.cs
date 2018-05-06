using UnityEngine;


public class BtnGroup
{ 
    protected GameObject[] btnGroupHolder;

    public void putBtn(int index, GameObject btn)
    {
        btnGroupHolder[index] = btn;
    }

    virtual public void showGroup()
    {
        for (int i = 0; i < btnGroupHolder.Length; i++)
        {
            if (btnGroupHolder[i]!=null)
                btnGroupHolder[i].SetActive(true);
        }
    }

    virtual public void hideGroup()
    {
        for (int i = 0; i < btnGroupHolder.Length; i++)
        {
            if (btnGroupHolder[i] != null)
                btnGroupHolder[i].SetActive(false);
        }
    }

    public void showBtnInGroup(int index)
    {
        btnGroupHolder[index].SetActive(true);
    }

    public void move(Vector3 delta)
    {
        for (int i=0;i< btnGroupHolder.Length; i++)
        {
            if (btnGroupHolder[i] != null)
                btnGroupHolder[i].transform.position += delta;
        }
    }
    public void moveBtnInGroup(int index, Vector3 delta)
    {
        btnGroupHolder[index].transform.position += delta;
    }

    public void hideBtnInGroup(int index)
    {
        btnGroupHolder[index].SetActive(false);
    }

    virtual public void showMonitor()
    {

    }
    virtual public void hideMonitor()
    {

    }
}

