using UnityEngine;

class ClayPickSensor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sensed!");
    }
}

