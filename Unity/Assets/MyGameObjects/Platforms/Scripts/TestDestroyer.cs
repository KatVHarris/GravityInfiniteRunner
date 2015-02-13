using UnityEngine;
using System.Collections;

public class TestDestroyer : MonoBehaviour {
	
	public GameObject PlatformController; 
	private TestSpawner controllerScript; 
	
	// Use this for initialization
	void Start () {
	}
	public void Awake(){
		controllerScript = PlatformController.GetComponent<TestSpawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		Debug.Log ("Destroyer tag: " + gameObject.tag);
		controllerScript.RemoveBox (other.gameObject);	
	}
}
