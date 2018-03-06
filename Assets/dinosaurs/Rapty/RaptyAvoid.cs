﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaptyAvoid : RaptyBehaviour
{
    public float collisionRadius = 0.4f;
    GameObject[] targets;

    void Start ()
    {
        targets = GameObject.FindGameObjectsWithTag("Rapty");
    }

    public override RaptySteering GetRaptySteering()
    {
        RaptySteering steering = new RaptySteering();
        float shortestTime = Mathf.Infinity;
        GameObject firstTarget = null;
        float firstMinSeparation = 0.0f;
        float firstDistance = 0.0f;
        Vector3 firstRelativePos = Vector3.zero;
        Vector3 firstRelativeVel = Vector3.zero;
        foreach (GameObject t in targets)
        {
            Vector3 relativePos;
            RaptyAgent targetAgent = t.GetComponent<RaptyAgent>();
            relativePos = t.transform.position - transform.position;
            Vector3 relativeVel = targetAgent.velocity - agent.velocity;
            float relativeSpeed = relativeVel.magnitude;
            float timeToCollision = Vector3.Dot(relativePos, relativeVel);
            timeToCollision /= relativeSpeed * relativeSpeed * -1;
            float distance = relativePos.magnitude;
            float minSeparation = distance - relativeSpeed * timeToCollision;
            if (minSeparation > 2 * collisionRadius)
                continue;
            if (timeToCollision > 0.0f && timeToCollision < shortestTime)
            {
                shortestTime = timeToCollision;
                firstTarget = t;
                firstMinSeparation = minSeparation;
                firstRelativePos = relativePos;
                firstRelativeVel = relativeVel;
            }
        }
        if (firstTarget == null)
            return steering;
        if (firstMinSeparation <= 0.0f || firstDistance < 2 * collisionRadius)
            firstRelativePos = firstTarget.transform.position;
        else
            firstRelativePos += firstRelativeVel * shortestTime;
        firstRelativePos.Normalize();
        steering.linear = -firstRelativePos * agent.maxAccel;
        return steering;
    }
}
