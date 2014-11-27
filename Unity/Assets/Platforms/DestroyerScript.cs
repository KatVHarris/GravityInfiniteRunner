using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour
{

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			Debug.Break ();
			return;
		}

		//Destory object I encounter, and it's parents
		if (other.gameObject.transform.parent) {
			Destroy (other.gameObject.transform.parent.gameObject);
		} else {
			Destroy (other.gameObject);
		}
	}
}
