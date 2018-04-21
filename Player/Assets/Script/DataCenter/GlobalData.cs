using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {


    private static volatile GlobalData instance;
    private static object _lock = new object();

    public static GlobalData Instance
    {
        get
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new GlobalData();
                }
            }
            return instance;
        }
    }

    //所有玩家信息列表
    public List<GameObject> PlayerDatas;
    //游戏进行时间
    public float CurrentTime; 

    
    // Use this for initialization
    void Start ()
    {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
