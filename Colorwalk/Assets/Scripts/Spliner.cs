using UnityEngine;
using System.Collections;

public static class Spliner {
	public static Vector3 catmullRom(float t, float alpha, Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3) {
		float[] ti = new float[4];
		float[] r = new float[3];
		float[] s = new float[3];
		Vector3[] A = new Vector3[3];
		Vector3[] B = new Vector3[2];

		ti[0] = 0.0f;
		ti[1] = Mathf.Pow(Vector3.Distance(v0, v1), alpha) + ti[0];
		ti[2] = Mathf.Pow(Vector3.Distance(v1, v2), alpha) + ti[1];
		ti[3] = Mathf.Pow(Vector3.Distance(v2, v3), alpha) + ti[2];

		for(int i = 1; i < 4; i++) {
			r[i-1] = ti[i] - t;
			s[i-1] = t - ti[i-1];
		}

		A[0] = (1/(ti[1] - ti[0])) * (r[0] * v0 + s[0] * v1);
		A[1] = (1/(ti[2] - ti[1])) * (r[1] * v1 + s[1] * v2);
		A[2] = (1/(ti[3] - ti[2])) * (r[2] * v2 + s[2] * v3);

		B[0] = (1/(ti[2]-ti[0])) * (r[1] * A[0] + s[0] * A[1]);
		B[1] = (1/(ti[3]-ti[1])) * (r[2] * A[1] + s[1] * A[2]);
				
		return (1/(ti[2]-ti[1])) * (r[1] * B[0] + s[1] * B[1]);
	}

	public static Vector3 catmullRomPath(float t, float alpha, Vector3[] prevPath, Vector3[] path) {
		float segTLength = 1.0f / ((float)path.Length - 1.0f);
		int segID = (int) (t / segTLength);
		float s = t - segID * segTLength;
		if(segID > 1) {
			return catmullRom(s, alpha, path[segID - 2], path[segID - 1], path[segID], path[segID + 1]);
		} else if(segID == 1) {
			return catmullRom(s, alpha, prevPath[prevPath.Length - 2], path[0], path[1], path[2]);
		} else {
			return catmullRom(s, alpha, prevPath[prevPath.Length - 3], prevPath[prevPath.Length - 2], path[0], path[1]);
		}
	}

//	public static Vector3 centripetalCatmullRom(float t, Vector3[] v) {
//		return catmullRom(t, 0.5f, v);
//	}
//
//	public static Vector3 chordalCatmullRom(float t, Vector3[] v) {
//		return catmullRom(t, 1.0f, v);
//	}
//
//	public static Vector3 standardCatmullRom(float t, Vector3[] v) {
//		return catmullRom(t, 0.0f, v);
//	}
}
