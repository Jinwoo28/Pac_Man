using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    protected GameObject Player = null;

    [SerializeField]
    protected Transform[] PatrolPos = null;

    [SerializeField]
    private Transform RedPos = null;
    
    protected NavMeshAgent NMA = null;
    private bool ischase = false;
    private int PatrolPointNum = 0;
    
    protected Vector3 MoveTarget = Vector3.zero;
    
    enum Mode
    {
        patrol,
        runaway,
        chase,
    }

    Mode mode = Mode.patrol;
    protected virtual void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
    }

    protected void modechange()
    {
        Condition();
        switch (mode)
        {
            case Mode.patrol:
                Patrolpatton();
                break;
            case Mode.runaway:
                Runaway();
                break;
            case Mode.chase:
                ChasePattern();
                break;
        }
    }

    public void Condition()
    {
        if (Vector3.Distance(this.transform.position, Player.transform.position) < 20 &&
            (Player.GetComponent<Player>().GetMove().magnitude > 0))
        {
            mode = Mode.chase;
        }

        else if (Player.GetComponent<Player>().GetPlayermode() == global::Player.PlayerMode.powerUp)
        {
            mode = Mode.runaway;
        }

        else
        {
            mode = Mode.patrol;
        }


               
    }

    protected void Moveing() { NMA.destination = MoveTarget; }
    public virtual void SetPosition() { }

    protected virtual void ChasePattern()
    {

    }

    protected void PatternRed()
    {
        MoveTarget = Player.transform.position;
    }

    protected void PatternBlue()
    {
        Vector3 Pos1 = Player.transform.position - RedPos.position;
        MoveTarget = Player.transform.position + Pos1;
    }

    protected void PatternPink()
    {
        MoveTarget = Player.GetComponent<Player>().GetPlayerforward();
    }

    protected void Patrolpatton()
    {
        NMA.SetDestination(PatrolPos[PatrolPointNum].position);
        if (Vector3.Distance(this.transform.position, PatrolPos[PatrolPointNum].position)<1.0f){
            PatrolPointnum();
        }
    }

    private void PatrolPointnum()
    {
        PatrolPointNum++;
        if (PatrolPointNum == PatrolPos.Length) PatrolPointNum = 0;
    
    }

    protected void Runaway()
    {
        Vector3 Pos = Player.transform.position - this.transform.position;
        this.transform.position += Pos;
    }

}
