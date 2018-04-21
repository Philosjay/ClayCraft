using UnityEngine;
using System.Collections;

public class SimpleControlTool : MonoBehaviour {
	public float Speed = 2.0f;
	public LayerMask Layer;

	public Material SelectedMaterial;
	public Material UnselectedMaterial;

	GameObject selectedObject = null;
	
	
	// Update is called once per frame
	void Update () {
		UpdateSelection();

		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity,Layer)) {
				if (selectedObject != null) selectedObject.GetComponent<Renderer>().material = UnselectedMaterial;
				selectedObject = hit.transform.gameObject;
				selectedObject.GetComponent<Renderer>().material = SelectedMaterial;
			}
		}
	}
	void UpdateSelection(){
		if (selectedObject == null) return;
	
		if(Input.GetKey(KeyCode.W)){
			selectedObject.transform.Translate(selectedObject.transform.up * Speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			selectedObject.transform.Translate(selectedObject.transform.up * -Speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A))
		{
			selectedObject.transform.Translate(selectedObject.transform.right * -Speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D))
		{
			selectedObject.transform.Translate(selectedObject.transform.right * Speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Z))
		{
			selectedObject.transform.Translate(selectedObject.transform.forward *-Speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.X))
		{
			selectedObject.transform.Translate(selectedObject.transform.forward * -Speed * Time.deltaTime);
		}
	}
}
