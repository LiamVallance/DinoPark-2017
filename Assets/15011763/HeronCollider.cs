﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeronCollider : MonoBehaviour {

    float radius = 0.00f;
    Vector3 position;

    void Awake()
    {
        position = transform.position;
    }

    void onDrawGizmoSelected()
    {
        Gizmos.color = new Color(0.32f, 0.55f, 0.76f, 0.7f);
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
