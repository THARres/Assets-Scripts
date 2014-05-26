using UnityEngine;
using System.Collections;

public class AliceOptionController : CharaOptionController {

	
	public override void additionalStart() {
		setAnimator(this.GetComponent<Animator>());
	}

	public override void additionalUpdate() {
		setDollMovState();
	}

	public override CharaController getCharaController() {
		return transform.parent.gameObject.GetComponent<AliceController>();
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
		getAnimator().Play("AliceDollStand");
	}
	
}
