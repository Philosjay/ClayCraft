using UnityEngine;

class Sensor : MonoBehaviour
{
    bool isSensed;
    Collider target;

    private void Start()
    {
        isSensed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        target = other;
        isSensed = true;
    }
    private void OnTriggerExit(Collider other)
    {
        target = null;

        isSensed = false;
    }

    public bool hasDetectedTarget()
    {
        return isSensed;
    }

    public Collider getTarget()
    {
        return target;
    }
}

