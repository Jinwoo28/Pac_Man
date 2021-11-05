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

    public Transform Warp1Pos = null;
    public Transform Warp2Pos = null;


    protected NavMeshAgent NMA = null;
    private bool ischase = false;
    private int PatrolPointNum = 1;
    
    public Vector3 MoveTarget = Vector3.zero;

    private bool warp1able = true;
    private bool warp2able = true;
    private bool CanWarp = false;
    private bool warpmode = false;

    public enum Mode
    {
        warp,
        patrol,
        runaway,
        chase,
    }

    public Mode mode = Mode.patrol;
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
                Debug.Log("RunAway");
                Runaway();
                break;
            case Mode.chase:
                ChasePattern();
                break;
            case Mode.warp:
                Warpmode();
                break;
        }
    }

    public void Warpmode()
    {
        
    }

    public void WarpPos1() { MoveTarget = Warp1Pos.position; }
    public void WarpPos2() { MoveTarget = Warp2Pos.position; }

    public void Condition()
    {

        if (CanWarp) { mode = Mode.warp; }
        else
        {
            if (Player.GetComponent<Player>().playermode == global::Player.PlayerMode.powerUp)
            {
                mode = Mode.runaway;
                Debug.Log(mode);
            }

            else
            {
                if (Vector3.Distance(this.transform.position, Player.transform.position) < 20)
                {
                    mode = Mode.chase;
                    PatrolPointNum = 1;
                }
                else mode = Mode.patrol;
            }
        }


        
        

               
    }

    protected void Moveing() { NMA.SetDestination(MoveTarget); }

    protected virtual void ChasePattern()  {  }

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
        if (Vector3.Distance(this.transform.position, Player.GetComponent<Player>().GetPlayerforward()) < 2.0f)
        {
            PatternRed();
        }
    }

    protected void PatternOrange() {   }



    protected void Patrolpatton()
    {
        MoveTarget = PatrolPos[PatrolPointNum].position;


        if (Vector3.Distance(this.transform.position, PatrolPos[PatrolPointNum].position)<1.0f){
            PatrolPointnum();
        }

    }

    private void PatrolPointnum()
    {
        PatrolPointNum++;
        if (PatrolPointNum == PatrolPos.Length) PatrolPointNum = 1;
    
    }

    protected void Runaway()
    {
        Vector3 Pos =  Player.transform.position - this.transform.position;
        Debug.Log("µµ¸Á");
        MoveTarget = -Pos;
    }

    protected void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<Player>().GetPlayermode()==global::Player.PlayerMode.Idle)
            other.GetComponent<Player>().PlayerDie();
        }

        if (other.CompareTag("warp1"))
        {
            if (warp1able)
            {
                warp2able = false;
                NMA.Warp(Warp2Pos.position);
                Debug.Log("warp1");
            }
        }
        else if (other.CompareTag("warp2"))
        {
            if (warp2able)
            {
                warp1able = false;
                NMA.Warp(Warp1Pos.position);
                Debug.Log("warp2");
            }
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("warp1")) warp1able = true;
        else if (other.CompareTag("warp1")) warp2able = true;
    }

    public bool WarpMode()
    {
        return CanWarp;
    }

    public void scatter()
    {
      //  Debug.Log("¸ÔÈû");
    }

    public void CanWarpChange()
    {
        if (CanWarp) CanWarp = false;
        else if (!CanWarp) CanWarp = true;
    }
   


}
