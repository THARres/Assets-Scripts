public class CharaInputManager : UnityEngine.MonoBehaviour {

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

	public virtual bool GetKey(string key) {return false;}
	public virtual void PreStart() {}
	public virtual void PostStart() {}


	/*
	 ▒██████▒▒████████▒████████
	 ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒██████▒▒████████▒▒▒▒██▒▒▒
	 ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒██████▒▒████████▒▒▒▒██▒▒▒
	*/
	private void SetDefaultValue() {}

}