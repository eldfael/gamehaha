﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ability
{
    void UseAbility();

    float GetCooldown();
}
