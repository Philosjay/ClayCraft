using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class JointPairHolder
{
    GameObject joint1, joint2;
    int[] indexs;
    int index;
    Block block;

    public void SetPair(GameObject j1, GameObject j2)
    {
        joint1 = j1;
        joint2 = j2;
    }
    public void SetPair(GameObject j1, Block block,int[] index)
    {
        joint1 = j1;
        this.block = block;

        this.indexs = new int[index.Length];
        for(int i = 0; i < index.Length; i++)
        {
            indexs[i] = index[i];
        }
    }
    public void SetPair(GameObject j1, Block block, int index)
    {
        joint1 = j1;
        this.block = block;
        this.index = index;
    }
    public void move(Vector3 delta)
    {
        joint1.transform.position += delta;

        
    }
    public void moveJoint1(Vector3 delta)
    {
        joint1.transform.position += delta;

    }
    public void moveJoint2(Vector3 delta)
    {
        if (joint2 != null)
        {
            joint2.transform.position += delta;
        }
        else
        {
            if (indexs != null)
            {
                for (int i = 0; i < indexs.Length; i++)
                {
                    block.GetComponent<MegaFFD2x2x2>().pt[indexs[i]] += delta;
                }
            }
            else
            {
                block.GetComponent<MegaFFD2x2x2>().pt[index] += delta;
            }
        }
    }
}
