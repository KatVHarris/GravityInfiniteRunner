using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private float nextFire;
	public float fireRate;
	public Transform shotSpawn;
	public GameObject shot; 
	
	// Update is called once per frame
	void Update () {
	     
	    if (Input.GetKeyUp(KeyCode.M) && Time.time > nextFire)
        {
        	Debug.Log("Clicked");
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
	}
}
