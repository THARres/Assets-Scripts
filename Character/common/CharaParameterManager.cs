public class CharaParameterManager : UnityEngine.MonoBehaviour {

	/* 0 is default input, please overload on PreStart() */
	public float   HP     = 0; /* Store current hp values */
	public float   MaxHP  = 0; /* Store max hp */
	public float   BuffHP = 0; /* Store buffed hp values */
	public float   MovSpd = 0; /* Store charaMovementSpeed */

	/* Stores All Parameter Here */
	public System.Collections.Generic.Dictionary<string, float> Parameter = 
		new System.Collections.Generic.Dictionary<string, float>();

	public void Start() {
		PreStart();
		SetDefaultValue();
		PostStart();
	}
	public void UpdateParameter(System.Collections.Generic.Dictionary<string, float> list) {
		foreach (var param in list) {
			Set(param.Key, param.Value);
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
  public float Get(string param) {
  	return Parameter[param];
  }

  /*
   ▒██████▒▒████████▒████████
   ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
   ▒██████▒▒████████▒▒▒▒██▒▒▒
   ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
   ▒██████▒▒████████▒▒▒▒██▒▒▒
  */

	public void Set(string param, float value) {
		Parameter[param] = value;
	}
	public void SetDefaultValue() {
		Parameter.Add("HP"        , HP);
		Parameter.Add("MaxHP"     , MaxHP);
		Parameter.Add("BuffHP"    , BuffHP);
		Parameter.Add("MoveSpeed" , MovSpd);
	}

}