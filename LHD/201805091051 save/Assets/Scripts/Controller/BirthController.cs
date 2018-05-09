using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class BirthController : MonoBehaviour
{
    public Workbench workbench;
    public GameObject playYard;
    public GameObject workbenchModel;
    public GameObject playerModel;

    bool isBirthed = false;

    private void Start()
    {
        StartCoroutine(WaitForInitAndStart(2f));


    }

    private void Update()
    {

        if (!isBirthed)
        {
            if (workbench.isComplete())
            {
                workbench.quit();

                workbench.gameObject.SetActive(false);
                playYard.SetActive(true);

                isBirthed = true;
            }
        }
        else
        {
            Vector3 dis = playerModel.transform.position - workbenchModel.transform.position;

            if (dis.x < 0) dis.x = -dis.x;
            if (dis.y < 0) dis.y = -dis.y;
            if (dis.z < 0) dis.z = -dis.z;


            if ( (  dis.x < 1 )&&(dis.z <1))
            {
                workbench.gameObject.SetActive(true);
                playYard.SetActive(false);
                workbench.enter();

                isBirthed = false;
            }

        }


    }


    IEnumerator WaitForInitAndStart(float time)
    {
        yield return new WaitForSeconds(time);

        workbench.gameObject.SetActive(true);
        playYard.gameObject.SetActive(false);
    }
}

