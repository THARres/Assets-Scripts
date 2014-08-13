public class CharaInputManager : UnityEngine.MonoBehaviour {

	/*************************************************
	 * Load Saved Data / Overload Set-Up on PreStart *
	 *     Please Make Sure Each Pair Is UNIQUE      *
	 *************************************************/
	private UnityEngine.KeyCode actionA = UnityEngine.KeyCode.Z;
	private UnityEngine.KeyCode actionB = UnityEngine.KeyCode.X;
	private UnityEngine.KeyCode fire    = UnityEngine.KeyCode.Q;
	private UnityEngine.KeyCode dash    = UnityEngine.KeyCode.LeftShift;
	private UnityEngine.KeyCode up0     = UnityEngine.KeyCode.W;
	private UnityEngine.KeyCode left0   = UnityEngine.KeyCode.A;
	private UnityEngine.KeyCode down0   = UnityEngine.KeyCode.S;
	private UnityEngine.KeyCode right0  = UnityEngine.KeyCode.D;
	private UnityEngine.KeyCode up1     = UnityEngine.KeyCode.UpArrow;
	private UnityEngine.KeyCode left1   = UnityEngine.KeyCode.LeftArrow;
	private UnityEngine.KeyCode down1   = UnityEngine.KeyCode.DownArrow;
	private UnityEngine.KeyCode right1  = UnityEngine.KeyCode.RightArrow;
	private UnityEngine.KeyCode mouse0  = UnityEngine.KeyCode.Mouse0;
	private UnityEngine.KeyCode mouse1  = UnityEngine.KeyCode.Mouse1;

	public System.Collections.Generic.Dictionary<string, UnityEngine.KeyCode> Key = 
		new System.Collections.Generic.Dictionary<string, UnityEngine.KeyCode>();

	public System.Collections.Generic.Dictionary<UnityEngine.KeyCode, string> Value = 
		new System.Collections.Generic.Dictionary<UnityEngine.KeyCode, string>();	

	public void Start() {
		PreStart();
		SetDefaultValue();
		PostStart();
	}

	public void SetDefaultValue() {
		Key.Add("actionA" , actionA);
		Key.Add("actionB" , actionB);
		Key.Add("fire"    , fire);
		Key.Add("dash"    , dash);
		Key.Add("up0"     , up0);
		Key.Add("left0"   , left0);
		Key.Add("down0"   , down0);
		Key.Add("right0"  , right0);
		Key.Add("up1"     , up1);
		Key.Add("left1"   , left1);
		Key.Add("down1"   , down1);
		Key.Add("right1"  , right1);
		Key.Add("mouse0"  , mouse0);
		Key.Add("mouse1"  , mouse1);

		foreach (var pair in Key) {
			Value.Add(pair.Value, pair.Key);
		}
	}

	 /*
	██▒▒▒▒██▒██▒██████▒▒████████▒██▒▒▒▒██▒▒█████▒▒██▒▒▒▒▒
	██▒▒▒▒██▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
	██▒▒▒▒██▒██▒██████▒▒▒▒▒██▒▒▒▒██▒▒▒▒██▒███████▒██▒▒▒▒▒
	▒██▒▒██▒▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
	▒▒████▒▒▒██▒██▒▒▒▒██▒▒▒██▒▒▒▒▒██████▒▒██▒▒▒██▒███████
	*/

	public virtual void PreStart() {}
	public virtual void PostStart() {}

	/*
	 ▒███████▒████████▒▒████████
	 ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ██▒▒▒██▒▒████████▒▒▒▒▒██▒▒▒
	 ▒██▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒▒█████▒▒████████▒▒▒▒▒██▒▒▒
	*/

	public bool GetKey(string key) {
		if (Key.ContainsKey(key)) {
			return UnityEngine.Input.GetKeyDown(Key[key]);
		} else {
			UnityEngine.Debug.Log("Unsupported Input Key: " + key);
			return false;
		}
	}

	/*
	 ▒██████▒▒████████▒████████
	 ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒██████▒▒████████▒▒▒▒██▒▒▒
	 ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒██████▒▒████████▒▒▒▒██▒▒▒
	*/
	public bool SetKey(string keyName, UnityEngine.KeyCode button) {
		/* If duplicate, then flip */
		if (Key.ContainsValue(button)) {
			Key[Value[button]] = Key[keyName];
			Key[keyName] = button;
			Value[Key[Value[button]]] = Value[button];
			Value[button] = keyName;
		} else {
			Value.Remove(Key[keyName]);
			Value.Add(button, keyName);
			Key[keyName] = button;
		}
		return UnityEngine.Input.GetKeyDown(button);
	}
}