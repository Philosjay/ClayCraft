
using UnityEngine;
using UnityEditor;


[AddComponentMenu("Modifiers/FFD/Manipulate")]
public class Manipulate : MegaFFD
{
    //射线检测用
    public Camera ca;
    private Ray ra;
    private RaycastHit hit;




    //拖拽用
    bool isGrabbing = false;
    Vector3[] points;
    public GameObject MarkerPrefab;
    GameObject[] markerHolder = new GameObject[8];
    int curPointIndex = 0;

    // Use this for initialization
    void Start () {
        InitMarkers(GetComponent<MegaFFD>().pt);
    }
	
	// Update is called once per frame
	void Update () {
        points = GetComponent<MegaFFD>().pt;

        if (!isGrabbing)
        {
            UpdatePointIndex();
        }
        

                
        UpdateMarkers(points);



        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isGrabbing = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isGrabbing = false;
        }

        if (isGrabbing)
        {
            Drag(curPointIndex);
        }
    }

    void Drag(int index)
    {
        var x = Input.GetAxis("Mouse X") * 20 * Time.deltaTime;
        var y = Input.GetAxis("Mouse Y") * 20 * Time.deltaTime;
        var z = Input.GetAxis("Mouse ScrollWheel") * 4f;

        x = ca.transform.position.x < 0 ? -x : x;
        y = ca.transform.position.y < 0 ? -y : y;
        z = ca.transform.position.z < 0 ? z : -z;

        // 这个方法有bug
        //     points[index] = ModifyCameraPosition( ca.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, hit.collider.gameObject.transform.position.z)) );


        points[index] += new Vector3(x, y, z);

        
    }

    void UpdatePointIndex()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            curPointIndex = 0;
        }else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curPointIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curPointIndex = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curPointIndex = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            curPointIndex = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            curPointIndex = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            curPointIndex = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            curPointIndex = 7;
        }
        */

        if (Input.GetMouseButton(0))
        {
            ra = ca.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit))
            {
                for (int i = 0; i < 8; i++)
                {
                    if (hit.collider.gameObject.transform.position - points[i] == Vector3.zero)
                    {
                        curPointIndex = i;
                    }
                   
                }
                
            }
        }

    }

    void InitMarkers(Vector3[] points)
    {
       
        for (int i = 0; i < 8; i++)
        {
            GameObject marker = (GameObject)Instantiate(
            MarkerPrefab,
            points[i],new Quaternion(0,0,0,0));
            marker.transform.position = points[i];
            markerHolder[i] = marker;
        }
    }


    void UpdateMarkers(Vector3[] points)
    {
        for (int i = 0; i < 8; i++)
        {
            markerHolder[i].transform.position = points[i];
            markerHolder[i].GetComponent<MeshRenderer>().material.color = Color.red;
            markerHolder[curPointIndex].GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
    
    Vector3 ModifyCameraPosition(Vector3 obj)
    {
        return new Vector3(obj.x + ca.transform.position.x, obj.y - ca.transform.position.y, obj.z + ca.transform.position.z);
    }
}
