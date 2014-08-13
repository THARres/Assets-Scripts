/**********************************************************
 * Please Include Animation Clips as Animation Component  *
 *   or else, animation["animationName"] would throw up   *
 **********************************************************/
public class CharaGraphicManager : UnityEngine.MonoBehaviour {

	/* 0 is default value, please overload on PreStart() */
	private string               preState  = "";
	private string               state     = "";
	private string               postState = "";

	public UnityEngine.Animator anim;

	public void Start() {
		PreStart();
		SetDefaultValue();
		PostStart();
	}
	public void Update() {
		if (GetPreState() != "") {
			StartCoroutine(RunPrestate(GetPreState(), animation[GetPreState()].length));
		} else if (GetPostState() != "") {
			SetState(GetPostState());
			SetPostState("");
			PlayState(GetState());
		} else {
			PlayState(GetState());
		}
	}

	private void PlayState(string stateName) {
		anim.Play(stateName);
	}

	private System.Collections.IEnumerator RunPrestate(string stateName, float length) {
		PlayState(stateName);
		yield return new UnityEngine.WaitForSeconds(length);
		SetPreState("");
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
	public string GetPreState() {
		return preState;
	}
	public string GetPostState() {
		return postState;
	}
	public string GetState() {
		return state;
	}

 /*
  ▒██████▒▒████████▒████████
  ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
  ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
 */
	public void SetDefaultValue() {
		anim = this.GetComponent<UnityEngine.Animator>();
	}
	public void setNextState(string next, string preNext = "") {
		SetPreState(preNext);
		SetPostState(preNext);
	}
	public string SetPreState(string s) {
		preState = s;
		return preState;
	}
	public string SetPostState(string s) {
		postState = s;
		return postState;
	}
	public string SetState(string s) {
		state = s;
		return state;
	}

}