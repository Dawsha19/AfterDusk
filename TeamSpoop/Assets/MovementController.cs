using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour {

    [SerializeField]
    float m_stetchiness = 200f;

    [SerializeField]
    float m_bounciness = 2f;


    public float m_speed = 20;

    public float m_rotSpeed = 3;

    public Rigidbody m_rb;

    public float m_jump = 50;

    public bool isGrounded;

    public float m_Drag = 1f;




    // Use this for initialization
    void Start () {
        m_rb = GetComponent<Rigidbody>();
    }
    protected void Move(float moveSpeed, float rotSpeed)
    {
  
        m_rb.AddForce(transform.forward * m_speed * moveSpeed);

        Vector3 currentRot = m_rb.transform.rotation.eulerAngles;
        Vector3 desiredRot = currentRot;
        desiredRot.y -= rotSpeed * m_rotSpeed;

        //Rotation...
        Vector3 displacement = currentRot - desiredRot;

        Debug.LogWarning(displacement.y);

 
        Vector3 springForce = displacement * m_stetchiness;

        Vector3 dampingForce = m_rb.angularVelocity * m_bounciness;

        m_rb.AddTorque(springForce - dampingForce);// - dampingForce);

        Vector3 dragForce = -m_rb.velocity * m_Drag;
        dragForce.y = 0;

        m_rb.AddForce(dragForce);
    }

    protected void Jump(bool input)
    {
        if (input == true && isGrounded)
        {
            Debug.Log("Jump!");
            m_rb.AddForce(Vector3.up * m_jump);
            isGrounded = false;
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
