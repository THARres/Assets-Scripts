public class FirstPersonCamera : UnityEngine.MonoBehaviour {

	public Map  Map     = null;
	public bool Running = false;
	private float h;
	private UnityEngine.Vector3 pos = new UnityEngine.Vector3(0F,0F,0F);

	public void StartFirstPersonCamera(Map map, UnityEngine.GameObject mama, float charaHeight) {
		SetMap(map);
		SetParent(mama);
		SetTransform(charaHeight);
		SetFieldOfView();
	}

	public void UpdateFirstPersonCamera() {
		if (UnityEngine.Input.GetAxis("Mouse ScrollWheel") < 0) {
			camera.fieldOfView = 2;
			pos.x = 0F;
			pos.y = h * 0.9F;
			pos.z = h * 2F;
			transform.localPosition = pos;
			Running = false;
		}
	}

 /*
  ▒██████▒▒████████▒████████
  ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
  ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
 */
	private void SetMap(Map map) {
		Map = map;
	}
	private void SetParent(UnityEngine.GameObject mama) {
		transform.parent = mama.transform;
	}
	private void SetTransform(float charaHeight) {
		h = charaHeight;
		pos.x = 0F;
		pos.y = h * 0.9F;
		pos.z = -2F;
		transform.localPosition = pos;
		transform.localEulerAngles = new UnityEngine.Vector3(0F,180F,0F);
	}
	private void SetFieldOfView() {
		camera.fieldOfView = 50;
	}

}
