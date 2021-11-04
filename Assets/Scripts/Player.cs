using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody Rb = null;
    private float MoveSpeed = 7;
    [SerializeField] private Transform Cam = null;
    [SerializeField] private Transform player = null;

    private Vector3 MoveDir = Vector3.zero;

    private Vector3 Playerforward = Vector3.zero;
    public enum PlayerMode
    {
        Idle,
        powerUp,
    }

    PlayerMode playermode = PlayerMode.Idle;
    
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {
            Playerforward = hit.point;
        }



        isMove();
        LookAt();
    }

    private void ModeChange()
    {
        switch (playermode)
        {
            case PlayerMode.Idle:
                break;
            case PlayerMode.powerUp:
                break;

        }
    }

    private void isMove()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");
       // Debug.Log("Move");

         MoveDir = new Vector3(X, 0, Z).normalized;
       // Debug.Log(MoveDir);
        
        //Vector3 MoveForward = new Vector3(Cam.forward.x, 0, 0).normalized;

        if (Input.GetKey(KeyCode.Space))
        {
            player.forward = Cam.forward;
        }
        transform.position += MoveDir * Time.deltaTime * MoveSpeed;
    }

    private void LookAt()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"),0);
        Vector3 CamAngle = Cam.rotation.eulerAngles;
        Cam.rotation = Quaternion.Euler(0, CamAngle.y + mouseDelta.x, 0).normalized;
       // this.transform.rotation = Quaternion.Euler(0, CamAngle.y + mouseDelta.y, 0).normalized;
    }

    public Vector3 GetPlayerforward()
    {
        return Playerforward;
    }

    public Vector3 GetMove()
    {
        return MoveDir;
    }

    public PlayerMode GetPlayermode()
    {
        return playermode;
    }


}
