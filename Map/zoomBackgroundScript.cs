using UnityEngine;
using System.Collections;

public class zoomBackgroundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (transform.localScale.x > 1F && transform.localScale.x < 4.9F)
			transform.localScale += (new Vector3(1F, 1F, 0) * Input.GetAxis("Mouse ScrollWheel"));
		if (transform.localScale.x < 1F)
			transform.localScale = new Vector3 (1F, 1F, 0);
		if (transform.localScale.x > 5F)
			transform.localScale = new Vector3 (5F, 5F, 0);

	}
}
