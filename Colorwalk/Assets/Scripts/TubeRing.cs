using UnityEngine;
using System.Collections;

public class TubeRing {

	private float r;
	private Vector3[] vertices;
	private Vector3 center;
	private Vector3 dir;

	public TubeRing(Vector3 center, Vector3 dir, Vector3 normal, float r, int n) {
		normal = Vector3.Normalize(normal);
		Quaternion rotation = Quaternion.AngleAxis(360.0f / n, dir);
	}
}
