public class CharaPhysicsManager : UnityEngine.MonoBehaviour {

	/* Everything is controlled by AI until the player jumps in */
	public bool AIFlag = true;

	/* Dependency  - Please Provide on the same GameObject */
	public CharaInputManager     AI;
	public CharaInputManager     Input;
	public CharaParameterManager Parameter;
	public Map                   Map;

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

	public void Update() {
		if (AIFlag) {
			SetActionState(AI);
			SetMovementState(AI);
		} else {
			Map.UpdatePlayer(gameObject);
			SetActionState(Input);
			SetMovementState(Input);
		}
	}

 /*
  ██▒▒▒▒██▒██▒██████▒▒████████▒██▒▒▒▒██▒▒█████▒▒██▒▒▒▒▒
  ██▒▒▒▒██▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
  ██▒▒▒▒██▒██▒██████▒▒▒▒▒██▒▒▒▒██▒▒▒▒██▒███████▒██▒▒▒▒▒
  ▒██▒▒██▒▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
  ▒▒████▒▒▒██▒██▒▒▒▒██▒▒▒██▒▒▒▒▒██████▒▒██▒▒▒██▒███████
 */

	public virtual void ExecuteDash() {
		if (u) {
			/* rigidbody.AddRelativeForce looks wacky :c */
			transform.Translate(0,0,-Parameter.Get("MovSpd") * Parameter.Get("SpdMod"));
		}
		if (l) {
			transform.Rotate(0,-Parameter.Get("TurnSpd") * Parameter.Get("SpdMod"),0);
		}
		if (d) {
			transform.Translate(0,0,Parameter.Get("MovSpd") * Parameter.Get("SpdMod"));
		}
		if (r) {
			transform.Rotate(0,Parameter.Get("TurnSpd") * Parameter.Get("SpdMod"),0);
		}
	}
	public virtual void ExecuteFire() {
		/* Do Particle System Here */
	}
	public virtual void ExecuteWalk() {
		if (u) {
			/* rigidbody.AddRelativeForce looks wacky :c */
			transform.Translate(0,0,-Parameter.Get("MovSpd"));
		}
		if (l) {
			transform.Rotate(0,-Parameter.Get("TurnSpd"),0);
		}
		if (d) {
			transform.Translate(0,0,Parameter.Get("MovSpd"));
		}
		if (r) {
			transform.Rotate(0,Parameter.Get("TurnSpd"),0);
		}

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
			(d ? (l ? (r ? 0 : 4) : (r ? 6 : 0)) : (l ? (r ? 8 : 7) : (r ? (l ? 8 : 9) : 8))) : 
			(l ? (r ? (d ? 2 : 0) : (d ? 1 : 4)) : (r ? (d ? 3 : 6) : (d ? 2 : 0)));
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
			ActionState = "Fire";
		} else {
			ActionState = "";
		}
	}
	private void SetDefaultValue() {
		AI        = GetComponent<CharaInputAI>();
		Input     = GetComponent<CharaInputPlayer>();
		Parameter = GetComponent<CharaParameterManager>();
		Map       = UnityEngine.GameObject.Find("_Map").GetComponent<Map>();
	}
	private void SetMovementState(CharaInputManager input) {
		Direction = GetDirection(input);
		switch (Direction) {
		case 0:
		default:
			MovementState = "Idle";
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
				MovementState = "Dash";
			} else {
				ExecuteWalk();
				MovementState = "Walk";
			}
			break;
		}
	}
}