
using UnityEngine;
using UnityEditor;

[AddComponentMenu("Modifiers/FFD/Manipulate")]
public class Manipulate : MegaFFD
{

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        HandleInput();
    }

    private void HandleInput()
    {
        Vector3[] points = GetComponent<MegaFFD>().pt;
        Debug.Log("Click");
        if(Input.GetKey(KeyCode.Q))
            points[0] += Vector3.one;
        if (Input.GetKey(KeyCode.W))
            points[1] += Vector3.one;
        if (Input.GetKey(KeyCode.E))
            points[2] += Vector3.one;
        if (Input.GetKey(KeyCode.R))
            points[3] += Vector3.one;
        if (Input.GetKey(KeyCode.A))
            points[4] += Vector3.one;
        if (Input.GetKey(KeyCode.S))
            points[5] += Vector3.one;
        if (Input.GetKey(KeyCode.D))
            points[6] += Vector3.one;
        if (Input.GetKey(KeyCode.F))
            points[7] += Vector3.one;

    }


    
}
