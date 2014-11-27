using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {

	//Collection of objects to Spawn
	public List<GameObject> NoPathList;
	public List<GameObject> PathList;

	public List<GameObject> activeFloorList;
	public List<GameObject> activeLeftList;
	public List<GameObject> activeTopList;
	public List<GameObject> activeRightList;

	public int pathdificulty = 2;

	//Spawn between 1 and 2 seconds
	public float spawnMin = 1f;
	public float spawnMax = 2f; 



	// Use this for initialization
	void Start () {
		//Spawn ();
		for (int i = 0; i<4; i++) {
			this.GeneratePlatform();
		}
	}

//	void Spawn(){
		//Randomly Selects between Path and No Path;
		//Instantiate(objs[Random.Range (0, objs.GetLength(0))], transform.position, Quaternion.identity);
		//Invoke ("Spawn", Random.Range(spawnMin, spawnMax)); 
//	}

	public void Update(){
		if (activeFloorList.Count < 5) {
			this.GeneratePlatform ();
		}
		if (activeLeftList.Count < 5) {
			this.GeneratePlatform ();
		}
		if (activeRightList.Count < 5) {
			this.GeneratePlatform ();
		}
		if (activeTopList.Count < 5) {
			this.GeneratePlatform ();
		}
	}

	public void RemovePlatform(GameObject gobj){
		this.activeFloorList.Remove (gobj);
		GameObject.Destroy (gobj);
	}

	void GeneratePlatform ()
	{
		int np = pathdificulty;
		int p = 4-pathdificulty;
		float val = Random.value;
		//determine randomly if there is a path or no path for each generation round 
		//p np values determine how many np's or p's are allowed
		//<.5 is no path

		//WORKING BOTTOM
		/*		Vector3 lastBotPlatPos = this.activeFloorList [this.activeFloorList.Count - 1].transform.position;

		if (val < .5) {
			//np = np-1; 
			int platformIndex = ((int) Random.value)% this.NoPathList.Count;
			this.activeFloorList.Add((GameObject)GameObject.Instantiate(this.NoPathList[platformIndex], new Vector3(lastBotPlatPos.x + 14,0,0), Quaternion.identity));
		}else{
			//p=p-1;
			int platformIndexP = ((int) Random.value)% this.PathList.Count;//Select Random PathPlatType
			this.activeFloorList.Add((GameObject)GameObject.Instantiate(this.PathList[platformIndexP], new Vector3(lastBotPlatPos.x + 14,0,0), Quaternion.identity));
		}
		*/
		for (int s = 0; s<4; s++) {
			switch(s){
			case 0:
				Vector3 lastBotPlatPos = this.activeFloorList [this.activeFloorList.Count - 1].transform.position;
				
				if (val < .5) {
					np = np-1; 
					int platformIndex = ((int) Random.value)% this.NoPathList.Count;
					this.activeFloorList.Add((GameObject)GameObject.Instantiate(this.NoPathList[platformIndex], new Vector3(lastBotPlatPos.x + 14,0,0), Quaternion.identity));
				}else{
					p=p-1;
					int platformIndexP = ((int) Random.value)% this.PathList.Count;//Select Random PathPlatType
					this.activeFloorList.Add((GameObject)GameObject.Instantiate(this.PathList[platformIndexP], new Vector3(lastBotPlatPos.x + 14,0,0), Quaternion.identity));
				}
				break; 
			case 1:
				Vector3 lastLeftPlatPos = this.activeLeftList [this.activeLeftList.Count - 1].transform.position;
				Quaternion sideRotate = Quaternion.AngleAxis (90, Vector3.left);
				if (val < .5 && np>0) {
					np = np-1; 
					int platformIndex = ((int) Random.value)% this.NoPathList.Count;
					this.activeLeftList.Add((GameObject)GameObject.Instantiate(this.NoPathList[platformIndex], new Vector3(lastLeftPlatPos.x + 14,3,3.5f), sideRotate));
				}else
				{
					if(p>0){
						p=p-1;
						int platformIndexP = ((int) Random.value)% this.PathList.Count;//Select Random PathPlatType
						this.activeFloorList.Add((GameObject)GameObject.Instantiate(this.PathList[platformIndexP], new Vector3(lastLeftPlatPos.x + 14,3,3.5f), Quaternion.identity));
					}
				}
				break; 
			case 2:
				Vector3 lastTopPlatPos = this.activeTopList [this.activeTopList.Count - 1].transform.position;
				Quaternion topRotate = Quaternion.AngleAxis (180, Vector3.left);
				if (val < .5 ){
				if(np>0) {
					np = np-1; 
					int platformIndex = ((int) Random.value)% this.NoPathList.Count;
					this.activeTopList.Add((GameObject)GameObject.Instantiate(this.NoPathList[platformIndex], new Vector3(lastTopPlatPos.x + 14,6,0f), topRotate));
					}
					else{
						p=p-1;
						int platformIndex = ((int) Random.value)% this.PathList.Count;
						this.activeTopList.Add((GameObject)GameObject.Instantiate(this.PathList[platformIndex], new Vector3(lastTopPlatPos.x + 14,6,0f), topRotate)); 
					}
				}else
				{
					if(p>0){
						p=p-1;
						int platformIndex = ((int) Random.value)% this.PathList.Count;
						this.activeTopList.Add((GameObject)GameObject.Instantiate(this.PathList[platformIndex], new Vector3(lastTopPlatPos.x + 14,6,0f), topRotate)); 
					}
					else{
						np=np-1;
						int platformIndex = ((int) Random.value)% this.NoPathList.Count;
						this.activeTopList.Add((GameObject)GameObject.Instantiate(this.NoPathList[platformIndex], new Vector3(lastTopPlatPos.x + 14,6,0f), topRotate));
					}
				}
				break;
			case 3:
				Vector3 lastRightPlatPos = this.activeRightList [this.activeRightList.Count - 1].transform.position;
				Quaternion rightRotate = Quaternion.AngleAxis (-90, Vector3.left);
				if (val < .5 ){
					if(np>0) {
						np = np-1; 
						int platformIndex = ((int) Random.value)% this.NoPathList.Count;
						this.activeRightList.Add((GameObject)GameObject.Instantiate(this.NoPathList[platformIndex], new Vector3(lastRightPlatPos.x + 14,3,-3.5f), rightRotate));
					}
					else{
						p=p-1;
						int platformIndex = ((int) Random.value)% this.PathList.Count;
						this.activeRightList.Add((GameObject)GameObject.Instantiate(this.PathList[platformIndex], new Vector3(lastRightPlatPos.x + 14,3,-3.5f), rightRotate)); 
					}
				}else
				{
					if(p>0){
						p=p-1;
						int platformIndex = ((int) Random.value)% this.PathList.Count;
						this.activeRightList.Add((GameObject)GameObject.Instantiate(this.PathList[platformIndex], new Vector3(lastRightPlatPos.x + 14,3,-3.5f), rightRotate)); 
					}
					else{
						np=np-1;
						int platformIndex = ((int) Random.value)% this.NoPathList.Count;
						this.activeRightList.Add((GameObject)GameObject.Instantiate(this.NoPathList[platformIndex], new Vector3(lastRightPlatPos.x + 14,3,-3.5f), rightRotate));
					}
				}
				break; 
			default:
				break;
			}
		}

	}
}
