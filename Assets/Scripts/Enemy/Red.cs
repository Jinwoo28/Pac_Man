using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Enemy
{
    // Start is called before the first frame update
   override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
     void Update()
    {
       Moveing();
        modechange();
        ColorChange();
    }
    protected override void ChasePattern()
    {
        PatternRed();
    }
    

   

}
