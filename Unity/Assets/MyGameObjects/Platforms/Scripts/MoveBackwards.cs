using UnityEngine;
using System.Collections;

public class MoveBackwards : MonoBehaviour {
	public float backspeed = 6.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.back * Time.deltaTime * backspeed);
	}
}
