using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody Rb = null;
    private float MoveSpeed = 7;
    [SerializeField] private Transform Cam = null;
    [SerializeField] private Transform player = null;

    private int CoinCount = 0;
    
    private bool warpable = true;

    private Vector3 MoveDir = Vector3.zero;

    private Vector3 Playerforward = Vector3.zero;

    private bool playerDie = false;
    public enum PlayerMode
    {
        Idle,
        powerUp,
    }

    public PlayerMode playermode = PlayerMode.Idle;
    
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDie)
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
            {
                Playerforward = hit.point;
            }
            isMove();
            LookAt();
        }
        Debug.Log(playerDie);
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
        Debug.Log("??");
        float Z = Input.GetAxisRaw("Vertical");
        float X = Input.GetAxisRaw("Horizontal");
  
        Vector3 Lookforward = new Vector3(Cam.forward.x, 0f, Cam.forward.z).normalized;
        Vector3 LookRight = new Vector3(Cam.right.x, 0f, Cam.right.z).normalized;
        Vector3 MoveDir = Lookforward * Z + LookRight * X;

            player.transform.forward = Lookforward;
            this.transform.position += MoveDir * Time.deltaTime*MoveSpeed;
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

    public void PowerUp()
    {
        playermode = PlayerMode.powerUp;
        StopCoroutine("PowerCanCel");
        StartCoroutine("PowerCanCel");
    }

    IEnumerator PowerCanCel() 
    {
        yield return new WaitForSeconds(5.0f);
        playermode = PlayerMode.Idle;
    }

    public void CoinCountUp()
    {
        CoinCount++;
    }

    public int GetCoinCount()
    {
        return CoinCount;
    }

    public bool GetPlayerDie()
    {
        return playerDie;
    }

    public void PlayerDie()
    {
        playerDie = true;
    }

    public void PlayerRevive()
    {
        playerDie = false;
    }

    public bool PlayerLife()
    {
        return playerDie;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(playermode == PlayerMode.powerUp)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().scatter();
            }
        }
    }


}
