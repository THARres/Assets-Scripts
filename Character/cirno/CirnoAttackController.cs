using UnityEngine;
using System.Collections;

public class CirnoAttackController : CharaAttackController {

	public override CharaController getCharaController() {
		return transform.root.gameObject.GetComponent<CirnoController>();
	}
	
}