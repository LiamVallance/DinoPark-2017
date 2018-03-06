﻿using UnityEngine;
using System.Collections;

public class RaptyArrive : RaptyBehaviour
{
    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;
 
    public override RaptySteering GetRaptySteering()
    {
        RaptySteering steering = new RaptySteering();
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        float targetSpeed;
        if (distance < targetRadius)
            return steering;
        if (distance > slowRadius)
            targetSpeed = agent.maxSpeed;
        else
            targetSpeed = agent.maxSpeed * distance / slowRadius;
        Vector3 desiredVelocity = direction;
        desiredVelocity.Normalize();
        desiredVelocity *= targetSpeed;
        steering.linear = desiredVelocity - agent.velocity;
        steering.linear /= timeToTarget;
        if (steering.linear.magnitude > agent.maxAccel)
        {
            steering.linear.Normalize();
            steering.linear *= agent.maxAccel;
        }
        return steering;
    }
}
