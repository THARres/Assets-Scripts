using UnityEngine;
using System.Collections;

public class charaController : MonoBehaviour {

	/* Character Combat Status Parameters */
	private float   charaHP;        // Store current hp values
	private float   charaMaxHP;     // Store max hp
	private float   charaBuffHP; 	  // Store buffed hp values
	private float   charaMovSpd;    // Store charaMovementSpeed

	/* Character Map Status Parameters */
	private Vector2 charaMousePos;  // Store position of mouse
	private int     charaDirection; // Store charaDirection
	private float   charaX;         // Store Chara x-coordinate
	private float   charaY;         // Store Chara y-coordinate

	/* Character Trigger Flags */
	private bool    charaDmged;  	  // Store Damage         Switch
	private bool    charaShift;     // Store shift          Switch
	private bool    charaMouse;     // Store charaMouse     Switch 
	private bool    charaAction;    // Store charaAction    Switch
	private bool    charaNormAtk;   // Store charaNormalAtk Switch
	private bool    charaReverse;   // Store charaReverse   Switch

	/* Animation */
	private Animator animator;     // Store Animator
	private bool     getSR;        // Store getStateReversed
	private bool     bDash;        // Store backDash
	private bool     fDash;        // Store frontDash
	private float    horz;         // Store Horizontal Input
	private float    vert;         // Store Vertical Input

	/* Map Border */
	private bool     setMap;       // Switch
	private float    top;          // Store Top Map Border
	private float    bottom;       // Store Bottom Map Border
	private float    left;         // Store Left Map Border
	private float    right;        // Store Right Map Border

	/* Controller: either "player" or "AI" */
	private bool     manual;       // Store Manual Switch
	private string   control;      // Store Character Control


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

		/* Set Map Border */
		setMapBorder();

		/* setCharaVariablesValues */
		setCharaVarValues();

		/* applyCharaVariablesValues */
		applyCharaVarValues();

	}

	void setMapBorder() {
		/* Setting Map Border Done Once Every Map Change */
		if (!setMap) {
			top    = dataBackgroundScript.topMapBorder;
			bottom = dataBackgroundScript.bottomMapBorder;
			left   = dataBackgroundScript.leftMapBorder;
			right  = dataBackgroundScript.rightMapBorder;
			setMap = true;
		}
	}

	void setCharaVarValues() {

		/* Store X-Y Position For Map Border Check */
		charaX = animator.transform.position.x;
		charaY = animator.transform.position.y;

		/* Attach Controller To Object, Player Or AI */
		attachController();
		
		/* set Values Based On Controller */
		switch (control) {
		case "player" :
			charaMousePos  = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			charaDirection = playerControlScript.playerDirection;
			charaShift     = playerControlScript.playerShift;
			charaDmged	   = playerControlScript.playerQ;
			charaMouse     = playerControlScript.getMouse(charaMousePos.x, charaMousePos.y, charaDirection);
			charaAction    = playerControlScript.playerAction;
			charaNormAtk   = playerControlScript.getMouseDown00();
			charaReverse   = getReverse(charaDirection, charaMouse);
			charaMovSpd    = getMovSpeed(charaDirection, charaShift, charaMouse);
			break;
		case "AI" :
			AIControlScript.getCommand(this);
			break;
		}
	}

	void applyCharaVarValues() {

		/* setHPAfterDmg*/
		if (charaDmged) applyCharaDmgedHP();

		/* setMovementAnimationState */
		setCharaMovState();

		/* setMovementAnimationSpeed */
		setCharaMovSpeed();

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

	void applyCharaDmgedHP(){
		/*currently only lose 2.5*/
		charaHP -= (float)2.5;
		Debug.Log(charaHP);
	}

	void defeated(){
		//Empty for now
	}


/*
`7MMF'   `7MF`7MMF`7MM"""Mq.MMP""MM""YMM `7MMF'   `7MF'   db     `7MMF'      
  `MA     ,V   MM   MM   `MMP'   MM   `7   MM       M    ;MM:      MM        
   VM:   ,V    MM   MM   ,M9     MM        MM       M   ,V^MM.     MM        
    MM.  M'    MM   MMmmdM9      MM        MM       M  ,M  `MM     MM        
    `MM A'     MM   MM  YM.      MM        MM       M  AbmmmqMA    MM      , 
     :MM;      MM   MM   `Mb.    MM        YM.     ,M A'     VML   MM     ,M 
      VF     .JMML.JMML. .JMM. .JMML.       `bmmmmd".AMA.   .AMMA.JMMmmmmMMM 
*/

	/*************************************************
	 *   Virtual Functions                           *
	 * Do Override for Characters                    *
	 *                                               *
	 *************************************************/


	public virtual void attachController() {
		control = "player";
	}

	public virtual float getMovSpeed(int d, bool s, bool m) {

		/**************************
		 * Default Movement:      *
		 * Idle          =  0     *
		 * Foward Walk   =  2     *
		 * Backward Walk =  1     *
		 * Froward Dash  =  5     *
		 * Backward Dash =  2.5   *
		 *                        *
		 **************************/

		return (d != 0) ? ((s) ? ((m) ? 5f : 2.5f) : ((m) ? 2f : 1f)) : 0f;
	}

	public virtual void setIdleMovState() {
	}

	public virtual void setForwardWalkMovSate() {
	}

	public virtual void setBackwardWalkMovSate() {
	}

	public virtual void setForwardDashMovState() {
	}

	public virtual void setBackwardDashMovState() {
	}

	public virtual bool isDashing() {
		return false;
	}

	public virtual IEnumerator waitFor(string animationName) {
		yield return new WaitForSeconds(0f);
	}

	public virtual IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
	}

                                                                  
		/*                                                                  
		        GGGGGGGGGGGGGEEEEEEEEEEEEEEEEEEEEEETTTTTTTTTTTTTTTTTTTTTTT
		     GGG::::::::::::GE::::::::::::::::::::ET:::::::::::::::::::::T
		   GG:::::::::::::::GE::::::::::::::::::::ET:::::::::::::::::::::T
		  G:::::GGGGGGGG::::GEE::::::EEEEEEEEE::::ET:::::TT:::::::TT:::::T
		 G:::::G       GGGGGG  E:::::E       EEEEEETTTTTT  T:::::T  TTTTTT
		G:::::G                E:::::E                     T:::::T        
		G:::::G                E::::::EEEEEEEEEE           T:::::T        
		G:::::G    GGGGGGGGGG  E:::::::::::::::E           T:::::T        
		G:::::G    G::::::::G  E:::::::::::::::E           T:::::T        
		G:::::G    GGGGG::::G  E::::::EEEEEEEEEE           T:::::T        
		G:::::G        G::::G  E:::::E                     T:::::T        
		 G:::::G       G::::G  E:::::E       EEEEEE        T:::::T        
		  G:::::GGGGGGGG::::GEE::::::EEEEEEEE:::::E      TT:::::::TT      
		   GG:::::::::::::::GE::::::::::::::::::::E      T:::::::::T      
		     GGG::::::GGG:::GE::::::::::::::::::::E      T:::::::::T      
		        GGGGGG   GGGGEEEEEEEEEEEEEEEEEEEEEE      TTTTTTTTTTT      
		*/                                                                 

	/*************************************************
	 *   Get Params                                  *
	 * Function Call :                               *
	 * get + param_name[0].uppercase + param_name[1] *
	 *                                               *
	 *************************************************/

	/* Character Combat Status Parameters */
	public float   getCharaHP() {
		return charaHP;
	}
	public float   getCharaMaxHP() {
		return charaMaxHP;
	}
	public float   getCharaBuffHP() {
		return charaBuffHP;
	}
	public float   getCharaMovSpd() {
		return charaMovSpd;
	}

	/* Character Map Status Parameters */
	public Vector2 getCharaMousePos() {
		return charaMousePos;
	}
	public int     getCharaDirection() {
		return charaDirection;
	}
	public float   getCharaX() {
		return charaX;
	}
	public float   getCharaY() {
		return charaY;
	} 

	/* Character Trigger Flags */
	public bool    getCharaDmged() {
		return charaDmged;
	}
	public bool    getCharaShift() {
		return charaShift;
	}
	public bool    getCharaMouse() {
		return charaMouse;
	}
	public bool    getCharaAction() {
		return charaAction;
	}
	public bool    getCharaNormAtk() {
		return charaNormAtk;
	}
	public bool    getCharaReverse() {
		return charaReverse;
	}

	/* Animation */
	public Animator getAnimator() {
		return animator;
	}
	public bool     getGetSR() {
		return getSR;
	}
	public bool     getBDash() {
		return bDash;
	}
	public bool     getFDash() {
		return fDash;
	}
	public float    getHorz() {
		return horz;
	}
	public float    getVert() {
		return vert;
	}

	/* Map Border - Ommitted: Get Map Border From dataBackgroundScript instead */

	/* Controller: either "player" or "AI" */
	public bool     getManual() {
		return manual;
	}
	public string   getControl() {
		return control;
	}

                                                                
		/*                                                                
		   SSSSSSSSSSSSSSS EEEEEEEEEEEEEEEEEEEEEETTTTTTTTTTTTTTTTTTTTTTT
		 SS:::::::::::::::SE::::::::::::::::::::ET:::::::::::::::::::::T
		S:::::SSSSSS::::::SE::::::::::::::::::::ET:::::::::::::::::::::T
		S:::::S     SSSSSSSEE::::::EEEEEEEEE::::ET:::::TT:::::::TT:::::T
		S:::::S              E:::::E       EEEEEETTTTTT  T:::::T  TTTTTT
		S:::::S              E:::::E                     T:::::T        
		 S::::SSSS           E::::::EEEEEEEEEE           T:::::T        
		  SS::::::SSSSS      E:::::::::::::::E           T:::::T        
		    SSS::::::::SS    E:::::::::::::::E           T:::::T        
		       SSSSSS::::S   E::::::EEEEEEEEEE           T:::::T        
		            S:::::S  E:::::E                     T:::::T        
		            S:::::S  E:::::E       EEEEEE        T:::::T        
		SSSSSSS     S:::::SEE::::::EEEEEEEE:::::E      TT:::::::TT      
		S::::::SSSSSS:::::SE::::::::::::::::::::E      T:::::::::T      
		S:::::::::::::::SS E::::::::::::::::::::E      T:::::::::T      
		 SSSSSSSSSSSSSSS   EEEEEEEEEEEEEEEEEEEEEE      TTTTTTTTTTT      
		                                                                */

	/*************************************************
	 *   Set Params                                  *
	 * Function Call :                               *
	 * set + param_name[0].uppercase + param_name[1] *
	 *                                               *
	 *************************************************/

	/* Character Combat Status Parameters */
	public float   setCharaHP(float num) {
		charaHP = num;
		return charaHP;
	}
	public float   setCharaMaxHP(float num) {
		charaMaxHP = num;
		return charaMaxHP;
	}
	public float   setCharaBuffHP(float num) {
		charaBuffHP = num;
		return charaBuffHP;
	}
	public float   setCharaMovSpd(float num) {
		charaMovSpd = num;
		return charaMovSpd;
	}

	/* Character Map Status Parameters */
	public Vector2 setCharaMousePos(Vector2 vec) {
		charaMousePos = vec;
		return charaMousePos;
	}
	public int     setCharaDirection(int num) {
		charaDirection = num;
		return charaDirection;
	}
	public float   setCharaX(float num) {
		charaX = num;
		return charaX;
	}
	public float   setCharaY(float num) {
		charaY = num;
		return charaY;
	} 

	/* Character Trigger Flags */
	public bool    setCharaDmged(bool trueFalse) {
		charaDmged = trueFalse;
		return charaDmged;
	}
	public bool    setCharaShift(bool trueFalse) {
		charaShift = trueFalse;
		return charaShift;
	}
	public bool    setCharaMouse(bool trueFalse) {
		charaMouse = trueFalse;
		return charaMouse;
	}
	public bool    setCharaAction(bool trueFalse) {
		charaAction = trueFalse;
		return charaAction;
	}
	public bool    setCharaNormAtk(bool trueFalse) {
		charaNormAtk = trueFalse;
		return charaNormAtk;
	}
	public bool    setCharaReverse(bool trueFalse) {
		charaReverse = trueFalse;
		return charaReverse;
	}

	/* Animation */
	public Animator setAnimator(Animator anim) {
		animator = anim;
		return animator;
	}
	public bool     setGetSR(bool trueFalse) {
		getSR = trueFalse;
		return getSR;
	}
	public bool     setBDash(bool trueFalse) {
		bDash = trueFalse;
		return bDash;
	}
	public bool     setFDash(bool trueFalse) {
		fDash = trueFalse;
		return fDash;
	}
	public float    setHorz(float num) {
		horz = num;
		return horz;
	}
	public float    setVert(float num) {
		vert = num;
		return vert;
	}

	/* Map Border - Ommitted: Map Border Mustn't Be Changed */

	/* Controller: either "player" or "AI" */
	public bool     setManual(bool trueFalse) {
		manual = trueFalse;
		return manual;
	}
	public string   setControl(string s) {
		control = s;
		return control;
	}

}