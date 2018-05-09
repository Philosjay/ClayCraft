using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ClickInfoHolder
{
    static public ClickInfo info;
    public ClickInfo get()
    {
        if (info == null)
        {
            info = new ClickInfo();
        }
        return info;
    }
}

