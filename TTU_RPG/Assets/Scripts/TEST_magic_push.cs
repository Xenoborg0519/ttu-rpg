using UnityEngine;
using System.Collections;

public class TEST_magic_push : MonoBehaviour {

    public float lifespan = 0.5f;
    public float power = 20.0f;
    public float range = 10.0f;

    private Vector3 origin;

    // Use this for initialization
    void Start () {
        origin = gameObject.transform.parent.transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Collision Detected");
        if(other.attachedRigidbody) other.attachedRigidbody.AddExplosionForce(power, origin, range);
    }
	
	// Update is called once per frame
	void Update () {
        lifespan -= Time.deltaTime;

        //if lifespan has ended, destroy object
        if(lifespan <= 0)
        {
            Destroy(gameObject);
        }
	}
}
