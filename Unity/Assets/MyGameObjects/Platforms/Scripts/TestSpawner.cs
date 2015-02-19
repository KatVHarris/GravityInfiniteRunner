using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestSpawner : MonoBehaviour {
	
	public List<GameObject> PathPlatforms;
	public List<GameObject> NoPathPlatforms;

	//NotSperated
	public List<GameObject> activeBottomPlatforms;
	public List<GameObject> activeLeftPlatforms;
	public List<GameObject> activeTopPlatforms;
	public List<GameObject> activeRightPlatforms;

	//waitlist
	public List<GameObject> bottomWaitList;
	public List<GameObject> leftWaitList;
	public List<GameObject> topWaitList;
	public List<GameObject> rightWiatList;
	
	private string bottomPlatformTag = "BottomPlatform";
	private string topPlatformTag = "TopPlatform";
	private string leftPlatformTag = "LeftPlatform";
	private string rightPlatformTag = "RightPlatform";
	
	public float leftPlatAdjustment = -3.5f; 
	public float rightPlatAdjustment = 3.5f; 
	public float topPlatAdjustment = 3f; 
	public float botPlatAdjustment = -3f; 

	public static Quaternion platformRoation; 
	public static float platformAngle; 

	
	float platformRandomness;
	int difficulty = 2; 
	float pathNoPath; 
	TestPlatformRotate tpr; 
	bool isRotating; 

	private Quaternion RightSideReference; 
	private Quaternion LeftSideReference; 
	private Quaternion TopReference; 
	private Quaternion BottomReference; 

	GameObject gameObjectTest; 
	TestPlatformController testObject;

	// Use this for initialization
	void Start () {
		//for (int i = 0; i<4; i++) {
		this.GeneratePlatforms ();
		//	this.CreatePlatforms ();

		Debug.Log ("looping through start"); 
		//	}

		//SPERATION CODE
		/*
		gameObjectTest = GameObject.Find ("TestPlatformControllerObject");
		testObject = gameObjectTest.GetComponent<TestPlatformController>();
		*/
	}
	
	// Update is called once per frame
	void Update () {
		if (!(TestPlatformRotate.rotating)) {

						if (bottomWaitList.Count > 0) {
								foreach (GameObject plat in bottomWaitList) {
										plat.transform.parent = roatatorObject.transform; 
								}
				bottomWaitList.Clear();

						}
		

						if (leftWaitList.Count > 0) {
				foreach (GameObject plat in leftWaitList) {
					plat.transform.parent = roatatorObject.transform; 
				}
				leftWaitList.Clear();
						}

						if (topWaitList.Count > 0) {
				foreach (GameObject plat in topWaitList) {
					plat.transform.parent = roatatorObject.transform; 
					//topWaitList.Remove(plat);
				}
				topWaitList.Clear();
						}

						if (rightWiatList.Count > 0) {
				foreach (GameObject plat in rightWiatList) {
					plat.transform.parent = roatatorObject.transform; 
				}
				rightWiatList.Clear();
						}
		}

		if (activeBottomPlatforms.Count <= 4 )
			this.CreatePlatforms ();
		

		if (activeLeftPlatforms.Count <= 4)
			this.CreatePlatforms ();
		
		if (activeTopPlatforms.Count <= 4)
			this.CreatePlatforms ();
		
		if (activeRightPlatforms.Count <= 4)
			this.CreatePlatforms ();

	}

	//NOT SEPERATED
	public void RemoveBottomPlatform(GameObject gobj){
		
		this.activeBottomPlatforms.Remove (gobj);
		GameObject.Destroy (gobj);
		
	}
	
	public void RemoveTopPlatform(GameObject gobj){

		this.activeTopPlatforms.Remove (gobj);
		GameObject.Destroy (gobj);
		
	}
	public void RemoveLeftPlatform(GameObject gobj){
		
		this.activeLeftPlatforms.Remove (gobj);
		GameObject.Destroy (gobj);
		
	}
	public void RemoveRightPlatform(GameObject gobj){
		
		this.activeRightPlatforms.Remove (gobj);
		GameObject.Destroy (gobj);
		
	}



	public void GeneratePlatformsTest ()
	{
		float val = Random.value; //will it be path or no path

		Vector3 lastBotPlatPos = testObject.activeBottomPlatforms [testObject.activeBottomPlatforms.Count - 1].transform.position;
		if (val < .5) {
			//Debug.Log ("np before adding platform: ");
			int platformType = ((int)Random.value) % testObject.NoPathPlatforms.Count; 
			GameObject x = (GameObject)GameObject.Instantiate (testObject.NoPathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
			x.tag = "BottomPlatform";
			testObject.activeBottomPlatforms.Add (x);
			//Debug.Log("np after addition: ");
			
		}
		else {
			int platformType = ((int)Random.value) % testObject.PathPlatforms.Count; 
			GameObject x = (GameObject)GameObject.Instantiate (testObject.PathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
			x.tag = "BottomPlatform";
			testObject.activeBottomPlatforms.Add (x);
			//this.activeBottomPlatforms.Add (
			//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity));
		} 
		
	}


	public void GeneratePlatforms ()
	{
		int np = difficulty; 
		int p = 4 - difficulty; 
		if (this.activeBottomPlatforms.Count >= 0) {
			CreatePathPlatform( bottomPlatformTag, 0, botPlatAdjustment,  new Vector3 (-14f, 0, 0) , Quaternion.identity);
			//GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [0], new Vector3 (0, -3f, 0), Quaternion.identity);
			//x.tag = bottomPlatformTag;

			//this.activeBottomPlatforms.Add (x);

		}
		if (this.activeLeftPlatforms.Count >= 0) {
			Quaternion leftRotate = Quaternion.AngleAxis (90, Vector3.forward);
			CreatePathPlatform( leftPlatformTag, leftPlatAdjustment,0 ,  new Vector3 (-14f, 0, 0) , leftRotate);
			//GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [0], new Vector3 (-3f,0f, 0), leftRotate);
			//x.tag = leftPlatformTag;

			//this.activeLeftPlatforms.Add(x);
		}
		if (this.activeTopPlatforms.Count >= 0) {
			Quaternion topRotate = Quaternion.AngleAxis(180, Vector3.forward);
			CreatePathPlatform( topPlatformTag, 0, topPlatAdjustment ,  new Vector3 (-14f, 0, 0) , topRotate);

			//GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [0], new Vector3 (0, 3f, 0), topRotate);
			//x.tag = topPlatformTag;
			//this.activeTopPlatforms.Add (x);

		}
		if (this.activeRightPlatforms.Count >= 0) {
			Quaternion rightRotate = Quaternion.AngleAxis (-90, Vector3.forward);
			CreatePathPlatform( rightPlatformTag, rightPlatAdjustment, 0 ,  new Vector3 (-14f, 0, 0) , rightRotate);

			//GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [0], new Vector3 (3f, 0, 0), rightRotate);

			//x.tag = rightPlatformTag;
			//this.activeRightPlatforms.Add(x);
		}
		


		
	}

	public void CreatePlatforms(){
				int np = difficulty; 
				int p = 4 - difficulty; 
				if (this.activeTopPlatforms.Count != 0 || this.activeRightPlatforms.Count != 0 || this.activeLeftPlatforms.Count != 0 || this.activeBottomPlatforms.Count != 0) {
						for (int s = 0; s<4; s++) {
								string nametag = "";
								switch (s) {
								case 0:
										nametag = bottomPlatformTag; 
										float val = Random.value; //will it be path or no path
										Vector3 lastBotPlatPos = this.activeTopPlatforms [this.activeTopPlatforms.Count - 1].transform.position;
										Quaternion noRotate = Quaternion.identity;
										
					
										if (val < .5) {
												np = np - 1;
												CreateNoPathPlatform (nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
						
										} else {
						
												p = p - 1;
												CreatePathPlatform (nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
						
										}
										break; 
								case 1: //Left
										nametag = leftPlatformTag; 
					
										float leftval = Random.value; //will it be path or no path
										Vector3 lastLeftPlatPos = this.activeLeftPlatforms [this.activeLeftPlatforms.Count - 1].transform.position;
					Quaternion leftRotate = Quaternion.AngleAxis (90, Vector3.forward);
										
										if (leftval < .5) {
												CreateNoPathPlatform (nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);
							
												np = np - 1;
			
										} else {

												p = p - 1;
												CreatePathPlatform (nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);

										}
										break;
								case 2: //Top
										nametag = topPlatformTag; 
					
										float topval = Random.value; //will it be path or no path
					//				Debug.Log ("Top random val: " + topval); 
					
										Vector3 lastTopPlatPos = this.activeTopPlatforms [this.activeTopPlatforms.Count - 1].transform.position;
										Quaternion topRotate = Quaternion.AngleAxis (180, Vector3.forward);

										if (np > 0) {
												np = np - 1;
												CreateNoPathPlatform (nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);

										} else {
												p = p - 1;
												CreatePathPlatform (nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);


				
										}
										break;
								case 3: //right
										nametag = rightPlatformTag; 
					
										float rightval = Random.value; //will it be path or no path
					//						Debug.Log ("Right side random val: " + rightval); 
										Vector3 lastRightPlatPos = this.activeRightPlatforms [this.activeRightPlatforms.Count - 1].transform.position;
										Quaternion rightRotate = Quaternion.AngleAxis (-90, Vector3.forward);
 										
										if (np > 0) {
												np = np - 1;
												CreateNoPathPlatform (nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);

										} else {
												p = p - 1;
												CreatePathPlatform (nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);
							

										}

										break; 
								default:
										break; 
								}
						}
				}
		}
	
		/*
	void GenerateBottomPlatfrom(int p, int np){
		string nametag = bottomPlatformTag; 
		float val = Random.value; //will it be path or no path
		Vector3 lastBotPlatPos = this.activeTopPlatforms [this.activeTopPlatforms.Count - 1].transform.position;
		Quaternion noRotate = Quaternion.identity;
		if (val < .5) {
			if (np > 0) {
				np = np - 1;
				noRotate = platformRoation;
				CreateNoPathPlatform(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
			} else {
				CreatePathPlatform(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
				/*							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
							x.tag = "BottomPlatform";
							this.activeBottomPlatforms.Add (x);

	
	*/

	//SEPERATED CODE 
	/*
	void CreateNoPathPlatform (string tagname, float xpos , float ypos, Vector3 lastzVector, Quaternion rq)
	{
		int platformType = ((int)Random.value) % testObject.NoPathPlatforms.Count; 
		GameObject z = (GameObject)GameObject.Instantiate (testObject.NoPathPlatforms [platformType], new Vector3 (xpos, ypos, lastzVector.z + 14f), rq);
		z.gameObject.tag = tagname;
		z.transform.parent = this.transform;
		
		if(tagname.Equals(bottomPlatformTag))
			testObject.activeBottomPlatforms.Add (z);
		if (tagname.Equals(rightPlatformTag))
			testObject.activeRightPlatforms.Add (z);
		if(tagname.Equals(topPlatformTag))
			testObject.activeTopPlatforms.Add(z);
		if (tagname.Equals(leftPlatformTag))
			testObject.activeLeftPlatforms.Add (z);
	}
	
	void CreatePathPlatform( string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq){
		int platformType = ((int)Random.value) % testObject.PathPlatforms.Count; 
		
		GameObject x = (GameObject)GameObject.Instantiate (testObject.PathPlatforms [platformType], new Vector3 (xpos, ypos, lastzVector.z + 14f), rq);
		x.gameObject.tag = tagname;
		x.transform.parent = this.transform;
		if(tagname.Equals(bottomPlatformTag))
			testObject.activeBottomPlatforms.Add (x);
		if (tagname.Equals(rightPlatformTag))
			testObject.activeRightPlatforms.Add (x);
		if(tagname.Equals(topPlatformTag))
			testObject.activeTopPlatforms.Add(x);
		if (tagname.Equals(leftPlatformTag))
			testObject.activeLeftPlatforms.Add (x);
	}
*/


	//NOT SEPERATED CODE

	GameObject roatatorObject; 

	void CreateNoPathPlatform (string tagname, float xpos , float ypos, Vector3 lastzVector, Quaternion rq)
	{
		int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
		GameObject z = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (xpos, ypos, lastzVector.z + 14f), rq);
		z.gameObject.tag = tagname;


		
		


		if (tagname.Equals (bottomPlatformTag)) {
			if (!TestPlatformRotate.rotating) {
				roatatorObject = GameObject.Find ("Rotator");
				this.activeBottomPlatforms.Add (z);

				//ROTATION SEPERATED
				z.transform.parent = roatatorObject.transform; 
			} else {
				z.transform.parent = this.transform;
				this.bottomWaitList.Add(z);
				this.activeBottomPlatforms.Add (z);

			}
		}
		if (tagname.Equals (rightPlatformTag)) {
			if (!TestPlatformRotate.rotating) {
				roatatorObject = GameObject.Find ("Rotator");
				this.activeRightPlatforms.Add (z);

				//ROTATION SEPERATED
				z.transform.parent = roatatorObject.transform; 
			} else {
				z.transform.parent = this.transform;
				this.rightWiatList.Add(z);
				this.activeRightPlatforms.Add (z);

			}
		}
		if (tagname.Equals (topPlatformTag)) {
			if (!TestPlatformRotate.rotating) {
				roatatorObject = GameObject.Find ("Rotator");
				this.activeTopPlatforms.Add(z);

				//ROTATION SEPERATED
				z.transform.parent = roatatorObject.transform; 
			} else {
				z.transform.parent = this.transform;
				this.topWaitList.Add(z);
				this.activeTopPlatforms.Add(z);

			}
		}
		if (tagname.Equals (leftPlatformTag)) {
			if (!TestPlatformRotate.rotating) {
				roatatorObject = GameObject.Find ("Rotator");
				this.activeLeftPlatforms.Add(z);
				
				//ROTATION SEPERATED
				z.transform.parent = roatatorObject.transform; 
			} else {
				z.transform.parent = this.transform;
				this.leftWaitList.Add(z);
				this.activeLeftPlatforms.Add(z);

			}
		}
	}
	
	void CreatePathPlatform( string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq){
				int platformType = ((int)Random.value) % this.PathPlatforms.Count; 

				GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (xpos, ypos, lastzVector.z + 14f), rq);
				x.gameObject.tag = tagname;
				//x.transform.parent = this.transform;
				//roatatorObject = GameObject.Find ("Rotator");

				//ROTATION SEPERATED
				//	x.transform.parent = roatatorObject.transform; 

				if (tagname.Equals (bottomPlatformTag)) {
						if (!TestPlatformRotate.rotating) {
								roatatorObject = GameObject.Find ("Rotator");
								this.activeBottomPlatforms.Add (x);

								//ROTATION SEPERATED
								x.transform.parent = roatatorObject.transform; 
						} else {
								x.transform.parent = this.transform;
				this.activeBottomPlatforms.Add(x);
								this.bottomWaitList.Add (x);
						}
				} else {
						if (tagname.Equals (rightPlatformTag)) {
								if (!TestPlatformRotate.rotating) {
										roatatorObject = GameObject.Find ("Rotator");
										this.activeRightPlatforms.Add (x);
				
										//ROTATION SEPERATED
										x.transform.parent = roatatorObject.transform; 
								} else {
										x.transform.parent = this.transform;
										this.rightWiatList.Add (x);
					this.activeRightPlatforms.Add (x);

								}
						} else {
								if (tagname.Equals (topPlatformTag)) {
										if (!TestPlatformRotate.rotating) {
												roatatorObject = GameObject.Find ("Rotator");
												this.activeTopPlatforms.Add (x);
				
												//ROTATION SEPERATED
												x.transform.parent = roatatorObject.transform; 
										} else {
												x.transform.parent = this.transform;
												this.topWaitList.Add (x);
						this.activeTopPlatforms.Add (x);

										}
								} else {
										if (tagname.Equals (leftPlatformTag)) {
												if (!TestPlatformRotate.rotating) {
														roatatorObject = GameObject.Find ("Rotator");
														this.activeLeftPlatforms.Add (x);
				
														//ROTATION SEPERATED
														x.transform.parent = roatatorObject.transform; 
												} else {
														x.transform.parent = this.transform;
														this.leftWaitList.Add (x);
							this.activeLeftPlatforms.Add (x);

												}
										}
								}
						}
				}
		}

}
