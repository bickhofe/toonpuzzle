using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTiles : MonoBehaviour {

	public int maxTiles;
	public GameObject VRcam;
	public GameObject[] Tiles;
	public GameObject Container;
	public GameObject Buttons;
	public int row = 0;
	public int col = 0;
	float xOffset = 6.1f;
	float yOffset = 6.65f;

	public List<Vector2> tilePos = new List<Vector2>();

	void Start () {
		VRcam = GameObject.Find ("VRcam");
		Buttons = GameObject.Find ("Buttons");
		Container = GameObject.Find ("PuzzleContainer");
		CreateTile (0,0);
	}

	void Update(){
		AdjustCam ();
	}

	void AdjustCam(){
		transform.position = new Vector3 (VRcam.transform.rotation.y*10, VRcam.transform.rotation.x*-5, -5);
		//transform.eulerAngles = new Vector3 (0, 0, VRcam.transform.rotation.z*50);
	}

	void ShowHideButtons(){
		//toggle buttons visibility
		if (Buttons.activeSelf) Buttons.SetActive (false);
		else Buttons.SetActive (true);
	}

	public void CreateTile(int rowVal,int colVal) {
		Vector2 pos = new Vector2(row,col);
		tilePos.Add(pos);
		print (tilePos);

		row += rowVal;
		col += colVal;
		//print ("row: " + row + " " + "col: " + col);
		GameObject myTile = Instantiate(Tiles[Random.Range(0,5)], new Vector3(rowVal*xOffset, colVal*yOffset, 10), Quaternion.identity) as GameObject;
		iTween.MoveTo(myTile,iTween.Hash("z",0,"time",1,"delay",0,"islocal",true,"easetype",iTween.EaseType.easeOutBounce));	
		myTile.transform.parent = Container.transform;
		//Container.transform.position = new Vector3(row*-offset, col*-offset, 0);
		iTween.MoveTo(Container,iTween.Hash("position",new Vector3(row*-xOffset, col*-yOffset, 0),"time",1,"delay",0,"easetype",iTween.EaseType.easeInOutSine));	
		//ShowHideButtons ();
	}
}
