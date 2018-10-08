using UnityEngine;
using System.Collections;

public class overhead_camera : MonoBehaviour {
    public Transform target;
    public Vector3 offset;
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 new_position = offset;
        new_position.x += target.position.x;
        new_position.y += target.position.y;
        new_position.z += target.position.z;
        transform.position = new_position;
        transform.LookAt(target);
	}
}
