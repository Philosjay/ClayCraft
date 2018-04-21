using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeControl : MonoBehaviour
{
    public int PlayerID;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        //带有黏土的标签的物体碰到基地后会给对应的玩家加资源
        if (col.tag == "soil")
        {
            Destroy(col);
            foreach (GameObject g in GlobalData.Instance.PlayerDatas)
            {
                if (g.GetComponent<PlayerData>().PlayerID == PlayerID)
                {
                    g.GetComponent<PlayerData>().Resource += 10;
                }
            }
        }
    }
}