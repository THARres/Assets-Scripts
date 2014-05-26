using UnityEngine;
using System.Collections;

public class AliceAttackController : CharaAttackController {

	public override CharaController getCharaController() {
		return transform.root.gameObject.GetComponent<AliceController>();
	}
}