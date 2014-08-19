public class CharaInputAI : CharaInputManager {

	/* AI behaves as if a player is controlling it. Model might demand high CPU capability */
	private bool actionA = false;
	private bool actionB = false;
	private bool fire    = false;
	private bool dash    = false;
	private bool up0     = false;
	private bool left0   = false;
	private bool down0   = false;
	private bool right0  = false;
	private bool up1     = false;
	private bool left1   = false;
	private bool down1   = false;
	private bool right1  = false;
	private bool mouse0  = false;
	private bool mouse1  = false;

	public System.Collections.Generic.Dictionary<string, bool> Key = 
		new System.Collections.Generic.Dictionary<string, bool>();

	 /*
	██▒▒▒▒██▒██▒██████▒▒████████▒██▒▒▒▒██▒▒█████▒▒██▒▒▒▒▒
	██▒▒▒▒██▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
	██▒▒▒▒██▒██▒██████▒▒▒▒▒██▒▒▒▒██▒▒▒▒██▒███████▒██▒▒▒▒▒
	▒██▒▒██▒▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
	▒▒████▒▒▒██▒██▒▒▒▒██▒▒▒██▒▒▒▒▒██████▒▒██▒▒▒██▒███████
	*/
	public override bool GetKey(string key) {
		return Key[key];
	}
	public override void PostStart() {
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
	}

	/*
	 ▒██████▒▒████████▒████████
	 ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒██████▒▒████████▒▒▒▒██▒▒▒
	 ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒██████▒▒████████▒▒▒▒██▒▒▒
	*/
	public void SetValue(string keyName, bool value) {
		Key[keyName] = value;
	}

}