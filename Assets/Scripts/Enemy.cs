using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent NMA = null;
    [SerializeField] private GameObject Player = null;
    enum Mode
    {
        idle,
        runaway,
        chase,
    }

    Mode mode = Mode.idle;
    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NMA.destination = Player.transform.position;
        Debug.Log(NMA.destination);
    }

    private void modechange()
    {
        switch (mode)
        {
            case Mode.idle:
                break;
            case Mode.runaway:
                break;
            case Mode.chase:
                break;
        }
    }

}
