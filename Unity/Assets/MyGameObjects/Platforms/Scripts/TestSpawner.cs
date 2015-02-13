using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestSpawner : MonoBehaviour {

	public List<GameObject> activeList;
	public List<GameObject> boxes;
	// Use this for initialization
	void Start () {
		this.GenerateFirstBox ();
		for (int i = 0; i<4; i++) {
						this.GenerateBox ();
				}
	}
	
	// Update is called once per frame
	void Update () {
		if(this.activeList.Count<7){
			this.GenerateBox();
		}
	}

	void GenerateFirstBox ()
	{
		GameObject x = (GameObject)GameObject.Instantiate (this.boxes [0], new Vector3 (0, 0, 0), Quaternion.identity);
		x.tag =  "ball";
		x.gameObject.name = "ball";
		this.activeList.Clear ();
		this.activeList.Add(x);
	}

	void GenerateBox ()
	{
		Vector3 lastxpos = this.activeList [this.activeList.Count - 1].transform.position;
		GameObject x = (GameObject)GameObject.Instantiate (this.boxes [0], new Vector3 (lastxpos.x + 2, 0, 0), Quaternion.identity);
		x.tag =  "ball";
		x.gameObject.name = "ball";
		this.activeList.Add(x);
	}

	public void RemoveBox(GameObject gobj){
		if (gobj.gameObject.transform.parent) {
			this.activeList.Remove (gobj.gameObject.transform.parent.gameObject);
			GameObject.Destroy (gobj.gameObject.transform.parent.gameObject);
				} else {
						this.activeList.Remove (gobj);
						GameObject.Destroy (gobj);
				}
		}
}
