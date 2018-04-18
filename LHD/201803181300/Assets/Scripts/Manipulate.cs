using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Modifiers/FFD/FFD Manipulate")]
public class Manipulate : MonoBehaviour {

	MegaFFD mega;
	MegaModifiers modifiers;
	GameObject clay;

	// Use this for initialization
	void Start () {

      	clay = GameObject.FindWithTag("Clay");
        Debug.Log(clay.name);
        AddFDD();
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AddFDD()
	{
		if(!clay.GetComponent<MegaFFD2x2x2>())
		{
            clay.AddComponent<MegaFFD2x2x2>();
        }
	}

}
