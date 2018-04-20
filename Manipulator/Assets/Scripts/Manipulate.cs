
using UnityEngine;
using UnityEditor;


public class Manipulate : MonoBehaviour
{
    //射线检测用
    public Camera ca;
    private Ray ra;
    private RaycastHit hit;

    public Block body;
    public Block head;
    public Block lLeg;
    public Block rLeg;
    public Block lArm;
    public Block rArm;


    //拖拽用
    bool isGrabbing = false;
    Block[] blockHolder = new Block[8];
    int curBlockIndex = 0;

    // Use this for initialization
    void Start () {
        blockHolder[0] = body;
        blockHolder[1] = head;
        blockHolder[2] = lLeg;
        blockHolder[3] = rLeg;
        blockHolder[4] = lArm;
        blockHolder[5] = rArm;

    }

    // Update is called once per frame
    void Update() {
               
        // 鼠标右键选择block
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            blockHolder[curBlockIndex].EnableMarkers(false);
            curBlockIndex = GetBlock();
            
        }

        // 显示选中的block的marker
        blockHolder[curBlockIndex].EnableMarkers(true);

        // 开启/关闭拖拽模式
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isGrabbing = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isGrabbing = false;
        }

        // 不在拖拽模式则尝试选中marker
        if (!isGrabbing)
        {
            SetMarkerIndex(curBlockIndex);
        }
        else
        {
            // 在拖拽模式进行拖拽
            var x = Input.GetAxis("Mouse X") * 20 * Time.deltaTime;
            var y = Input.GetAxis("Mouse Y") * 20 * Time.deltaTime;
            var z = Input.GetAxis("Mouse ScrollWheel") * 4f;

            x = ca.transform.position.x < 0 ? -x : x;
            y = ca.transform.position.y < 0 ? -y : y;
            z = ca.transform.position.z < 0 ? z : -z;

            blockHolder[curBlockIndex].Drag(x, y, z);
        }

    }


    int GetBlock()
    {
        ra = ca.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ra, out hit))
        {
            for (int i = 0; i < blockHolder.Length; i++)
            {
                if (hit.collider.gameObject.transform.position - blockHolder[i].transform.position == Vector3.zero)
                {
                    return i;
                }
            }

        }

        return curBlockIndex;
    }

    void  SetMarkerIndex(int blockIndex)
    {  

        Vector3[] points = blockHolder[blockIndex].GetMarkerPosition();

        ra = ca.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ra, out hit))
        {
            for (int i = 0; i < 8; i++)
            {
                if (hit.collider.gameObject.transform.position - points[i] == Vector3.zero)
                {
                    blockHolder[blockIndex].SetCurMarkerIndex(i);
                }
                   
            }
                
        }

    }
    
    Vector3 ModifyCameraPosition(Vector3 obj)
    {
        return new Vector3(obj.x + ca.transform.position.x, obj.y - ca.transform.position.y, obj.z + ca.transform.position.z);
    }
}
