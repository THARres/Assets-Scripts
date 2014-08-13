public class CharaPhysicsManager : UnityEngine.MonoBehaviour {

	/* Everything is controlled by AI until the player jumps in */
	public bool   AI = true;

	/**************************************************************
	 *          Action and Movement State Can Be Combined         *
	 * Emotion State Will Replace Action and Movement when filled *
	 **************************************************************/
	public string ActionState = "";
	public string MovementState = "";

	public string EmotionState = "";
	
	public void Start() {
		PreStart();
		SetDefaultValue();
		PostStart();
	}
 /*
  ██▒▒▒▒██▒██▒██████▒▒████████▒██▒▒▒▒██▒▒█████▒▒██▒▒▒▒▒
  ██▒▒▒▒██▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
  ██▒▒▒▒██▒██▒██████▒▒▒▒▒██▒▒▒▒██▒▒▒▒██▒███████▒██▒▒▒▒▒
  ▒██▒▒██▒▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
  ▒▒████▒▒▒██▒██▒▒▒▒██▒▒▒██▒▒▒▒▒██████▒▒██▒▒▒██▒███████
 */

	public virtual void ExecuteFire() {
		/* Do Particle System Here */
	}

	public virtual void PreStart() {}
	public virtual void PostStart() {}

 /*
  ▒███████▒████████▒▒████████
  ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ██▒▒▒██▒▒████████▒▒▒▒▒██▒▒▒
  ▒██▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒▒█████▒▒████████▒▒▒▒▒██▒▒▒
 */
	public string GetPhysicsState() {
		if (AI) {
			return GetPhysicsStateFromAI();
		} else {
			return GetPhysicsStateFromInput();
		}
	}

	private string GetPhysicsStateFromAI() {
		return "Idle";
	}

	private string GetPhysicsStateFromInput() {
		if (GetComponent<CharaInputManager>().GetKey("fire")) {
			ExecuteFire();
			ActionState = "Fire";
			MovementState = "Idle";
		} else {
			ActionState = "";
			MovementState = "Idle";
		}
		return (EmotionState != "") ? EmotionState : MovementState + ActionState;
	}

 /*
  ▒██████▒▒████████▒████████
  ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
  ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
 */
	public void SetDefaultValue() {}
}