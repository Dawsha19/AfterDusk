using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MovementController{


    enum AggressiveState { PATROLLING }

    [SerializeField] AggressiveState m_aggressiveState = AggressiveState.PATROLLING;
    [SerializeField] Transform followTarget;
    [SerializeField] float awareDis;
    [SerializeField] float coneAware;
    [SerializeField] float slowDown;
    float vertInput;
    float horizInput;
    Vector3 dif;

    //For pathfinding...
    public Transform[] patrolPoints;    //Transform t0, Transform t1, Transform t2... length = 3
    int nextPathIndex = 0;              //index 0,      index 1         index 2
    [SerializeField] float maxCheckDist = 10;
    public Transform nextPatrolPoint;


    // Use this for initialization
    void Start()
    {

        m_rb = GetComponent<Rigidbody>();

        if (patrolPoints.Length > 0)
        {
            nextPatrolPoint = patrolPoints[0];
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (nextPathIndex + 1 > patrolPoints.Length - 1)
        {
            nextPathIndex = 0;
        }

        nextPatrolPoint = patrolPoints[++nextPathIndex];
    }
    // Update is called once per frame
    void Update () {
        RunAggresiveState();
	}


    void RunAggresiveState()
    {
        switch (m_aggressiveState)
        {
            case AggressiveState.PATROLLING:
                Patrolling();
                break;
        }
    }


    //void RunState()
    //{
    //    switch (m_state)
    //    {
    //        case State.AGGRESSIVE:
    //            RunAggresiveState();
    //            break;
    //    }
    //}

    void Patrolling()
    {

        if (nextPathIndex > patrolPoints.Length - 1)
        {
            nextPathIndex = 0;
        }

        Looking(nextPatrolPoint.position); //TODO: Give it a patrol point position instead...

        //      Looking(patrolPoints[nextPathIndex].position);
        Move(vertInput, horizInput);
    }


    void Attack()
    {
//        if (!PlayerInSight())
//        {
//            return;
//       }

        Looking(followTarget.position);
        Move(vertInput, horizInput);
    }

    protected bool PlayerInSight()
    {
        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position, dif.normalized, out hit))
        //    {
        //        if (!hit.transform.GetComponentInParent<playerControl>())
        //        {
        //            return false;
        //        }

        //    }
        return true;
    }


void Looking(Vector3 lookPos)
    {
        //dif = followTarget.position - transform.position;
        dif = lookPos - transform.position;
        dif.y = 0;

        float distance = dif.magnitude;

        /*
        if (distance > awareDis)
        {
            vertInput = 0;
            horizInput = 0;

            return;
        }*/
        if (distance < slowDown)
        {
            vertInput = 0;
            horizInput = 0;

            return;
        }

        Vector3 localDif = transform.InverseTransformPoint(lookPos);
        float difAngle = Vector3.Angle(dif, transform.forward);

        if (difAngle < coneAware)
        {
            vertInput = 1;
            horizInput = 0;
            return;
        }

        if (localDif.x > 0)
        {
            horizInput = 1;
        }
        else
        {
            horizInput = -1;
        }


    }


}
