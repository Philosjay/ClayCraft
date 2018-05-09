using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.tag == "Enemy")
        {
            print("enemy is attacked");
            Destroy(gameObject);
        }
    }
}
