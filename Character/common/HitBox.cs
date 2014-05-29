using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {

	private float   fixedZ;
	private Vector3 coord;

	private CharaController script;

	void Start() {

		script = transform.parent.gameObject.GetComponent<CharaController>();
		fixedZ = -4f;

	}

	void Update() {
		if (transform.position.z != fixedZ) {
			coord = transform.position;
			coord.z = fixedZ;
			transform.position = coord;
		}
	}

	void OnParticleCollision(GameObject test) {
		Debug.Log("Got hit");
		script.applyCharaDmgedHP();
	}

}