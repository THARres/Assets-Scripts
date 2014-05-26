using UnityEngine;
using System.Collections;

public class DataBackgroundScript : MonoBehaviour {

	public static float topMapBorder;    // Store topMapBorder     to Pass Around Scripts
	public static float leftMapBorder;   // Store leftMapBorder    to Pass Around Scripts
	public static float bottomMapBorder; // Store bottomMapBorder  to Pass Around Scripts
	public static float rightMapBorder;  // Store rightMapBorder   to Pass Around Scripts
	public static float mapX;            // Store map x-coordinate to Pass Around Scripts
	public static float mapY;            // Store map y-coordinate to Pass Around Scripts

	// Use this for initialization
	
	void Start () {

		setMapBorder();
	}

	void setMapBorder() {

		bottomMapBorder = transform.Find("BottomRightCorner").transform.position.y;
		rightMapBorder = transform.Find("BottomRightCorner").transform.position.x;
		topMapBorder = transform.Find("TopLeftCorner").transform.position.y;
		leftMapBorder = transform.Find("TopLeftCorner").transform.position.x;

		Debug.Log("bottom = " + bottomMapBorder);
		Debug.Log("right = " + rightMapBorder);
		Debug.Log("top = " + topMapBorder);
		Debug.Log("left = " + leftMapBorder);
	}



	// Update is called once per frame
	void Update () {

		mapX = transform.position.x;
		mapY = transform.position.y;

	}
}
