using UnityEngine;
using System.Collections;

public class ZoomCameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.orthographicSize -= 2F * Input.GetAxis("Mouse ScrollWheel");
		if (Camera.main.orthographicSize < 2F)
			Camera.main.orthographicSize = 2F;
		if (Camera.main.orthographicSize > 10F)
			Camera.main.orthographicSize = 10F;
	}
}
