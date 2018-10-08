using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class player_controller : MonoBehaviour {

    public GameObject r_palm_item;
    public GameObject l_palm_item;
    public GameObject r_backhand_item;
    public GameObject l_backhand_item;

    public float ability_cooldown = 2.0f;
    public TEST_magic_push push;

    public float mov_speed = 1.0f;
    public float m_GroundCheckDistance = 0.1f;

    private float m_h;
    private float m_v;

    private float t_h;
    private float t_v;

    private float r_palm;
    private float r_p_cooldown;
    private float l_palm;
    private float l_p_cooldown;
    private float r_backhand;
    private float r_b_cooldown;
    private float l_backhand;
    private float l_b_cooldown;

	// Use this for initialization
	void Start () {

        m_h = 0.0f;
        m_v = 0.0f;

        t_h = 0.0f;
        t_v = 0.0f;

        r_palm = 0.0f;
        r_p_cooldown = 0.0f;
        l_palm = 0.0f;
        l_p_cooldown = 0.0f;
        r_backhand = 0.0f;
        r_b_cooldown = 0.0f;
        l_backhand = 0.0f;
        l_b_cooldown = 0.0f;
}
    
    void Update () {
        //This part of the script controls the non-movement player actions.
        r_palm = CrossPlatformInputManager.GetAxis("Fire1");
        l_palm = CrossPlatformInputManager.GetAxis("Fire3");
        r_backhand = CrossPlatformInputManager.GetAxis("Fire2");
        l_backhand = CrossPlatformInputManager.GetAxis("Fire4");

        r_p_cooldown -= Time.deltaTime;
        if (r_p_cooldown < 0.0f)
        {
            r_p_cooldown = 0.0f;
        }
        r_b_cooldown -= Time.deltaTime;
        if (r_b_cooldown < 0.0f)
        {
            r_b_cooldown = 0.0f;
        }
        l_p_cooldown -= Time.deltaTime;
        if (l_p_cooldown < 0.0f)
        {
            l_p_cooldown = 0.0f;
        }
        l_b_cooldown -= Time.deltaTime;
        if (l_b_cooldown < 0.0f)
        {
            l_b_cooldown = 0.0f;
        }

        if (r_palm != 0.0f)
        {
           // Debug.Log("Right palm activated");
            if(r_p_cooldown <= 0.0f)
            {
                Instantiate(push, gameObject.transform, false);
                r_p_cooldown = ability_cooldown;
            }
        }
        if(l_palm != 0.0f)
        {
           // Debug.Log("Left palm activated");
        }
        if(r_backhand != 0.0f)
        {
           // Debug.Log("Right backhand activated");
        }
        if(l_backhand != 0.0f)
        {
            //Debug.Log("Left backhand activated");
        }
        if(r_palm == 0.0f && l_palm == 0.0f && r_backhand == 0.0f && l_backhand == 0.0f)
        {
            //Debug.Log("Nothing activated");
        }
    }
	
	void FixedUpdate () {
        //This part of the script controls the player actions related to movement and rotation.
        m_h = CrossPlatformInputManager.GetAxis("Horizontal");
        m_v = CrossPlatformInputManager.GetAxis("Vertical");
        t_h = CrossPlatformInputManager.GetAxis("Horizontal2");
        t_v = CrossPlatformInputManager.GetAxis("Vertical2");

        transform.Translate(m_h * mov_speed * Time.deltaTime, 0.0f, m_v * mov_speed * Time.deltaTime, Space.World);


        float angle = Mathf.Atan2(t_h, t_v);

        if (t_h != 0.0f || t_v != 0.0f)
        {
            transform.rotation = Quaternion.Euler(0, angle * Mathf.Rad2Deg, 0);
        }
    }
}
