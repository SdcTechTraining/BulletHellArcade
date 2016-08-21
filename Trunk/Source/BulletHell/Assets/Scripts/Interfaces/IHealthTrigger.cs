using System;
using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public interface IHealthTrigger
{
    void HealthChanged(float oldHealth, float newHealth);
}
