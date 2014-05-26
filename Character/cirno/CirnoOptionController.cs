using UnityEngine;
using System.Collections;

public class CirnoOptionController : CharaOptionController {
	
	public override CharaController getCharaController() {
		return transform.parent.gameObject.GetComponent<CirnoController>();
	}
	
}
