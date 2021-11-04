using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Enemy
{

    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Moveing();
        Condition();
        modechange();
        Debug.Log(mode);
    }
    protected override void ChasePattern()
    {
        PatternBlue();
    }


}
