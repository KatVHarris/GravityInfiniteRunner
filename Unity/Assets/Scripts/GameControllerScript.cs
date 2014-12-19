using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	public GUITest guiObject; 
	private int score; 
	// Use this for initialization
	void Start () {
		Game GUIGameObject = GameObject.FindWithTag("GUI");
		score = 0;
		guiObject = GUIGameObject.GetComponent<GUITest>();
		UpdateScore();

	}
	
	// Update is called once per frame
	void UpdateScore () {
		guiObject.UpdatePrintedScore("Score: " ,score);

	}

	public void AddScore(int newScore){
		Debug.Log("Trying to Add Score");
		score += newScore;
		UpdateScore();
	}
}
