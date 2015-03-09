using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class GameController : MonoBehaviour {
	public static int score; 

	Text scoreText;

    PlayerHealthController playerHealth;
    GameObject player;
    GameObject platformController; 
    TestSpawner testSpawner;
    public bool gameended = false; 

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
        platformController = GameObject.Find("PlatformController");
        testSpawner = platformController.GetComponent<TestSpawner>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealthController>();

        // Reset the score.
        score = 0;
	}
	
	
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		scoreText.text = "Score: " + score;

        if (playerHealth.currentHealth <= 0 && !gameended)
            EndGame();
	}
	
	public void EndGame(){
        gameended = true; 
        if (PlayerHealthController.instantDeath)
        {
            EndGameInstantly();
        }
        else
        {
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                Application.LoadLevel(Application.loadedLevel);
            }

            player.GetComponent<FirstPersonCharacter>().enabled = false;
            player.rigidbody.useGravity = false;
            //player.GetComponent<Shoot>().enabled = false; 

            //Destroy all platforms
            testSpawner.StopMovement();

            //Destory Enemies
            //Destory Items


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

    void EndGameInstantly()
    {
        restartTimer += Time.deltaTime;

        // .. if it reaches the restart delay...
        if (restartTimer >= restartDelay)
        {
            // .. then reload the currently loaded level.
            Application.LoadLevel(Application.loadedLevel);
        }

        player.GetComponent<FirstPersonCharacter>().enabled = false;
        //player.rigidbody.useGravity = false;

        //Destroy all platforms
        testSpawner.StopMovement();
    }
}
