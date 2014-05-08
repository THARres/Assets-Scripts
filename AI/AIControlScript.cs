using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

public class AIControlScript : MonoBehaviour {

	/* Input Syntax */


	/* Use this for initialization */
	void Start () {

		Dictionary<string, string> aliceAI = ParsingCommandLine(AliceAI());
		foreach( KeyValuePair<string, string> kvp in aliceAI) {
			Console.WriteLine("{0} = {1}", 
			kvp.Key, kvp.Value);
		}
	
	}
	
	/* Update is called once per frame */
	void Update () {
	
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

	static string AliceAI() {
		return
		  "[target]"
		+ "Player"
		+ "[action]"
		+ "Guard"
		+ "[direction]"
		+ "All"
		+ "[time]"
		+ "0"
		+ "[name]"
		+ "Guard Player";
	}

}
