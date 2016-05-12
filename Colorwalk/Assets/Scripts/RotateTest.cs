using UnityEngine;
using System.Collections;

public class RotateTest : MonoBehaviour {
	public Transform origin;
	public Transform target;
	public Transform newTarget;

	private Vector3 dir;
	private Quaternion rotation;
	private Vector3 normal;
	private Vector3 help;
	private float speed = 2.0f;
	private float newDirCD = 2.0f;

	// Use this for initialization
	void Start () {
		dir = target.position - origin.position;
		help = new Vector3(dir.x, dir.y, -dir.z);
		normal = Vector3.Cross(dir, help);
		normal = Vector3.Normalize(normal);
	}
	
	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(target.position, target.position + normal);
		Gizmos.DrawLine(origin.position, target.position);
		Gizmos.DrawLine(origin.position, newTarget.position);
	}

	void Update () {
		newDirCD -= Time.deltaTime;
		if(newDirCD < 0.0f) {
			
			normal = Vector3.Cross(dir, help);
			normal = Vector3.Normalize(normal);
			newTarget.position = target.position + normal * Random.Range(-3.0f, 3.0f);
			newDirCD = 2.0f;
		}

		rotation = Quaternion.AngleAxis(90.0f * speed * Time.deltaTime, dir);

		newTarget.position = rotation * newTarget.position;
	}
}
