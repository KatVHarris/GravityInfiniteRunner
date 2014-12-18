using UnityEngine;
using System.Collections;

public class ShotMovement : MonoBehaviour {

	public float speed; 

	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
	}
}
