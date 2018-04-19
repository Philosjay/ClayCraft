using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoints : MonoBehaviour {

    //public GameObject targetObject;

	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
		//ShowPointsChange();
	}

    void ShowPointsChange()
    {
        Vector3[] points = GetComponent<MegaFFD>().pt;
        int gs = GetComponent<MegaFFD>().GridSize();
        for (int x = 0; x < gs; x++)
        {
            for (int y = 0; y < gs; y++)
            {
                for (int z = 0; z < gs; z++)
                {
                    int i = (x * gs * gs) + (y * gs) + z;
                    Debug.Log(points[i]);
                }
            }
        }
    }
}
