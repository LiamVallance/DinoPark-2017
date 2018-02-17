﻿// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class HeronCollider : MonoBehaviour
{
    public float radius = 0.00f;
    public Vector3 position;

    void Awake()
    {
        position = transform.position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.32f, 0.55f, 0.76f, 0.7f);
        Gizmos.DrawSphere(transform.position, radius);
    }
}