using UnityEngine;
using System.Collections;

public class Alice_Movement : MonoBehaviour {

	public static Vector2 charaMousePos;  // Store Position of Mouse  to Pass Around Scripts
	public static int     charaDirection; // Store charaDirection     to Pass Around Scripts
	public static bool    charaShift;     // Store shift              to Pass Around Scripts
	public static bool    charaDmged;  	  // Store whether dmg taken  to Pass Around Scripts
	public static bool    charaMouse;     // Store charaMouse         to Pass Around Scripts
	public static bool    charaAction;    // Store charaAction        to Pass Around Scripts
	public static bool    charaReverse;   // Store charaReverse       to Pass Around Scripts
	public static float   charaMovSpd;    // Store charaMovementSpeed to Pass Around Scripts
	public static float   charaX;         // Store Chara x-coordinate to Pass Around Scripts
	public static float   charaY;         // Store Chara y-coordinate to Pass Around Scripts
	public static float   charaHP;		  // Store current hp values  to Pass Around Scripts
	public static float   charaMaxHP;	  // Store max hp 		      to Pass Around Scripts
	public static float   charaBuffHP; 	  // Store buffed hp values	  to Pass Around Scripts
	public static string  control;        // Store Character Control  to Pass Around Scripts

	private static Animator animator;     // Store Animator
	private static bool     getSR;        // Store getStateReversed
	private static bool     bDash;        // Store backDash
	private static bool     fDash;        // Store frontDash
	private static float    horz;         // Store Horizontal Input
	private static float    vert;         // Store Vertical Input

	private static bool     setMap;       // Switch
	private static float    top;          // Store Top Map Border
	private static float    bottom;       // Store Bottom Map Border
	private static float    left;         // Store Left Map Border
	private static float    right;        // Store Right Map Border

	/* Use this for initialization */
	void Start() { 
		animator = this.GetComponent<Animator>();
		getSR = false;
		bDash = false;
		fDash = false;
		charaReverse = false;
		charaMaxHP = 10; //base hp
		charaBuffHP = 0; //amount of hp received from buff
		charaHP = charaMaxHP + charaBuffHP; //current total
	}

	/* Update is call once per turn */
	void Update() {

		if (!setMap) {
			top    = dataBackgroundScript.topMapBorder;
			bottom = dataBackgroundScript.bottomMapBorder;
			left   = dataBackgroundScript.leftMapBorder;
			right  = dataBackgroundScript.rightMapBorder;
			setMap = true;
		}

		charaX = animator.transform.position.x;
		charaY = animator.transform.position.y;

		/* attach controller to object, player or AI */
		attachController();

		/* setCharaVariablesValues */
		setCharaVarValues();

		/* setHPAfterDmg*/
		if (charaDmged) {
			setCharaDmgedHP();
		}

		/* setMovementAnimationState */
		setCharaMovState();

		/* setMovementAnimationSpeed */
		setCharaMovSpeed();
	}

	void attachController() {
		control = "player";
	}

	void setCharaVarValues() {
		switch (control) {
		case "player" :
			charaMousePos  = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			charaDirection = playerControlScript.playerDirection;
			charaShift     = playerControlScript.playerShift;
			charaDmged	   = playerControlScript.playerQ;
			charaMouse     = playerControlScript.getMouse(charaMousePos.x, charaMousePos.y, charaDirection);
			charaAction    = playerControlScript.playerAction;
			charaReverse   = getReverse(charaDirection, charaMouse);
			charaMovSpd    = getMovSpeed(charaDirection, charaShift, charaMouse);
			break;
		case "AI" :
			/* AI Controller Pending */
			break;
		}
	}

	bool getReverse(int d, bool m) {
		/*Check if sprite needs to be reversed or not */
		switch (d) {
		case 0: // Idle
			return charaReverse;
		case 1: // Down-Left
			return m;
		case 2: // Down
			return charaMousePos.x < 0;
		case 3: // Down-Right
			return !m;
		case 4: // Left
			return m;
		case 6: // Right
			return !m;
		case 7: // Up-Left
			return m;
		case 8: // Up
			return charaMousePos.x < 0;
		case 9: // Up-Right
			return !m;
		default:
			return charaReverse;
		}
	}

	float getMovSpeed(int d, bool s, bool m) {

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

	void setCharaMovState() {
		/* Set if Sprite needs to be reversed */
		animator.transform.Rotate(0, getRotation(charaReverse), 0);
		/* Check if Character is Processing Action */
		if (charaAction) setCharaActionMovState();
		else setCharaNonActionMovState();
	}

	void setCharaActionMovState() {
		// Pending for Action States
	}

	void setCharaNonActionMovState() {
		/* Check if Character is idle */
		if (charaDirection == 0) setIdleMovState();
		else setCharaMovingMovState();
	}

	void setCharaMovingMovState() {
		/* Check if Character is moving to position of mouse */
		if (charaMouse) setCharaForwardMovState();
		else setCharaBackwardMovState();
	}

	void setCharaForwardMovState() {
		/* Check if Character is dashing */
		if (charaShift) setForwardDashMovState();
		else setForwardWalkMovSate();
	}

	void setCharaBackwardMovState() {
		/* Check if Character is dashing */
		if (charaShift) setBackwardDashMovState();
		else setBackwardWalkMovSate();
	}

	void setIdleMovState() {
		/* isDashing() is to finish pre#, post# dashing animation */
		if (!isDashing()) animator.Play("AliceStand");
	}

	void setForwardWalkMovSate() {
		if (!isDashing()) animator.Play("AliceWalkFront");
	}

	void setBackwardWalkMovSate() {
		if (!isDashing()) animator.Play("AliceWalkBack");
	}

	void setForwardDashMovState() {
		if (fDash) animator.Play("AliceDashFrontLoop");
		else if (!isDashing()) StartCoroutine(waitFor("AliceDashFrontStart"));
	}

	void setBackwardDashMovState() {
		if (bDash) animator.Play("AliceDashBackLoop");
		else if (!isDashing()) StartCoroutine(waitFor("AliceDashBackStart"));
	}

	int getRotation(bool r) {

		/************************************************************
		 * Rotation is by 180 degree on y axis                      *
		 * Return 180 to rotate                                     *
		 * Return 0 to keep position state                          *
		 * getSR is used to check whether rotation is needed or not *
		 *                                                          *
		 ************************************************************/
		
		if (r)
			if (getSR) {
				return 0;
			} else {
				getSR = true;
				return 180;
			}
		else
			if (getSR) {
				getSR = false;
				return 180;
			} else {
				return 0;
			}
	}

	bool isDashing() {
		if (fDash) {
			StartCoroutine(waitFor("AliceDashFrontFinish"));
			return true;
		}
		if (bDash) {
			StartCoroutine(waitFor("AliceDashBackFinish"));
			return true;
		}
		return false;
	}

	IEnumerator waitFor(string animationName) {
		switch (animationName) {
		case "AliceDashFrontStart":
			animator.Play("AliceDashFrontStart");
			yield return StartCoroutine(WaitAndPrint(0.167F));
			fDash = true;
			break;
		case "AliceDashFrontFinish":
			animator.Play("AliceDashFrontFinish");
			yield return StartCoroutine(WaitAndPrint(0.250F));
			fDash = false;
			break;
		case "AliceDashBackStart":
			animator.Play("AliceDashBackStart");
			yield return StartCoroutine(WaitAndPrint(0.167F));
			bDash = true;
			break;
		case "AliceDashBackFinish":
			animator.Play("AliceDashBackFinish");
			yield return StartCoroutine(WaitAndPrint(0.167F));
			bDash = false;
			break;
		default:
			yield return new WaitForSeconds (0f);
			break;
		}
	}

	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
	}

	void setCharaMovSpeed() {
		if (charaNotNextToCorner()) moveChara(charaDirection, charaMovSpd);
		else moveChara(checkDirection(), charaMovSpd);
	}

	bool charaNotNextToCorner() {
		return (charaY < top && charaY > bottom && charaX > left && charaX < right);
	}

	int checkDirection() {
		switch (charaDirection) {
		case 0: // Idle
			return 0;
		case 1: // Down-Left
			return charaX > left ? 
				(charaY > bottom ? 1 : 4) : 
				(charaY > bottom ? 2 : 0);
		case 2: // Down
			return charaY > bottom ? 2 : 0;
		case 3: // Down-Right
			return charaX < right ? 
				(charaY > bottom ? 3 : 6) : 
				(charaY > bottom ? 2 : 0);
		case 4: // Left
			return charaX > left ? 4 : 0;
		case 6: // Right
			return charaX < right ? 6 : 0;
		case 7: // Up-Left
			return charaX > left ? 
				(charaY < top ? 7 : 4) : 
				(charaY < top ? 8 : 0);
		case 8: // Up
			return charaY < top ? 8 : 0;
		case 9: // Up-Right
			return charaX < right ? 
				(charaY < top ? 9 : 6) : 
				(charaY < top ? 8 : 0);
		default:
			return 0;
		}
	}

	void moveChara(int d, float mS) {

		if (charaReverse)

		switch(d) {
		case 0: // Idle
			transform.Translate(new Vector2(0,0) * mS * Time.deltaTime);
			return;
		case 1: // Down-Left
			transform.Translate(new Vector2(1,-1) * mS * Time.deltaTime);
			return;
		case 2: // Down
			transform.Translate(new Vector2(0,-1) * mS * Time.deltaTime);
			return;
		case 3: // Down-Right
			transform.Translate(new Vector2(-1,-1) * mS * Time.deltaTime);
			return;
		case 4: // Left
			transform.Translate(new Vector2(1,0) * mS * Time.deltaTime);
			return;
		case 6: // Right
			transform.Translate(new Vector2(-1,0) * mS * Time.deltaTime);
			return;
		case 7: // Up-Left
			transform.Translate(new Vector2(1,1) * mS * Time.deltaTime);
			return;
		case 8: // Up
			transform.Translate(new Vector2(0,1) * mS * Time.deltaTime);
			return;
		case 9: // Up-Right
			transform.Translate(new Vector2(-1,1) * mS * Time.deltaTime);
			return;
		default:
			transform.Translate(new Vector2(0,0) * mS * Time.deltaTime);
			return;
		}

		else

		switch(d) {
		case 0: // Idle
			transform.Translate(new Vector2(0,0) * mS * Time.deltaTime);
			return;
		case 1: // Down-Left
			transform.Translate(new Vector2(-1,-1) * mS * Time.deltaTime);
			return;
		case 2: // Down
			transform.Translate(new Vector2(0,-1) * mS * Time.deltaTime);
			return;
		case 3: // Down-Right
			transform.Translate(new Vector2(1,-1) * mS * Time.deltaTime);
			return;
		case 4: // Left
			transform.Translate(new Vector2(-1,0) * mS * Time.deltaTime);
			return;
		case 6: // Right
			transform.Translate(new Vector2(1,0) * mS * Time.deltaTime);
			return;
		case 7: // Up-Left
			transform.Translate(new Vector2(-1,1) * mS * Time.deltaTime);
			return;
		case 8: // Up
			transform.Translate(new Vector2(0,1) * mS * Time.deltaTime);
			return;
		case 9: // Up-Right
			transform.Translate(new Vector2(1,1) * mS * Time.deltaTime);
			return;
		default:
			transform.Translate(new Vector2(0,0) * mS * Time.deltaTime);
			return;
		}

	}

	void setCharaDmgedHP(){
		/*currently only lose 2.5*/
		charaHP -= (float)2.5;
		Debug.Log(charaHP);
	}

	void defeated(){
		//Empty for now
	}
}
