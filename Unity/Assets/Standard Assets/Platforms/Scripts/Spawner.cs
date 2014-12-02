using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	
	public List<GameObject> PathPlatforms;
	public List<GameObject> NoPathPlatforms;
	
	public List<GameObject> activeBottomPlatforms;
	public List<GameObject> activeLeftPlatforms;
	public List<GameObject> activeTopPlatforms;
	public List<GameObject> activeRightPlatforms;
	
	private string bottomPlatformTag = "BottomPlatform";
	private string topPlatformTag = "TopPlatform";
	private string leftPlatformTag = "LeftPlatform";
	private string rightPlatformTag = "RightPlatform";
	
	int difficulty = 2; 
	// Use this for initialization
	void Start () {
		//		for (int i = 0; i<4; i++) {
		this.GeneratePlatforms ();
		Debug.Log ("looping through start"); 
		//		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (activeBottomPlatforms.Count < 6)
			this.GeneratePlatforms ();
		
		
		if (activeLeftPlatforms.Count < 6)
			this.GeneratePlatforms ();
		
		if (activeTopPlatforms.Count < 6)
			this.GeneratePlatforms ();
		
		if (activeRightPlatforms.Count < 6)
			this.GeneratePlatforms ();
		
	}
	
	public void RemoveBottomPlatform(GameObject gobj){
		this.activeBottomPlatforms.Remove (gobj);
		GameObject.Destroy (gobj);
	}
	
	public void RemoveTopPlatform(GameObject tp){
		this.activeTopPlatforms.Remove (tp);
		GameObject.Destroy (tp);
	}
	public void RemoveLeftPlatform(GameObject lp){
		this.activeLeftPlatforms.Remove (lp);
		GameObject.Destroy (lp);
	}
	public void RemoveRightPlatform(GameObject rp){
		this.activeRightPlatforms.Remove (rp);
		GameObject.Destroy (rp);
	}
	
	void GeneratePlatformsTest ()
	{
		float val = Random.value; //will it be path or no path
		Vector3 lastBotPlatPos = this.activeBottomPlatforms [this.activeBottomPlatforms.Count - 1].transform.position;
		if (val < .5) {
			//Debug.Log ("np before adding platform: ");
			int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
			GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
			x.tag = "BottomPlatform";
			this.activeBottomPlatforms.Add (x);
			//Debug.Log("np after addition: ");
			
		}
		else {
			int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
			GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
			x.tag = "BottomPlatform";
			this.activeBottomPlatforms.Add (x);
			//this.activeBottomPlatforms.Add (
			//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity));
		} 
		
	}
	
	void GeneratePlatforms ()
	{
		int np = difficulty; 
		int p = 4 - difficulty; 
		if (this.activeBottomPlatforms.Count == 0) {
			GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [0], new Vector3 (14, 0, 0), Quaternion.identity);
			x.tag = bottomPlatformTag;
//			x.gameObject.tag = "BottomPlatform";
			this.activeBottomPlatforms.Add (x);
		}
		if (this.activeLeftPlatforms.Count == 0) {
			Quaternion leftRotate = Quaternion.AngleAxis (90, Vector3.left);
			GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [0], new Vector3 (14, 3, 3.5f), leftRotate);
			x.tag = leftPlatformTag;
//			x.gameObject.tag = "LeftPlatform";
			this.activeLeftPlatforms.Add (x);
		}
		if (this.activeTopPlatforms.Count == 0) {
			Quaternion topRotate = Quaternion.AngleAxis(180, Vector3.left);
			GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [0], new Vector3 (14, 6.5f, 0), topRotate);
			//x.gameObject.tag = "TopPlatform";
			x.tag = topPlatformTag;
			this.activeTopPlatforms.Add (x);
		}
		if (this.activeRightPlatforms.Count == 0) {
			Quaternion rightRotate = Quaternion.AngleAxis (-90, Vector3.left);
			GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [0], new Vector3 (14, 3, -3.5f), rightRotate);
			//x.gameObject.tag = "RightPlatform";
			x.tag = rightPlatformTag;
			this.activeRightPlatforms.Add (x);
		}
		
		if (this.activeTopPlatforms.Count != 0 || this.activeRightPlatforms.Count != 0 || this.activeLeftPlatforms.Count != 0 || this.activeBottomPlatforms.Count != 0) {
			for (int s = 0; s<4; s++) {
				switch (s) {
				case 0:
					string nametag = bottomPlatformTag; 
					float val = Random.value; //will it be path or no path
					Vector3 lastBotPlatPos = this.activeBottomPlatforms [this.activeBottomPlatforms.Count - 1].transform.position;
					Quaternion noRotate = Quaternion.identity;
					if (val < .5) {
						if (np > 0) {
							np = np - 1;
							CreateNoPathPlatform(nametag, lastBotPlatPos, 0,0, noRotate);
							/*							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
							x.tag = "BottomPlatform";
												this.activeBottomPlatforms.Add (x);*/
						} else {
							CreatePathPlatform(nametag, lastBotPlatPos, 0, 0, noRotate);
							/*							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
							x.tag = "BottomPlatform";
							this.activeBottomPlatforms.Add (x);
*/
							p = p - 1;
						}
					} else {
						if (p > 0) {
							p = p - 1;
							CreatePathPlatform(nametag, lastBotPlatPos, 0, 0, noRotate);
							/*int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
							x.tag = "BottomPlatform";
							this.activeBottomPlatforms.Add (x);*/
						} else {
							CreateNoPathPlatform(nametag, lastBotPlatPos, 0, 0, noRotate);
							np = np - 1;
							/*
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
							x.tag = "BottomPlatform";
							this.activeBottomPlatforms.Add (x);*/
						}
					}
					break; 
				case 1: //Left
					float leftval = Random.value; //will it be path or no path
					Vector3 lastLeftPlatPos =  this.activeLeftPlatforms [this.activeLeftPlatforms.Count - 1].transform.position;; 
					Quaternion leftRotate = Quaternion.AngleAxis (90, Vector3.left);
					if (leftval < .5) {
						if (np > 0) {
							np = np - 1;
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							GameObject x = ((GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate));
							x.tag = "LeftPlatform";
							this.activeLeftPlatforms.Add (x);
						} else {
							p = p - 1;
							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeLeftPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate);
							x.gameObject.tag = "LeftPlatform";
							this.activeLeftPlatforms.Add (x);
						}
					} else {
						if (p > 0) {
							p = p - 1;
							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeLeftPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate);
							x.tag = "LeftPlatform";
							this.activeLeftPlatforms.Add (x);
						} else {
							np = np - 1;
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							//this.activeLeftPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate);
							x.tag = "LeftPlatform";
							this.activeLeftPlatforms.Add (x);
						}
					}
					break;
				case 2: //Top
					float topval = Random.value; //will it be path or no path
					//				Debug.Log ("Top random val: " + topval); 
					
					Vector3 lastTopPlatPos = this.activeTopPlatforms [this.activeTopPlatforms.Count - 1].transform.position;
					Quaternion topRotate = Quaternion.AngleAxis (180, Vector3.left);
					if (topval < .5) {
						if (np > 0) {
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							//this.activeTopPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate));
							np = np - 1;
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate);
							x.tag = "TopPlatform";
							this.activeTopPlatforms.Add (x);
						} else {
							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeTopPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate));
							p = p - 1;
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate);
							x.tag = "TopPlatform";
							this.activeTopPlatforms.Add (x);
						}
					} else {
						if (p > 0) {
							p = p - 1;
							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeTopPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate);
							x.tag = "TopPlatform";
							this.activeTopPlatforms.Add (x);
						} else {
							//		Debug.Log ("np before adding platform: " +np);
							np = np - 1;
							//		Debug.Log("np after addition: " +np);														
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate);
							x.tag = "TopPlatform";
							this.activeTopPlatforms.Add (x);
							//this.activeTopPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate));
						}
					}
					break;
				case 3: //right
					float rightval = Random.value; //will it be path or no path
					//						Debug.Log ("Right side random val: " + rightval); 
					Vector3 lastRightPlatPos = this.activeRightPlatforms [this.activeRightPlatforms.Count - 1].transform.position;
					Quaternion rightRotate = Quaternion.AngleAxis (-90, Vector3.left);
					if (rightval < .5) {
						if (np > 0) {
							//			Debug.Log ("np before adding platform: " +np);
							np = np - 1;
							//			Debug.Log("np after addition: " +np);														
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							//this.activeRightPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate);
							x.tag = "RightPlatform";
							this.activeRightPlatforms.Add (x);
						} else {
							p = p - 1;
							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeRightPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate);
							x.tag = "RightPlatform";
							this.activeRightPlatforms.Add (x);
						}
					} else {
						if (p > 0) {
							p = p - 1;
							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeRightPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate);
							x.tag = "RightPlatform";
							this.activeRightPlatforms.Add (x);
						} else {
							//		Debug.Log ("np before adding platform: " +np);
							np = np - 1;
							//			Debug.Log("np after addition: " +np);														
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							//this.activeRightPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate);
							x.tag = "RightPlatform";
							this.activeRightPlatforms.Add (x);
						}
					}
					break; 
				default:
					break; 
				}
			}
		}
	}
	
	
	void CreateNoPathPlatform (string tagname, Vector3 lastxVector, float ypos, float zpos, Quaternion rq)
	{
		int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
		GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastxVector.x + 14f, ypos, zpos), rq);
		x.gameObject.tag = tagname;
		this.activeBottomPlatforms.Add (x);
	}
	
	void CreatePathPlatform( string tagname, Vector3 lastxVector, float ypos, float zpos, Quaternion rq){
		int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
		GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastxVector.x + 14f, ypos, zpos), rq);
		x.gameObject.tag = tagname;
		this.activeBottomPlatforms.Add (x);
	}
	
}
