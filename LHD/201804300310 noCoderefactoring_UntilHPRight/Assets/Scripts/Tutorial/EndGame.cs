using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public GameObject Pn_Win;
    private GameObject enemyCastle;
    private int enemyCastleHP;
	
    // Use this for initialization
	void Start () {
        Pn_Win = GameObject.Find("WinPanel");
        Pn_Win.SetActive(false);

        enemyCastle = GameObject.Find("EnemyCastle");
        enemyCastleHP = enemyCastle.GetComponent<BloodEnemyCastle>().HP;
	}
	
	// Update is called once per frame
	void Update () {
        enemyCastleHP = enemyCastle.GetComponent<BloodEnemyCastle>().HP;
        CheckWin();
        //Debug.Log(enemyCastleHP);
	}

    public void CheckWin()
    {
        
        if (enemyCastleHP <= 0)
        {
            Pn_Win.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
