public class CharaPhysicsManager : UnityEngine.MonoBehaviour {

	/* Everything is controlled by AI until the player jumps in */
	public bool AIFlag = true;

	/* Script Attached To GameObject */
	public CharaAIManager        AI;
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
	private int GetDirectionFromAI() {
		return System.Convert.ToInt32(AI.GetCommand("direction"));
	}
	private int GetDirectionFromInput() {
		u = Input.GetKey("up0");
		l = Input.GetKey("left0");
		d = Input.GetKey("down0");
		r = Input.GetKey("right0");
		return u ? 
			(d ? (l ? (r ? 0 : 4) : (r ? (l ? 0 : 6) : 0)) : (l ? (r ? 0 : 7) : (r ? (l ? 0 : 9) : 8))) : 
			(l ? (r ? (d ? 2 : 0) : (d ? 1 : 4)) : (r ? (d ? 3 : 6) : (d ? 2 : 0)));
	}
	private string GetPhysicsState() {
		if (AIFlag) {
			return GetPhysicsStateFromAI();
		} else {
			return GetPhysicsStateFromInput();
		}
	}
	private string GetPhysicsStateFromAI() {
		SetActionStateFromAI();
		SetMovementStateFromAI();
		return MovementState + ActionState;
	}
	private string GetPhysicsStateFromInput() {
		SetActionStateFromInput();
		SetMovementStateFromInput();
		return MovementState + ActionState;
	}

 /*
  ▒██████▒▒████████▒████████
  ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
  ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
 */

	private void SetActionStateFromAI() {
		if ((bool)AI.GetCommand("fire")) {
			ExecuteFire();
			ActionState = "fire";
		} else {
			ActionState = "";
		}
	}
	private void SetActionStateFromInput() {
		if (Input.GetKey("fire")) {
			ExecuteFire();
			ActionState = "fire";
		} else {
			ActionState = "";
		}
	}
	private void SetDefaultValue() {
		AI        = GetComponent<CharaAIManager>();
		Input     = GetComponent<CharaInputManager>();
		Parameter = GetComponent<CharaParameterManager>();
	}
	private void SetMovementStateFromAI() {
		Direction = GetDirectionFromAI();
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
			if ((bool)AI.GetCommand("dash")) {
				ExecuteDash();
				MovementState = "dash";
			} else {
				ExecuteWalk();
				MovementState = "walk";
			}
			break;
		}
	}
	private void SetMovementStateFromInput() {
		Direction = GetDirectionFromInput();
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