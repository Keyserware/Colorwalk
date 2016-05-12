using UnityEngine;
using System.Collections.Generic;

public class TubeFactory : MonoBehaviour {
	public int controlCount;
	public float offsetAngle;
	public float offsetDist;

	private static IList<Vector3> createRandPath(Vector3 start, int count, float offsetAngle, float offsetDist) {
		IList<Vector3> list = new List<Vector3>();
		list.Add(start);
		Vector3 prevPoint = start;
		for(int c = 0; c < count; c++) {
			float phi = Random.Range(-1.0f, 1.0f) * offsetAngle;
			float psi = Random.Range(-1.0f, 1.0f) * offsetAngle;
			Vector3 nextPoint = prevPoint + Vector3;

		}

		return list;
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
