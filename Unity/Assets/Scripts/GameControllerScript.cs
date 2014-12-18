using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	public GUIText scoreText; 
	private int score; 
	// Use this for initialization
	void Start () {
		score = 0;
		//UpdateScore();
	}
	
	// Update is called once per frame
	void UpdateScore () {
		//scoreText.text = "Score: " +score;

	}

	public void AddScore(int newScore){
		Debug.Log("Trying to Add Score");
		//score += newScore;
		//UpdateScore();
	}
}
