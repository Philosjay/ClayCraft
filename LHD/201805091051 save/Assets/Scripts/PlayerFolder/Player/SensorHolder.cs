using UnityEngine;

class SensorHolder : MonoBehaviour
{
    GameObject sensorBoj;
    Sensor sensor;

    private void Start()
    {
        sensorBoj = new GameObject("sensor");
        sensorBoj.AddComponent<Sensor>();
        sensorBoj.AddComponent<CapsuleCollider>();
        sensorBoj.GetComponent<CapsuleCollider>().transform.position = new Vector3(0, 2, 0.5f);
        sensorBoj.GetComponent<CapsuleCollider>().height = 2;
        sensorBoj.GetComponent<CapsuleCollider>().isTrigger = true;



        sensorBoj.transform.parent = transform;
        Debug.Log(transform.name);

        sensor = sensorBoj.GetComponent<Sensor>();

    }

    private void OnTriggerEnter(Collider other)
    {
//        Debug.Log("sensed!");

 //       Destroy(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
 //       Debug.Log("sensed!");
    }

    private void OnDestroy()
    {
        Destroy(sensorBoj);
    }

    public bool hasDetectedTarget()
    {
        return sensor.hasDetectedTarget();
    }
    
    public Sensor getSensor()
    {
        return sensor;
    }
}
