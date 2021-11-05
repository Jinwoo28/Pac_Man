using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Enemy
{
    private int PatternNum = 0;
    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Moveing();
        modechange();
    }
    protected override void ChasePattern()
    {
        switch (PatternNum)
        {
            case 0:
                PatternRed();
                break;
            case 1:
                PatternBlue();
                break;
            case 2:
                PatternOrange();
                break;
        }
    }

    IEnumerator PatternChange()
    {
        yield return new WaitForSeconds(8.0f);
        PatternNum = Random.Range(0, 3);
    }


}
