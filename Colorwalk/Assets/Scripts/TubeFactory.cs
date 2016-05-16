using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TubeFactory : MonoBehaviour {
	public int controlCount;
	public float offsetRadius;
	public float offsetDist;

	private Vector3[] testPath;
	private Tube testTube;




	void OnDrawGizmos() {
//		IEnumerator<Vector3> splineEnum = testTube.splineEnum;
//
//		Vector3 v;
//		float splineHue = 0.0f;
//		splineEnum.MoveNext();
//		v = splineEnum.Current;
//		Gizmos.DrawWireSphere(v, 0.5f);
//		Gizmos.color = Color.HSVToRGB(splineHue += 0.05f, 1.0f, 1.0f);
//		while(splineEnum.MoveNext()) {
//			Gizmos.DrawLine(v, splineEnum.Current);
//			v = splineEnum.Current;
//			Gizmos.DrawWireSphere(v, 0.1f);
//			Gizmos.color = Color.HSVToRGB(splineHue += 0.01f, 1.0f, 1.0f);
//		}

	}

	void Start () {
		testTube = new Tube(1.0f, 3, 5.0f, 1.0f);
		testTube.debugPath(Color.green);
//		GameObject marker;
//		marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
//		marker.transform.position = testPath[0];
//		marker.transform.localScale = 0.2f * Vector3.one;
//		for(int i = 1; i < testPath.Length; i++) {
//			marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
//			marker.transform.position = testPath[i];
//			marker.transform.localScale = 0.2f * Vector3.one;
//			Debug.DrawLine(testPath[i-1], testPath[i], Color.cyan, 1000.0f);
//		}


		testTube.appendRandPath(10, 5.0f, 1.0f, 50);
		testTube.debugPath(Color.blue);

//		LinkedList<Vector3> spline = testTube.getSpline;
//		print(spline.Count);
//		Vector3 u = spline.First.Value;
//		foreach(Vector3 v in spline){
//			marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			marker.transform.position = v;
//			marker.transform.localScale = 0.2f * Vector3.one;
//			Debug.DrawLine(u, v, Color.red, 1000.0f);
//			print(v.ToString());
//			u = v;
//		}
	}
	
	void Update () {
		
	}
}
