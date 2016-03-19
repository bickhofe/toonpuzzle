using UnityEngine;
using System.Collections;


public class RayCast : MonoBehaviour {

	public CreateTiles TilesScript;
	GameObject curButton;
	RaycastHit hit;
	float time = 0;
	public float focusTime;

	// Use this for initialization
	void Start () {
		TilesScript = transform.parent.GetComponent<CreateTiles> ();
	}

	void FixedUpdate() 
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		//Debug.DrawRay(transform.position, fwd*25, Color.green);

		if (Physics.Raycast (transform.position, fwd, out hit)) {
			if (hit.collider.name == "plusRight") NewTile(1,0);
			else if (hit.collider.name == "plusLeft") NewTile(-1,0);
			else if (hit.collider.name == "plusTop") NewTile(0,1);
			else if (hit.collider.name == "plusBottom") NewTile(0,-1);
		} else {
			if (curButton != null) curButton.transform.localScale = new Vector3(.5f,.5f,.5f);
		}
	}

	void NewTile(int row, int col){

		curButton = hit.collider.gameObject;
		time += Time.deltaTime;
		curButton.transform.localScale = new Vector3(.75f,.75f,.75f);
		//delay
		if (time > focusTime) {
			curButton.transform.localScale = new Vector3(.5f,.5f,.5f);
			TilesScript.CreateTile (row, col);
			time = 0;
		}
	}

}
