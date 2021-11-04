using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    private Vector3 Playerforward = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if(Physics.Raycast(this.transform.position,this.transform.forward,out hit))
        {
            Playerforward = hit.point;
        }
        
        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");
        Vector3 Move = new Vector3(X, 0, Z).normalized;

        this.transform.position += Move * 10*Time.deltaTime;
    }

    public Vector3 GetPlayerforward()
    {
        return Playerforward;
    }

}
