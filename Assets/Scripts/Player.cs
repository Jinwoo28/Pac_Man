using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody Rb = null;
    private float MoveSpeed = 20;
    [SerializeField] private Transform Cam = null;
    [SerializeField] private Transform player = null;
    
    enum PlayerMode
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

        Vector3 MoveDir = new Vector3(X, 0, Z).normalized;
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

}
