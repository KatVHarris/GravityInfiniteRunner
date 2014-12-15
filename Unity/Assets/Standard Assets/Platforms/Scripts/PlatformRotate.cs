using UnityEngine;
using System.Collections;

public class PlatformRotate : MonoBehaviour {
	public bool rotating = false; 
	public float rotationAngle  = 0; 
	private Quaternion curAngle; 
	public float targetAngle = 0f; 
	const float rotationAmt = 1.5f; 
	public float rDistance = 1.0f; 
	public float rSpeed = 1.0f; 
	private float lastAngle = 0.0f; 
	private float angle = 0.0f; 
	// Use this for initialization
	void Start () {
	
	}
	int degree = 0; 


	//No Coroutine too fast
	/*
	void Update (){
		if (Input.GetKeyUp (KeyCode.H)) {
			curAngle = transform.localRotation;
			targetAngle = 90.0f;
			Rotate();
		}
	}

	protected void Rotate(){
		float step = rSpeed * Time.deltaTime; 
		transform.RotateAround (Vector3.zero, Vector3.forward, targetAngle); 
		//float orbitCircumfrance = 2F * rDistance *
	}

*/

	//Using Co Routines
	int count = 1; 
	int countRight = 1;
	int countLeft = 1; 
	int countFlip = 1; 
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Q)){


		//	angle = getNextLeft(angle);
			angle = getNextLeftAngle(angle);
		//	RotatePlatform(angle);
			Debug.Log("ANGLE: "+ angle);

			
			if(!rotating) {
				//angle = getNextLeft(angle);
				StartCoroutine(RotateMe(angle));
			}


		
		}

		if(Input.GetKeyUp(KeyCode.E)){
			
			 

			//angle = getNextRight(angle);
			angle = getNextRightAngle(angle);
			//RotatePlatform(angle);


			Debug.Log("ANGLE: "+ angle);
			if(!rotating) {
				StartCoroutine(RotateMe(angle));
			}

		}

		if(Input.GetKeyUp("space")){
			
			angle = getNextFlip(angle); 

			Debug.Log("rotating " + rotating + " next step "+ angle);
			if(!rotating) {
				StartCoroutine(RotateMe(angle));
			}
		}
	}

	float getNextLeft (float oAngle)
	{
		if (oAngle == 270) {
						oAngle = 0;
			return oAngle; 
				} else {
						oAngle = oAngle + 90; 
			return oAngle; 
				}
	}

	float getNextLeftAngle (float oAngle){
		oAngle = oAngle + 90; 
		return oAngle; 
	}

	float getNextRightAngle (float oAngle)
	{
		oAngle = oAngle - 90; 
		return oAngle; 
	}

	float getNextRight (float oAngle)
	{
		if (oAngle == 0) {
			oAngle = 270;
			return oAngle; 
		} else {
			oAngle = oAngle - 90; 
			return oAngle; 
		}
	}

	float getNextFlip (float angle)
	{
		throw new System.NotImplementedException ();
	}

	private void RotatePlatform(float nextAngle){
		transform.rotation = Quaternion.Euler (new Vector3(0, 0, nextAngle));	
	}

	IEnumerator RotateMe(float nextstep) {
		//if (rotating)		return; 
		rotating = true; 
		float step = 45 * Time.deltaTime;
		Quaternion fromAngle = transform.rotation;
		Quaternion newRotation = Quaternion.Euler (new Vector3(0, 0, nextstep));	
		while(transform.rotation != newRotation){//the original angle from the input key dot with 90 degree < !=  0 
			transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, step);//newRotation;
			yield return null;

		}
		rotating = false; 
		Debug.Log ("Rotate Done: " + rotating);
	}


}
