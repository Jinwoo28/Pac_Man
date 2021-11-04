using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp2 : MonoBehaviour
{
  [SerializeField]
    private Transform WarpExit = null;

    private bool warpenalbe = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
       
                warpenalbe = false;
                other.transform.position = WarpExit.position;
                other.transform.rotation = Quaternion.Euler(0, 180, 0);
                Debug.Log(other.transform.position);
            
        }
    }




}
