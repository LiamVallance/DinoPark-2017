﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullSoundHeat : MonoBehaviour {

    static float heat = 0.00f;

    void Update () {
        if (heat > 0) heat -= Time.deltaTime;
    }
}
