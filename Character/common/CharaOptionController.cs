using UnityEngine;
using System.Collections;

public class CharaOptionController : MonoBehaviour {

	private Animator animator;
	private Vector2  objectMouse;
	private bool     rotatedY;
	private bool     optionAction;
	private float    prevRotate;
	private float    currentRotate;
	private float    normAtkTimer;
	private float    timer;

	private CharaController script;

	/* Use this for initialization */
	void Start () {

		rotatedY = false;
		prevRotate = 0;
		currentRotate = 0;
		normAtkTimer = 0.1f;
		timer = 0;

		script = getCharaController();

		additionalStart();

	}
	
	/* Update is called once per frame */
	void Update () {

		/* setCharaVariablesValues */
		setControllerValues();

		/* applyCharaVariablesValues */
		applyControllerValues();

		additionalUpdate();
	}

	void setControllerValues() {

		objectMouse = script.getCharaMousePos();
		optionAction = script.getCharaNormAtk();
	}

	void applyControllerValues() {

		transform.Rotate(0,getRotationY(script.getCharaReverse()), getRotationZ());

		if (optionAction) {
			timer += Time.deltaTime;
			/* Shooting every .1 sec */
			if (timer > normAtkTimer) {
				applyNormalAttack();
				timer = 0f;
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

	void applyNormalAttack() {
		Global.inherentParticleEmission(transform.Find("Normal Attack").gameObject);
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

	/* If Extra Stuff Required */
	public virtual void additionalStart() {}

	/* If Extra Stuff Required */
	public virtual void additionalUpdate() {}

	public virtual CharaController getCharaController() {
		return GetComponent<CharaController>();
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

	public Animator getAnimator() {
		return animator;
	}
	public Vector2  getObjectMouse() {
		return objectMouse;
	}
	public bool     getRotatedY() {
		return rotatedY;
	}
	public bool     getOptionAction() {
		return optionAction;
	}
	public float    getPrevRotate() {
		return prevRotate;
	}
	public float    getCurrentRotate() {
		return currentRotate;
	}
	public float    getNormAtkTimer() {
		return normAtkTimer;
	}
	public float    getTimer() {
		return timer;
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

	public Animator setAnimator(Animator anim) {
		animator = anim;
		return animator;
	}
	public Vector2  setObjectMouse(Vector2 vec) {
		objectMouse = vec;
		return objectMouse;
	}
	public bool     setRotatedY(bool trueFalse) {
		rotatedY = trueFalse;
		return rotatedY;
	}
	public bool     setOptionAction(bool trueFalse) {
		optionAction = trueFalse;
		return optionAction;
	}
	public float    setPrevRotate(float num) {
		prevRotate = num;
		return prevRotate;
	}
	public float    setCurrentRotate(float num) {
		currentRotate = num;
		return currentRotate;
	}
	public float    setNormAtkTimer(float num) {
		normAtkTimer = num;
		return normAtkTimer;
	}
	public float    setTimer(float num) {
		timer = num;
		return timer;
	}
}