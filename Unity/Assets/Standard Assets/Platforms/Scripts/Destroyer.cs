using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	public GameObject PlatformController; 
	private Spawner controllerScript; 

	// Use this for initialization
	void Start () {
		gameObject.tag = "Smelly";
	}
	public void Awake(){
		controllerScript = PlatformController.GetComponent<Spawner> ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Destroyer tag: " + gameObject.tag);
		Debug.Log ("ran into... " + other.gameObject.tag);
		if(other.tag == "Player"){
			Debug.Break();
		}
		if (other.gameObject.tag == "BottomPlatform") {
			controllerScript.RemoveBottomPlatform(other.gameObject);
			Debug.Log("Trying to Destroy Bottom");
		}
		if (other.tag == "TopPlatform") {
			controllerScript.RemoveTopPlatform(other.gameObject);
			Debug.Log("Trying to Destroy Top");
		}
		if (other.tag == "RightPlatform") {
			controllerScript.RemoveRightPlatform(other.gameObject);
			Debug.Log("Trying to Destroy Right");
		}
		if (other.tag == "LeftPlatform") {
			controllerScript.RemoveLeftPlatform(other.gameObject);
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

		//controllerScript.RemovePlatform (other.gameObject);
	}
}
