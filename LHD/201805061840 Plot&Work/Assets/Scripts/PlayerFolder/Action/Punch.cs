using UnityEngine;
using System.Collections;

public class Punch : ActionWithCD
{
    public GameObject bulletPrefab;

    // Use this for initialization
    void Start()
    {
        CD = 1f;
        triggerKey = KeyCode.G;
        parent = gameObject.GetComponent<Player>();


    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }

    protected override void BeginEffect()
    {
        print("punch");
        Vector3 playerpos = this.transform.position;
        Vector3 bulletpos = new Vector3(playerpos.x, playerpos.y-1f, playerpos.z+1f);
//        GameObject clone = Instantiate(bulletPrefab,bulletpos, Quaternion.identity) as GameObject;
//        Rigidbody bulletf = clone.GetComponent<Rigidbody>();
//        bulletf.AddForce(transform.forward * 50);
        //1.0.5s内碰撞不到也不在有效击打范围内了，也会destroy。2.碰到的不是敌人也在这里destroy
 //       Destroy(clone, 1f);
    }

    protected override void CooledEffect()
    {
        print("punch cooled");
    }

}
