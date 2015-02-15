using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	public GameObject PlatformController; 
	private Spawner platformControllerScript;  
	// Use this for initialization
	void Start () {
	

	}
	public void Awake(){
		//controllerScript = PlatformController.GetComponent<TestSpawner> ();
		platformControllerScript = PlatformController.GetComponent<Spawner> (); 
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		//controllerScript.RemoveBox (other.gameObject);
		string collideTag = other.tag;

		if(collideTag == "Player"){

		}


		if (collideTag == "BottomPlatform") {
			platformControllerScript.RemoveBottomPlatform(other.gameObject);
			GameController.score += 1; 
		}
		if (collideTag == "TopPlatform") {
			platformControllerScript.RemoveTopPlatform(other.gameObject);
			GameController.score += 1;
		}
		if (collideTag == "RightPlatform") {
			platformControllerScript.RemoveRightPlatform(other.gameObject);
			GameController.score += 1; 
		}
		if (collideTag == "LeftPlatform") {
			platformControllerScript.RemoveLeftPlatform(other.gameObject);
			GameController.score += 1; 
		}

		//ADD CODE TO HANDLE ENEMIES

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
