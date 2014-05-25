using UnityEngine;
using System.Collections;

public class AliceController : charaController {

	public override void attachController() {
		setControl("player");
	}
	
	public override float getMovSpeed(int d, bool s, bool m) {

		/**********************
		 * Alice Movement:    *
		 * Idle          =  0 *
		 * Foward Walk   =  3 *
		 * Backward Walk =  1 *
		 * Froward Dash  = 10 *
		 * Backward Dash =  5 *
		 *                    *
		 **********************/

		return (d != 0) ? ((s) ? ((m) ? 10f : 5f) : ((m) ? 3f : 1f)) : 0f;
	}

	public override void setIdleMovState() {
		/* isDashing() is to finish pre#, post# dashing animation */
		if (!isDashing()) getAnimator().Play("AliceStand");
	}

	public override void setForwardWalkMovSate() {
		if (!isDashing()) getAnimator().Play("AliceWalkFront");
	}

	public override void setBackwardWalkMovSate() {
		if (!isDashing()) getAnimator().Play("AliceWalkBack");
	}

	public override void setForwardDashMovState() {
		if (getFDash()) getAnimator().Play("AliceDashFrontLoop");
		else if (!isDashing()) StartCoroutine(waitFor("AliceDashFrontStart"));
	}

	public override void setBackwardDashMovState() {
		if (getBDash()) getAnimator().Play("AliceDashBackLoop");
		else if (!isDashing()) StartCoroutine(waitFor("AliceDashBackStart"));
	}

	public override bool isDashing() {
		if (getFDash()) {
			StartCoroutine(waitFor("AliceDashFrontFinish"));
			return true;
		}
		if (getBDash()) {
			StartCoroutine(waitFor("AliceDashBackFinish"));
			return true;
		}
		return false;
	}

	public override IEnumerator waitFor(string animationName) {
		switch (animationName) {
		case "AliceDashFrontStart":
			getAnimator().Play("AliceDashFrontStart");
			yield return StartCoroutine(WaitAndPrint(0.167F));
			setFDash(true);
			break;
		case "AliceDashFrontFinish":
			getAnimator().Play("AliceDashFrontFinish");
			yield return StartCoroutine(WaitAndPrint(0.250F));
			setFDash(false);
			break;
		case "AliceDashBackStart":
			getAnimator().Play("AliceDashBackStart");
			yield return StartCoroutine(WaitAndPrint(0.167F));
			setBDash(true);
			break;
		case "AliceDashBackFinish":
			getAnimator().Play("AliceDashBackFinish");
			yield return StartCoroutine(WaitAndPrint(0.167F));
			setBDash(false);
			break;
		default:
			yield return new WaitForSeconds (0f);
			break;
		}
	}
}
