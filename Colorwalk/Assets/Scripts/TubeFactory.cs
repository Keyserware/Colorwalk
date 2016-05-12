using UnityEngine;
using System.Collections.Generic;

public class TubeFactory : MonoBehaviour {
	public int controlCount;
	public float offsetRadius;
	public float offsetDist;

	private IList<Vector3> testPath = createRandPath(Vector3.zero, Vector3.one, 100, 5, 0.5f);

	private static IList<Vector3> createRandPath(Vector3 start, Vector3 dir, int count, float offsetDist, float offsetRadius) {
		IList<Vector3> list = new List<Vector3>();
		list.Add(start);

		Vector3 prev = start;
		dir = Vector3.Normalize(dir);

		for(int c = 0; c < count; c++) {
			Vector3 help = new Vector3(dir.x, -dir.y, -dir.z);
			Vector3 normal = Vector3.Normalize(Vector3.Cross(dir, help));
			Vector3 nextDir = Vector3.Normalize(Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), dir) * (dir + normal * offsetRadius));
			Vector3 next = prev + nextDir * offsetDist;
			list.Add(next);

			dir = nextDir;
			prev = next;
		}

		return list;
	}

	void OnDrawGizmos() {
		IEnumerator<Vector3> e = testPath.GetEnumerator();

		float hue = 0.0f;
		e.MoveNext();
		Vector3 v = e.Current;
		Gizmos.DrawWireSphere(v, 0.5f);
		Gizmos.color = Color.HSVToRGB(hue += 0.05f, 1.0f, 1.0f);
		while(e.MoveNext()) {
			Gizmos.DrawLine(v, e.Current);
			v = e.Current;
			Gizmos.DrawWireSphere(v, 0.1f);
			Gizmos.color = Color.HSVToRGB(hue += 0.01f, 1.0f, 1.0f);
		}
	}

	void Start () {
		testPath = createRandPath(Vector3.zero, Vector3.one, controlCount, offsetDist, offsetRadius);
	}
	
	void Update () {
	
	}
}
