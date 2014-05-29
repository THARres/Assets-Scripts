using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SceneBattle : MonoBehaviour {

	public float     barDisplay = 0;
	public Vector2   pos = new Vector2(20, Screen.height - 40);
	public Vector2   size = new Vector2(60,20);
	public Texture2D progressBarEmpty, progressBarFull;
	public GUIStyle  bgEmpty, bgFull;


	private CharaController script;

	//public static int charNum;
	//public static Dictionary<string, string> character;

	void Start() {
		script = GameObject.Find("Alice").GetComponent<AliceController>();
	}

	void Update() {

		//if (charNum == null) {
		//	charNum = 0;
		//}
		//character = new string[charNum];
		// for this example, the bar display is linked to the current time,
		// however you would set this value based on your desired display
		// eg, the loading progress, the player's health, or whatever.
		barDisplay = script.getCharaHP() / script.getCharaMaxHP();
	}

	void OnGUI() {

		// draw the background:
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
			GUI.Box (new Rect (0,0, size.x, size.y), progressBarEmpty, bgEmpty);

			// draw the filled-in part:
			GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
				GUI.Box (new Rect (0,0, size.x, size.y), progressBarFull, bgFull);
			GUI.EndGroup ();

		GUI.EndGroup ();

	}
}