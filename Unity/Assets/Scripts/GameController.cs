using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class GameController : MonoBehaviour {
	public static int score; 

	Text scoreText; 

	float restartTimer;
	float restartDelay = 25f; 

	// Use this for initialization
	void Start () {
	
	}
	
	void Awake ()
	{
		// Set up the reference.
		GameObject stui = GameObject.Find ("ScoreTextUI");
		scoreText = stui.GetComponent<Text>();

		// Reset the score.
		score = 0;
	}
	
	
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		scoreText.text = "Score: " + score;
	}
	
	public void EndGame(){
		restartTimer += Time.deltaTime;
		
		// .. if it reaches the restart delay...
		if (restartTimer >= restartDelay) {
			// .. then reload the currently loaded level.
			Application.LoadLevel (Application.loadedLevel);
		}

		/* This code is located on the Player Health Script
		// Turn off any remaining shooting effects.
		playerShooting.DisableEffects ();
		
		// Tell the animator that the player is dead.
		anim.SetTrigger ("Die");
		
		// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
		playerAudio.clip = deathClip;
		playerAudio.Play ();
		
		// Turn off the movement and shooting scripts.
		playerMovement.enabled = false;
		playerShooting.enabled = false;
		*/
	}
}
