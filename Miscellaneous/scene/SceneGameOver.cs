using UnityEngine;
using System.Collections;

public class SceneGameOver : MonoBehaviour {

	public int buttonWidth = 200;
	public int buttonHeight = Screen.height / 8;
	public int spacing = Screen.height / 8;

	public string str;
	
	void Start() {
		/* Set BackGround */
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Touhou-background/gensokyonewmap");
  }

	void OnGUI () {

		GUILayout.BeginArea(new Rect ((Screen.width - buttonWidth) / 2, 
		                    Screen.height / 6, buttonWidth, 400));

			if (GUILayout.Button("Rematch", GUILayout.Height(buttonHeight))) {
				Application.LoadLevel("SceneBattle");
			}
			GUILayout.Space(spacing);
			if (GUILayout.Button("Load", GUILayout.Height(buttonHeight))) {
				// Implementation Pending
			}

			GUILayout.Space(spacing);
			if (GUILayout.Button("Title", GUILayout.Height(buttonHeight))) {
				Application.LoadLevel("SceneTitle");
			}
		GUILayout.EndArea();
	}
}
