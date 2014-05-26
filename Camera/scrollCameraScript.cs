using UnityEngine;
using System.Collections;

public class ScrollCameraScript : MonoBehaviour {

	public static float camX;    // Store Camera x-coordinate to Pass Around Scripts
	public static float camY;    // Store Camera y-coordinate to Pass Around Scripts
	public static float camW;    // Store Camera Width to Pass Around Scripts
	public static float camH;    // Store Camera Height to Pass Around Scripts

	private static float tempH;  // Temporary Storage for switches and conditional check
	private static float charaX; // Store Player x-coordinate
	private static float charaY; // Store Player y-coordinate
	private static float top;    // Store Top Map Border
	private static float bottom; // Store Bottom Map Border
	private static float left;   // Store Left Map Border
	private static float right;  // Store Right Map Border

	private static AliceController script;

	// Use this for initialization
	void Start () {
		camH  = Camera.main.orthographicSize; // Half Width
		camW  = camH * camera.aspect;         // Half Height
		tempH = 0;
		script = GameObject.Find("Alice").GetComponent<AliceController>();
	}

	// Update is called once per frame
	void Update () {

		camH = Camera.main.orthographicSize;

		if (camH != tempH) {

			camW = camH * camera.aspect;

			top    = DataBackgroundScript.topMapBorder - camH;
			bottom = DataBackgroundScript.bottomMapBorder + camH;
			left   = DataBackgroundScript.leftMapBorder + camW;
			right  = DataBackgroundScript.rightMapBorder - camW;
			tempH  = camW;
		}

		camX = transform.position.x;
		camY = transform.position.y;

		charaX = script.getCharaX();
		charaY = script.getCharaY();

		if (setCamScroll()) scrollCam(script.getCharaDirection(), script.getCharaMovSpd());
		else scrollCam(checkDirection(), script.getCharaMovSpd());
	}

	bool setCamScroll() {
		return (camY < top && camY > bottom && camX > left && camX < right);
	}

	int checkDirection() {
		switch (script.getCharaDirection()) {
		case 0: // Idle
			return 0;
		case 1: // Down-Left
			return charaX > left && charaX < right ? 
				(charaY < top && charaY > bottom ? 1 : 4) : 
				(charaY < top && charaY > bottom ? 2 : 0);
		case 2: // Down
			return charaY < top && charaY > bottom ? 2 : 0;
		case 3: // Down-Right
			return charaX > left && charaX < right ? 
				(charaY < top && charaY > bottom ? 3 : 6) : 
				(charaY < top && charaY > bottom ? 2 : 0);
		case 4: // Left
			return charaX > left && charaX < right ? 4 : 0;
		case 6: // Right
			return charaX > left && charaX < right ? 6 : 0;
		case 7: // Up-Left
			return charaX > left && charaX < right ? 
				(charaY < top && charaY > bottom ? 7 : 4) : 
				(charaY < top && charaY > bottom ? 8 : 0);
		case 8: // Up
			return charaY < top && charaY > bottom ? 8 : 0;
		case 9: // Up-Right
			return charaX > left && charaX < right ? 
				(charaY < top && charaY > bottom ? 9 : 6) : 
				(charaY < top && charaY > bottom ? 8 : 0);
		default:
			return 0;
		}
	}

	void scrollCam(int d, float mS) {
		switch(d) {
		case 0: // Idle
			transform.Translate(new Vector2(0,0) * mS * Time.deltaTime);
			return;
		case 1: // Down-Left
			transform.Translate(new Vector2(-1,-1) * mS * Time.deltaTime);
			return;
		case 2: // Down
			transform.Translate(new Vector2(0,-1) * mS * Time.deltaTime);
			return;
		case 3: // Down-Right
			transform.Translate(new Vector2(1,-1) * mS * Time.deltaTime);
			return;
		case 4: // Left
			transform.Translate(new Vector2(-1,0) * mS * Time.deltaTime);
			return;
		case 6: // Right
			transform.Translate(new Vector2(1,0) * mS * Time.deltaTime);
			return;
		case 7: // Up-Left
			transform.Translate(new Vector2(-1,1) * mS * Time.deltaTime);
			return;
		case 8: // Up
			transform.Translate(new Vector2(0,1) * mS * Time.deltaTime);
			return;
		case 9: // Up-Right
			transform.Translate(new Vector2(1,1) * mS * Time.deltaTime);
			return;
		default:
			transform.Translate(new Vector2(0,0) * mS * Time.deltaTime);
			return;
		}
	}

}
