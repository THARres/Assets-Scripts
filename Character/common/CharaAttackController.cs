using UnityEngine;
using System.Collections;

public class CharaAttackController : MonoBehaviour {

	private Vector2 objectMouse;
	private float   currentRotate;
	private float   fixedZ;
	private Vector3 coord;

	private CharaController script;

	/* Use this for initialization */

	void Start () { 

		preAdditionalStart();

		script = getCharaController();
		fixedZ = -4f;

		postAdditionalStart();
	
	}
	
	/* Update is called once per frame */
	void Update () {

		preAdditionalUpdate();

		objectMouse   = script.getCharaMousePos();
		currentRotate = -Mathf.Atan2(objectMouse.y, objectMouse.x) * Mathf.Rad2Deg;

		//Rotate All Child Objects
		foreach (Transform child in transform) {
			if (child.transform.position.z != fixedZ) {
				coord = child.transform.position;
				coord.z = fixedZ;
				child.transform.position = coord;
			}
			child.particleSystem.startRotation = currentRotate * Mathf.Deg2Rad;
		}

		postAdditionalUpdate();
	
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
	public virtual void preAdditionalStart() {}

	/* If Extra Stuff Required */
	public virtual void postAdditionalStart() {}

	/* If Extra Stuff Required */
	public virtual void preAdditionalUpdate() {}

	/* If Extra Stuff Required */
	public virtual void postAdditionalUpdate() {}

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

	public Vector2  getObjectMouse() {
		return objectMouse;
	}
	public float    getCurrentRotate() {
		return currentRotate;
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

	public Vector2  setObjectMouse(Vector2 vec) {
		objectMouse = vec;
		return objectMouse;
	}
	public float    setCurrentRotate(float num) {
		currentRotate = num;
		return currentRotate;
	}
}