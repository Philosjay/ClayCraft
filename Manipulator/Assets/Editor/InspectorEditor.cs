
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects, CustomEditor(typeof(MegaModifier))]
public class InspectorEditor : MegaModifierEditor
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 pm = new Vector3();

    public override Texture LoadImage() { return (Texture)EditorGUIUtility.LoadRequired("MegaFiers\\ffd_help.png"); }

    bool showpoints = false;

    public override bool Inspector()
    {
        MegaFFD mod = (MegaFFD)target;

#if !UNITY_5 && !UNITY_2017
		EditorGUIUtility.LookLikeControls();
#endif
        mod.KnotSize = EditorGUILayout.FloatField("Knot Size", mod.KnotSize);
        mod.inVol = EditorGUILayout.Toggle("In Vol", mod.inVol);

        handles = EditorGUILayout.Toggle("Handles", handles);
        handleSize = EditorGUILayout.Slider("Size", handleSize, 0.0f, 1.0f);
        mirrorX = EditorGUILayout.Toggle("Mirror X", mirrorX);
        mirrorY = EditorGUILayout.Toggle("Mirror Y", mirrorY);
        mirrorZ = EditorGUILayout.Toggle("Mirror Z", mirrorZ);

        showpoints = EditorGUILayout.Foldout(showpoints, "Points");

        if (showpoints)
        {
            int gs = mod.GridSize();
            //int num = gs * gs * gs;

            for (int x = 0; x < gs; x++)
            {
                for (int y = 0; y < gs; y++)
                {
                    for (int z = 0; z < gs; z++)
                    {
                        int i = (x * gs * gs) + (y * gs) + z;
        //                mod.pt[i] = EditorGUILayout.Vector3Field("p[" + x + "," + y + "," + z + "]", mod.pt[i]);
                    }
                }
            }
        }
        return false;
    }

    static public float handleSize = 0.5f;
    static public bool handles = true;
    static public bool mirrorX = false;
    static public bool mirrorY = false;
    static public bool mirrorZ = false;
}
