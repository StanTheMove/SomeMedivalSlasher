using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCentreHealth : Health
{
    private void Start()
    {
        Init();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    protected override void Death()
    {
        base.Death();
    }

}
