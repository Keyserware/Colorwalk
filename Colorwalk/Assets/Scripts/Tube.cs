using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class Tube  {
	private LinkedList<Vector3> spline;
	private Vector3[] currentPath;
	private float splineNodeDistance;

	public LinkedList<Vector3> getSpline{
		get {return spline;}
	}

	public Vector3 lastNode {
		get {return currentPath[currentPath.Length - 1];}
	}

	public Vector3 lastDir {
		get {return lastNode - currentPath[currentPath.Length - 2];}
	}

	public Tube(float splineNodeDistance, int n, float offsetDist, float offsetRadius) {
		this.splineNodeDistance = splineNodeDistance;
		initPath(n, offsetDist, offsetRadius);
		spline = new LinkedList<Vector3>();
		spline.AddLast(lastNode);
	}


	public void debugPath(Color color) {
		GameObject marker;
		foreach(Vector3 v in currentPath) {
			marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			marker.transform.position = v;
			marker.transform.localScale = 0.2f * Vector3.one;
			marker.GetComponent<Renderer>().material.color = color;
		}
	}

	public void appendRandPath(int n, float offsetDist, float offsetRadius, int splinePrecision) {
		Vector3[] path = createRandPath(lastNode, lastDir, n, offsetDist, offsetRadius);
		float[] arcLengths = new float[splinePrecision + 1];
		arcLengths[0] = 0.0f;
		Vector3 v0 = currentPath[currentPath.Length - 2];

		GameObject marker;

		for(int i = 1; i < arcLengths.Length; i++) {
			marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			marker.transform.position = v0;
			marker.transform.localScale = 0.2f * Vector3.one;
			Vector3 v1 = Spliner.catmullRomPath((float) i / splinePrecision, 0.5f, currentPath, path);
			arcLengths[i] = arcLengths[i-1] + Vector3.Distance(v0, v1);
			Debug.Log(v0);
			Debug.DrawLine(v0, v1, Color.green, 1000);
			v0 = v1;
		}

		float t;
		float a = splineNodeDistance - Vector3.Distance(spline.Last(), path[0]);

//		while(a < arcLengths[n]) {
//			int alID = Array.BinarySearch(arcLengths, a);
//			if(alID < 0) {
//				alID = (~alID) - 1;
//				t = (alID + (a - arcLengths[alID]) / (arcLengths[alID + 1] - arcLengths[alID])) / n;
//			} else {
//				t = alID / n;
//			}
//			a += splineNodeDistance;
//			spline.AddLast(Spliner.catmullRomPath(t, 0.5f, currentPath, path));
//		}

		currentPath = path;
	}

	private void initPath(int n, float offsetDist, float offsetRadius) {
		Vector3[] path = createRandPath(Vector3.zero, Vector3.back, 3, offsetDist, offsetRadius);
		Array.Reverse(path);
		this.currentPath = path;
	}
	private static Vector3[] createRandPath(Vector3 start, Vector3 dir, int n, float offsetDist, float offsetRadius) {
		Vector3[] path = new Vector3[n];

		path[0] = start;
		dir = Vector3.Normalize(dir);

		for(int i = 1; i < n; i++) {
			Vector3 normal = Vector3.Normalize(perp(dir));
			Vector3 nextDir = Vector3.Normalize(Quaternion.AngleAxis(UnityEngine.Random.Range(0.0f, 360.0f), dir) * (dir + normal * offsetRadius));
			path[i] = path[i-1] + nextDir * offsetDist;
			dir = nextDir;
		}

		return path;
	}

	private static Vector3 perp(Vector3 v) {
		if(v.x == 0 && v.y == 0) {
			return Vector3.Cross(v, Vector3.right);
		} else {
			return Vector3.Cross(v, Vector3.forward);
		}
	}

}
