using System.Collections;

public class CharaInputManager : UnityEngine.MonoBehaviour {

	private string   actionA;
	private string   actionB;
	private string   fire;
	private string   shift;
	private string   mouse; 
	private string[] direction;

	public void Start() {
		preStart();
		setDefaultValue();
		postStart();

	}

	public void setDefaultValue() {}

	public void SetKey(string keyName, string button) {

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

  public object GetKey(string key) {
		switch (key) {
		case "actionA":
			return false;
		case "actionB":
			return false;
		case "fire":
			return false;
		case "shift":
			return false;
		case "mouse":
			return false;
		case "direction":
			return false;
		default:
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
	}
}