using UnityEngine;
using System.Collections.Generic;

public class TubeFactory : MonoBehaviour {
	public int controlCount;
	public float offsetAngle;
	public float offsetDist;

	private static IList<Vector3> createRandPath(Vector3 start, Vector3 dir, int count, float offsetRadius, float offsetDist) {
		IList<Vector3> list = new List<Vector3>();
		list.Add(start);

		Vector3 prevPoint = start;
		dir = Vector3.Normalize(dir);

		for(int c = 0; c < count; c++) {
			Vector3 help = new Vector3(dir.x, -dir.y, -dir.z);
			Vector3 normal = Vector3.Normalize(Vector3.Cross(dir, help));
			Vector3 nextPoint = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), dir) * (prevPoint + dir * offsetDist + normal * offsetRadius);
			list.Add(nextPoint);

			dir = Vector3.Normalize(nextPoint - prevPoint);
			prevPoint = nextPoint;
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
