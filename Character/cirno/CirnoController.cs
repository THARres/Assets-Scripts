using UnityEngine;
using System.Collections;

public class CirnoController : CharaController {

	public override void attachController() {
		setControl("AI");
	}

	public override float getMovSpeed(int d, bool s, bool m) {

		/************************
		 * Cirno Movement:      *
		 * Idle          =  0   *
		 * Foward Walk   =  3.5 *
		 * Backward Walk =  2   *
		 * Froward Dash  = 12   *
		 * Backward Dash =  5.5 *
		 *                      *
		 ************************/

		return (d != 0) ? ((s) ? ((m) ? 12f : 5.5f) : ((m) ? 3.5f : 2f)) : 0f;
	}

	public override void setIdleMovState() {
		/* isDashing() is to finish pre#, post# dashing animation */
		if (!isDashing()) getAnimator().Play("CirnoStand");
	}

	public override void setForwardWalkMovSate() {
		if (!isDashing()) getAnimator().Play("CirnoWalkFront");
	}

	public override void setBackwardWalkMovSate() {
		if (!isDashing()) getAnimator().Play("CirnoWalkBack");
	}

	public override void setForwardDashMovState() {
		if (getFDash()) getAnimator().Play("CirnoDashFrontLoop");
		else if (!isDashing()) StartCoroutine(waitFor("CirnoDashFrontStart"));
	}

	public override void setBackwardDashMovState() {
		if (getBDash()) getAnimator().Play("CirnoDashBackLoop");
		else if (!isDashing()) StartCoroutine(waitFor("CirnoDashBackStart"));
	}

	public override bool isDashing() {
		if (getFDash()) {
			StartCoroutine(waitFor("CirnoDashFrontFinish"));
			return true;
		}
		if (getBDash()) {
			StartCoroutine(waitFor("CirnoDashBackFinish"));
			return true;
		}
		return false;
	}

	public override IEnumerator waitFor(string animationName) {
		switch (animationName) {
		case "CirnoDashFrontStart":
			getAnimator().Play("CirnoDashFrontStart");
			yield return StartCoroutine(WaitAndPrint(0.333F));
			setFDash(true);
			break;
		case "CirnoDashFrontFinish":
			getAnimator().Play("CirnoDashFrontFinish");
			yield return StartCoroutine(WaitAndPrint(0.333F));
			setFDash(false);
			break;
		case "CirnoDashBackStart":
			getAnimator().Play("CirnoDashBackStart");
			yield return StartCoroutine(WaitAndPrint(0.167F));
			setBDash(true);
			break;
		case "CirnoDashBackFinish":
			getAnimator().Play("CirnoDashBackFinish");
			yield return StartCoroutine(WaitAndPrint(0.167F));
			setBDash(false);
			break;
		default:
			yield return new WaitForSeconds (0f);
			break;
		}
	}

}
