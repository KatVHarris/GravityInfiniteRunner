using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	public GameObject PlatformController; 
	private Spawner platformControllerScript;  

	// Use this for initialization
	void Start () {
		gameObject.tag = "Smelly";
	}
	public void Awake(){
		//controllerScript = PlatformController.GetComponent<TestSpawner> ();
		platformControllerScript = PlatformController.GetComponent<Spawner> (); 
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Destroyer tag: " + gameObject.tag);
		//controllerScript.RemoveBox (other.gameObject);
		string collideTag = "";
		Debug.Log ("ran into... " + other.gameObject.tag);
		if (other.gameObject.transform.parent) {
						collideTag = other.gameObject.transform.parent.tag;
				} else {
						collideTag = other.tag;
				}
		if(collideTag == "Player"){
			Debug.Break();
		}

		if (collideTag == "BottomPlatform") {
			platformControllerScript.RemoveBottomPlatform(other.gameObject);
			Debug.Log("Trying to Destroy Bottom");
		}
		if (collideTag == "TopPlatform") {
			platformControllerScript.RemoveTopPlatform(other.gameObject);
			Debug.Log("Trying to Destroy Top");
		}
		if (collideTag == "RightPlatform") {
			platformControllerScript.RemoveRightPlatform(other.gameObject);
			Debug.Log("Trying to Destroy Right");
		}
		if (collideTag == "LeftPlatform") {
			platformControllerScript.RemoveLeftPlatform(other.gameObject);
			Debug.Log("Trying to Destroy Left");
		}

//		if(other.gameObject.transform.parent){
//			Destroy(other.gameObject.transform.parent.gameObject);
//		}
//		else{
//			controllerScript = PlatformController.GetComponent<Spawner> ();
//			controllerScript.RemovePlatform(other.gameObject);
			//Destroy(other.gameObject);
//		}

		//controllerScript.RemovePlatform (other.gameObject);*/
	}
}
