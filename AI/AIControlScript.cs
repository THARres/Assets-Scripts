using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

public class AIControlScript : MonoBehaviour {

	private static GameObject target;
	private static bool       hasSetTarget;
	private static Dictionary<string, string> cirnoAI;


	/* Use this for initialization */
	void Start () {

		cirnoAI = ParsingCommandLine(CirnoAI());
		hasSetTarget = false;
	
	}
	
	/* Update is called once per frame */
	void Update () {
	
	}

	public static void getCommand(CharaController control) {

		//if (control.name == "Cirno") {
			if (!hasSetTarget) {
				target = GameObject.Find(cirnoAI["target"]);
				hasSetTarget = true;
			}
			if (cirnoAI["action"] == "eliminate") {
				control.setCharaMousePos(target.transform.position);
				control.setCharaDirection(0);
				control.setCharaShift(false);
				control.setCharaDmged(false);
				control.setCharaMouse(true);
				control.setCharaAction(false);
				control.setCharaReverse(false);
				control.setCharaMovSpd(0);
				control.setCharaNormAtk(true);
			}
		//}
	}

	/* go to xy-coordinate */
	int goTo(float x, float y) {

		/*************
		 *           *
		 *************/

		return 0;
	}

	/* Parsing String To Hash */

	static Dictionary<string, string> ParsingCommandLine(string input) {
		Regex regex = new Regex(@"\[([^\]]+)\]([^\[]+)");
		Dictionary<string, string> result = new Dictionary<string, string>();
		foreach (Match match in regex.Matches(input)) {
			result.Add(match.Groups[1].Value, match.Groups[2].Value.Trim());
		}
		return result;
	}

	static string CirnoAI() {
		return
		  "[target]"
		+ "Alice"
		+ "[action]"
		+ "eliminate"
		+ "[direction]"
		+ "all"
		+ "[time]"
		+ "0"
		+ "[extra]"
		+ "target hp > 5";
	}

}
