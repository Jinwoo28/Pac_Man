using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarpStart : MonoBehaviour
{
    [SerializeField]
    private Transform Destination = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().WarpMode();
            other.transform.position += other.transform.forward * Time.deltaTime*2.0f;
            Debug.Log("warp");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().WarpModeExit();
        }
    }

}
