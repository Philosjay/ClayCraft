using UnityEngine;

class PickUp : ActionWithCD
{
    SensorHolder sensor;
    Collider target;
    bool isHoldding;

    // Use this for initialization
    void Start()
    {
        CD = 0.5f;
        triggerKey = KeyCode.C;
        parent = gameObject.GetComponent<Player>();

        gameObject.AddComponent<SensorHolder>();
        sensor = gameObject.GetComponent<SensorHolder>();

        isHoldding = false;
    }

    protected override bool TestTriggered()
    {
        return Input.GetKey(triggerKey);
    }

    protected override void BeginEffect()
    {
        print("trying to pick");
        

        if ( sensor.hasDetectedTarget())
        {
            if (!isHoldding)
            {
                Debug.Log("picked");
                target = sensor.getSensor().getTarget();
                if (target.GetComponent<ClayPickSensor>() != null)
                {
                    target.transform.position = new Vector3(
                    gameObject.transform.position.x, 1.5f, gameObject.transform.position.z - 1);
                    target.transform.parent = gameObject.transform;

                    target.GetComponent<Rigidbody>().useGravity = false;

                    isHoldding = true;
                }

                
            }
            else
            {
                Debug.Log("droped");
                target = sensor.getSensor().getTarget();

                if (target.GetComponent<ClayPickSensor>() != null)
                {

                    target.transform.parent = GameObjectHolder.playYard.transform;
                    target.GetComponent<Rigidbody>().useGravity = true;

                    isHoldding = false;
                }

            }

        }


        
    }

    protected override void CooledEffect()
    {
        print("pick cooled");
    }
}

