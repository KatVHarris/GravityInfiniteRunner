using UnityEngine;
using System.Collections;
using System;

public class Shoot : MonoBehaviour {

	private float nextFire;
	public float fireRate = 1f;
	public Transform shotSpawn;
	public GameObject shot; 
	GameObject currentGo; 
	GameObject go;
	private EffectSettings effectSettings;
	private GameObject Target;
	private bool isDay, isHomingMove;
	private float prefabSpeed = 10;
	private bool isReadyEffect= true; 
	private bool isReadyDefaulBall;

	void Start(){
		go = GameObject.Find ("ShotSpawner");
		GetTarget();

		//Get shot from inventory...
		//InstanceEffect(transform.position);

	}
	
	// Update is called once per frame
	void Update () {


		GetTarget();
	    if (Input.GetKeyUp(KeyCode.M) && Time.time > nextFire)
        {



			//Get shot from inventory...
			InstanceEffect(go.transform.position);
        	Debug.Log("Clicked");
            nextFire = Time.time + fireRate;
            //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			//InstanceEffect(transform.position);
			if (isReadyEffect) {
				isReadyEffect = false;
				currentGo.SetActive(true);
			}

        }
        
	}

	private void GetTarget(){
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
		{
			Debug.Log("Targeting");
			Collider target = hit.collider; // What did I hit?
			float distance = hit.distance; // How far out?
			Vector3 location = hit.point; // Where did I make impact?
			Target = hit.collider.gameObject; // What's the GameObject?
			if(hit.collider.tag == "Enemy"){
				Debug.Log("Has Target");
			}
		}
	}

	private void InstanceEffect(Vector3 pos)
	{
		currentGo = Instantiate(shot, pos, shot.transform.rotation) as GameObject;
		effectSettings = currentGo.GetComponent<EffectSettings>();
		effectSettings.Target = Target;
		if (isHomingMove) effectSettings.IsHomingMove = isHomingMove;
		prefabSpeed = effectSettings.MoveSpeed;
		effectSettings.EffectDeactivated+=effectSettings_EffectDeactivated;
		currentGo.transform.parent = Target.transform;//transform;
		//effectSettings.CollisionEnter += (n, e) => { Debug.Log(e.Hit.transform.name); };
	}

	void effectSettings_EffectDeactivated(object sender, EventArgs e)
	{
		currentGo.transform.position = transform.position;// GetInstancePosition(GuiStats[current]);
		isReadyEffect = true;
	}
}




