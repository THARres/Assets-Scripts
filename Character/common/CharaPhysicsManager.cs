public class CharaPhysicsManager : UnityEngine.MonoBehaviour {

	/* Everything is controlled by AI until the player jumps in */
	public bool AIFlag = true;

	/* Script Attached To GameObject */
	public CharaInputManager     AI;
	public CharaInputManager     Input;
	public CharaParameterManager Parameter;

	public int                   Direction;

	private bool u,l,d,r;

	/**************************************************************
	 *          Action and Movement State Can Be Combined         *
	 **************************************************************/
	public string ActionState = "";
	public string MovementState = "";
	
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

	public virtual void ExecuteDash() {
		/* Do Transform Movement Here */
	}
	public virtual void ExecuteFire() {
		/* Do Particle System Here */
	}
	public virtual void ExecuteWalk() {
		/* Do Transform Movement Here */
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
	private int GetDirection(CharaInputManager input) {
		u = input.GetKey("up0");
		l = input.GetKey("left0");
		d = input.GetKey("down0");
		r = input.GetKey("right0");
		return u ? 
			(d ? (l ? (r ? 0 : 4) : (r ? (l ? 0 : 6) : 0)) : (l ? (r ? 0 : 7) : (r ? (l ? 0 : 9) : 8))) : 
			(l ? (r ? (d ? 2 : 0) : (d ? 1 : 4)) : (r ? (d ? 3 : 6) : (d ? 2 : 0)));
	}
	private string GetPhysicsState() {
		if (AIFlag) {
			SetActionState(AI);
			SetMovementState(AI);
		} else {
			SetActionState(Input);
			SetMovementState(Input);
		}
		return MovementState + ActionState;
	}

 /*
  ▒██████▒▒████████▒████████
  ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
  ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
 */

	private void SetActionState(CharaInputManager input) {
		if (input.GetKey("fire")) {
			ExecuteFire();
			ActionState = "fire";
		} else {
			ActionState = "";
		}
	}
	private void SetDefaultValue() {
		AI        = GetComponent<CharaAiInput>();
		Input     = GetComponent<CharaPlayerInput>();
		Parameter = GetComponent<CharaParameterManager>();
	}
	private void SetMovementState(CharaInputManager input) {
		Direction = GetDirection(input);
		switch (Direction) {
		case 0:
		default:
			MovementState = "idle";
			break;
		case 1:
		case 2:
		case 3:
		case 4:
		case 6:
		case 7:
		case 8:
		case 9:
			if (Input.GetKey("dash")) {
				ExecuteDash();
				MovementState = "dash";
			} else {
				ExecuteWalk();
				MovementState = "walk";
			}
			break;
		}
	}
}