public class CharaParameterManager : UnityEngine.MonoBehaviour {

	/* 0 is default input, please overload on PreStart() */
	private float   charaHP     = 0; /* Store current hp values */
	private float   charaMaxHP  = 0; /* Store max hp */
	private float   charaBuffHP = 0; /* Store buffed hp values */
	private float   charaMovSpd = 0; /* Store charaMovementSpeed */

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
			Parameter[param.Key] = param.Value;
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
  public float GetCharaHP() {
		return charaHP;
	}
	public float GetCharaMaxHP() {
		return charaMaxHP;
	}
	public float GetCharaBuffHP() {
		return charaBuffHP;
	}
	public float GetCharaMovSpd() {
		return charaMovSpd;
	}

  /*
   ▒██████▒▒████████▒████████
   ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
   ▒██████▒▒████████▒▒▒▒██▒▒▒
   ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
   ▒██████▒▒████████▒▒▒▒██▒▒▒
  */

  public float SetCharaHP(float num) {
		charaHP = num;
		return charaHP;
	}
	public float SetCharaMaxHP(float num) {
		charaMaxHP = num;
		return charaMaxHP;
	}
	public float SetCharaBuffHP(float num) {
		charaBuffHP = num;
		return charaBuffHP;
	}
	public float SetCharaMovSpd(float num) {
		charaMovSpd = num;
		return charaMovSpd;
	}
	public void SetDefaultValue() {
		Parameter.Add("HP", charaHP);
		Parameter.Add("MaxHP", charaMaxHP);
		Parameter.Add("BuffHP", charaBuffHP);
		Parameter.Add("MoveSpeed", charaMovSpd);
	}

}