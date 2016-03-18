using UnityEngine;
using System.Collections;

public class CreateTiles : MonoBehaviour {

	public int maxTiles;
	public GameObject[] Tiles;

	// Use this for initialization
	void Start () {
		for (int i=0; i<10; i++){
			Debug.Log(i);
			GameObject myTile = Instantiate(Tiles[Random.Range(0,5)], new Vector3(i*6.1f, 0, 0), transform.rotation) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
