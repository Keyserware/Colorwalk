using UnityEngine;
using System.Collections;

public static class Spliner {
	public static Vector3 catmullRom(float t, float alpha, Vector3[] v) {
//		if(v.Length != 4) {
//			throw UnityException;
//		}
		float[] ti = new float[4];
		float[] r = new float[3];
		float[] s = new float[3];
		Vector3[] A = new Vector3[3];
		Vector3[] B = new Vector3[2];

		ti[0] = 0.0f;
		for(int i = 1; i < v.Length; i++) {
			ti[i] = Mathf.Pow(Vector3.Distance(v[i-1], v[i]), alpha) + ti[i-1];
			r[i-1] = ti[i] - t;
			s[i-1] = t - ti[i-1];
		}

		for(int i = 0; i < A.Length; i++) {
			A[i] = (1/(ti[i+1] - ti[i])) * (r[i] * v[i] + s[i] * v[i+1]);
		}

		for(int i = 0; i < B.Length; i++) {
			B[i] = (1/(ti[i+2]-ti[i])) * (r[i+1] * A[i] + s[i] * A[i+1]);
		}
				
		return (1/(ti[2]-ti[1])) * (r[1] * B[0] + s[1] * B[1]);
	}

	public static Vector3 centripetalCatmullRom(float t, Vector3[] v) {
		return catmullRom(t, 0.5f, v);
	}

	public static Vector3 chordalCatmullRom(float t, Vector3[] v) {
		return catmullRom(t, 1.0f, v);
	}

	public static Vector3 standardCatmullRom(float t, Vector3[] v) {
		return catmullRom(t, 0.0f, v);
	}
}
