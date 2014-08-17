/**************************************************
 *           This is a super manager              *
 * Handles all the coupling of character managers *
 **************************************************/

public class CharaControllerManager : UnityEngine.MonoBehaviour {

	public CharaAudioManager   Audio;
	public CharaGraphicManager Graphic;
	public CharaPhysicsManager Physics;
	
	public void Start() {
		PreStart();
		SetDefaultValue();
		PostStart();
	}

	public void Update() {
		Graphic.SetNextState(name + "_" + Physics.MovementState);
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
   ▒██████▒▒████████▒████████
   ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
   ▒██████▒▒████████▒▒▒▒██▒▒▒
   ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
   ▒██████▒▒████████▒▒▒▒██▒▒▒
  */
  private void SetDefaultValue() {
  	Audio   = GetComponent<CharaAudioManager>();
		Graphic = GetComponent<CharaGraphicManager>();
		Physics = GetComponent<CharaPhysicsManager>();
  }
}