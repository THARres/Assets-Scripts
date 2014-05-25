using UnityEngine;
using System.Collections;

public class CirnoAttackController : MonoBehaviour {

	private Vector2 objectMouse; // Store mouse position based on character
	private bool rotatedY;
	private float prevRotate;
	private float currentRotate;
	
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {

		objectMouse = GameObject.Find("Cirno").GetComponent<CirnoController>().getCharaMousePos();
		currentRotate =  -Mathf.Atan2(objectMouse.y, objectMouse.x) * Mathf.Rad2Deg;

		//Rotate All Child Objects
		foreach (Transform child in transform) {
			child.particleSystem.startRotation = currentRotate * Mathf.Deg2Rad;
		}
	}
}