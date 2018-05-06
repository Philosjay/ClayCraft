using UnityEngine;


public class Block : MegaFFD 
{
    //拖拽用
    Vector3[] points;
    GameObject[] markerHolder = new GameObject[8];
    int curMarkerIndex = 0;

    // 修正坐标
    Vector3 joinPos;

    // Use this for initialization
    void Start()
    {
        joinPos = new Vector3();
 //       InitMarkers();
    }

    // Update is called once per frame
    void Update()
    {
//        UpdateMarkers();
    }

    public void setJiontPos(Vector3 pos)
    {
        joinPos.Set(pos.x,pos.y,pos.z);
    }

    public void Drag(float x, float y, float z)
    {
        points = GetComponent<MegaFFD>().pt;
        points[curMarkerIndex] += new Vector3(x, y, z);
    }

    public float GetBlockSize()
    {
        Vector3[] points = GetComponent<MegaFFD>().pt;
        //求bounding box
        Vector3 max = new Vector3(points[0].x, points[0].y, points[0].z);
        Vector3 min = new Vector3(points[0].x, points[0].y, points[0].z);


        for (int i = 1; i < 8; i++)
        {
            if (points[i].x > max.x)
                max.x = points[i].x;
            else if (points[i].x < min.x)
                min.x = points[i].x;

            if (points[i].y > max.y)
                max.y = points[i].y;
            else if (points[i].y < min.y)
                min.y = points[i].y;

            if (points[i].z > max.z)
                max.z = points[i].z;
            else if (points[i].z < min.z)
                min.z = points[i].z;
        }
        float BBV = (max.x - min.x) * (max.y - min.y) * (max.z - min.z);
        return BBV;

    }
    public void InitMarkers()
    {
        /*
        points = ModifyPosition(GetComponent<MegaFFD>().pt);
        for (int i = 0; i < 8; i++)
        {
            GameObject marker = (GameObject)Instantiate(
            MarkerPrefab,
            points[i], new Quaternion(0, 0, 0, 0));
            marker.transform.position = points[i];
            marker.SetActive(false);
            markerHolder[i] = marker;        
        }
        */
    }

    public void EnableMarkers(bool isEnabled)
    {
        for (int i = 0; i < 8; i++)
        {
            markerHolder[i].SetActive(isEnabled);
        }
    }



    void UpdateMarkers()
    {
        points = ModifyPosition(GetComponent<MegaFFD>().pt);
        for (int i = 0; i < 8; i++)
        {
            markerHolder[i].transform.position = points[i];
            markerHolder[i].GetComponent<MeshRenderer>().material.color = Color.red;
            markerHolder[curMarkerIndex].GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    public void SetCurMarkerIndex(int index)
    {
        curMarkerIndex = index;
    }

    public Vector3[] GetMarkerPosition()
    {
        Vector3[] pos= new Vector3[8];
        for(int i = 0; i < 8; i++)
        {
            pos[i] = markerHolder[i].transform.position;
        }
        return pos;
    }

    Vector3[] ModifyPosition(Vector3[] origin)
    {
        Vector3[] neo = new Vector3[origin.Length];
        for (int i = 0; i < origin.Length; i++)
        {
            neo[i] += origin[i] + transform.position;
            /*
            neo[i] += joinPos;
            neo[i].x *= 0.5f;
            neo[i].y *= 0.9f;
            neo[i].z *= 0.4f;
            */
        }
        return neo;
    }
}