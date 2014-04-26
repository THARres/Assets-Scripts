using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public static void activeRecursive(GameObject parent, bool active) {
		parent.SetActive(active);
		foreach (Transform child in parent.transform) {
			activeRecursive(child.gameObject, active);
		}
	}

	public static void inherentParticleEmission(GameObject parent) {
		if (parent.particleSystem) parent.particleSystem.Emit(1);
		foreach (Transform child in parent.transform) {
			inherentParticleEmission(child.gameObject);
		}
	}

}
