using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    public ThirdPersonUserControl userControl;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        userControl = player.GetComponent<ThirdPersonUserControl>();
        userControl.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}


