﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAilment {

    public float ailmentChance;
    public AilmentType ailmentType;

    public enum AilmentType
    {
        Burn
    }

    public SkillAilment(AilmentType ailtype, int chance)
    {
        ailmentType = ailtype;
        ailmentChance = chance;
    }
}
