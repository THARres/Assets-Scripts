using UnityEngine;
using System.Collections;

public class CirnoOptionController : MonoBehaviour {

	private Animator animator;       // Store Animator
	private Vector2  objectMouse;
	private bool     rotatedY;
	private bool     optionAction;
	private float    prevRotate;
	private float    currentRotate;
	private float    timer;	

	/* Use this for initialization */
	void Start () {
		//animator = this.GetComponent<Animator>();

		prevRotate = 0;
		currentRotate = 0;
		rotatedY = false;
		timer = 0;
	}
	
	/* Update is call once per turn */
	void Update() {

		var script = GameObject.Find("Cirno").GetComponent<CirnoController>();

		objectMouse = script.getCharaMousePos();
		transform.Rotate(0,getRotationY(script.getCharaReverse()), getRotationZ());

		optionAction = script.getCharaNormAtk();

		if (optionAction) {
			timer += (1f / 60);
			/* Shooting every .1 sec */
			if (timer > .1f) {
				timer = 0f;
				Global.inherentParticleEmission(transform.Find("Normal Attack").gameObject);
			}
		}
	}

	float getRotationY(bool r) {
		if (r)
			if (rotatedY) {
				return 0;
			} else {
				rotatedY = true;
				return -180;
			}
		else
			if (rotatedY) {
				rotatedY = false;
				return -180;
			} else {
				return 0;
			}
	}

	float getRotationZ() {
		currentRotate = Mathf.Atan2(objectMouse.y, objectMouse.x) * Mathf.Rad2Deg;

		if (prevRotate == currentRotate) {
			return 0;
		} else {
			transform.Rotate(0,0,-prevRotate);
			prevRotate = currentRotate;
			return currentRotate;
		}
	}
	
}
