using UnityEngine;
using UnityEditor;


public class Block : MegaFFD
{
    //拖拽用
    Vector3[] points;
    public GameObject MarkerPrefab;
    GameObject[] markerHolder = new GameObject[8];
    int curMarkerIndex = 0;

    // Use this for initialization
    void Start()
    {
        InitMarkers();
    }

    // Update is called once per frame
    void Update()
    {
        points = GetComponent<MegaFFD>().pt;
        UpdateMarkers();
        
    }

    public void Drag(float x, float y, float z)
    {
        points = GetComponent<MegaFFD>().pt;
        points[curMarkerIndex] += new Vector3(x, y, z);
    }

    public void InitMarkers()
    {
        points = gameObject.GetComponent<MegaFFD>().pt;
        for (int i = 0; i < 8; i++)
        {
            GameObject marker = (GameObject)Instantiate(
            MarkerPrefab,
            points[i], new Quaternion(0, 0, 0, 0));
            marker.transform.position = points[i];
            marker.SetActive(false);
            markerHolder[i] = marker;
        }
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
        return ModifyPosition( GetComponent<MegaFFD>().pt );
    }

    Vector3[] ModifyPosition(Vector3[] origin)
    {
        Vector3[] neo = new Vector3[origin.Length];
        for (int i = 0; i < origin.Length; i++)
        {
            neo[i] = origin[i] + gameObject.transform.position;
        }
        return neo;
    }
}