public class ThirdPersonCamera : UnityEngine.MonoBehaviour {

	public Map                    Map         = null;
	public UnityEngine.GameObject Subject     = null;
	public float                  FieldOfView = 50;

	private float h;
	private UnityEngine.Vector3 pos = new UnityEngine.Vector3(0F,0F,0F);
	private FirstPersonCamera fpc;

	public void Start() {
		SetDefaultValue();
	}

	public void Update() {
		if (!Map.CameraHasUpdate) {
			Subject = Map.Player;
			UpdateCamera();
			Map.CameraHasUpdate = true;
		}
		UpdateCameraFieldOfView();
	}

	private void UpdateCamera() {
		UpdateCameraParent();
		ResetCameraFieldOfView();
		UpdateCameraTransform();
	}

	private void UpdateCameraParent() {
		transform.parent = Subject.transform;
	}

	private void UpdateCameraFieldOfView() {
		if (!fpc.Running) {
			if (camera.fieldOfView >= 2F && camera.fieldOfView <= 98F) {
				camera.fieldOfView += UnityEngine.Input.GetAxis("Mouse ScrollWheel") * -10F;
			} else {
				if (camera.fieldOfView < 2F) {
					camera.fieldOfView = 2F;
					fpc.StartFirstPersonCamera(Map, Subject, h);
					fpc.Running = true;
				} else {
					camera.fieldOfView = 98F;
				}
			}
		} else {
			fpc.UpdateFirstPersonCamera();
		}
	}

	private void UpdateCameraTransform() {
		h = Subject.transform.FindChild("Mesh").gameObject.transform.FindChild("Mesh0").gameObject.GetComponent<UnityEngine.SkinnedMeshRenderer>().bounds.size.y;
		pos.x = 0F;
		pos.y = h * 0.9F;
		pos.z = h * 2F;
		transform.localPosition = pos;
		transform.localEulerAngles = new UnityEngine.Vector3(0F,180F,0F);
	}

	private void ResetCameraFieldOfView() {
		camera.fieldOfView = FieldOfView;
	}

 /*
  ▒██████▒▒████████▒████████
  ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
  ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
  ▒██████▒▒████████▒▒▒▒██▒▒▒
 */
	private void SetDefaultValue() {
		ResetCameraFieldOfView();
		Map = UnityEngine.GameObject.Find("_Map").GetComponent<Map>();
		fpc = GetComponent<FirstPersonCamera>();
	}
}
