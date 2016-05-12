using UnityEngine;
using System.Collections.Generic;

public class TubeFactory : MonoBehaviour {
	public int controlCount;
	public float offsetAngle;
	public float offsetDist;

	private static IList<Vector3> createRandPath(Vector3 start, Vector3 dir, int count, float offsetAngle, float offsetDist) {
		IList<Vector3> list = new List<Vector3>();
		list.Add(start);
		Vector3 prevPoint = start;
		dir = Vector3.Normalize(dir);
		float theta = Mathf.Acos(dir.z);
		float phi = Mathf.Atan2(dir.y, dir.x);
		for(int c = 0; c < count; c++) {
			theta += Random.Range(-1.0f, 1.0f) * offsetAngle;
			phi += Random.Range(-1.0f, 1.0f) * offsetAngle;
			Vector3 nextPoint = prevPoint;
			
		}

		return list;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.white;

		IList<Vector3> path = createRandPath(Vector3.zero, Vector3.one, 10, 0.2f * Mathf.PI, 2);

		IEnumerator<Vector3> e = path.GetEnumerator();

		while(e.MoveNext()) {
			Gizmos.DrawWireSphere(e.Current, 0.1f);
		}
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
