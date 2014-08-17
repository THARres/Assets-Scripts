public class Map : UnityEngine.MonoBehaviour {

	public UnityEngine.GameObject Player = null;
	public bool CameraHasUpdate = true;

	public void Start () {}

	public void UpdatePlayer(UnityEngine.GameObject player) {
		if (Player != player) {
			Player = player;
			CameraHasUpdate = false;
		}
	}
}
