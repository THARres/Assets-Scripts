using UnityEngine;
using System.Collections;

public class AliceOptionController : MonoBehaviour {

	private Animator animator;       // Store Animator
	private Vector2  objectMouse;
	private bool     rotatedY;
	private bool     dollAction;
	private float    prevRotate;
	private float    currentRotate;
	private float    timer;

	/* Use this for initialization */
	void Start () {
		animator = this.GetComponent<Animator>();

		prevRotate = 0;
		currentRotate = 0;
		rotatedY = false;
		timer = 0;
	}
	
	/* Update is call once per turn */
	void Update() {

		var script = GameObject.Find("Alice").GetComponent<AliceController>();

		objectMouse = script.getCharaMousePos();
		animator.transform.Rotate(0,getRotationY(script.getCharaReverse()), getRotationZ());

		dollAction = script.getCharaNormAtk();


		if (dollAction) {
			timer += (1f / 60);
			/* Shooting every .1 sec */
			if (timer > .1f) {
				timer = 0f;
				Global.inherentParticleEmission(transform.Find("Normal Attack").gameObject);
			}
		}

		setDollMovState();
		// setMovementAnimationState

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
			animator.transform.Rotate(0,0,-prevRotate);
			prevRotate = currentRotate;
			return currentRotate;
		}
	}

	void setDollMovState() {
		// Check if Character is Processing Action
		//if (dollAction) setDollActionMovState();
		//else 
		setDollNonActionMovState();
	}

	void setDollActionMovState() {
		// Pending for Action States
	}

	void setDollNonActionMovState() {
		setDollMovingMovState();
	}

	void setDollMovingMovState() {
		setIdleMovState();
	}

	void setIdleMovState() {
		animator.Play("AliceDollStand");
	}
	
}
