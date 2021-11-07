using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    [SerializeField]
    private GameObject WarpExit = null;


    private bool warpalbe = true;
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
            if (warpalbe)
            {
                warpalbe = false;
                other.transform.position = WarpExit.transform.position;
                WarpExit.GetComponent<warp>().donwarp();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warpalbe = true;
        }
    }

    public void donwarp()
    {
        warpalbe = false;
    }




}
