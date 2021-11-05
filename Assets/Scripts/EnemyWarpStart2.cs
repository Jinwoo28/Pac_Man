using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarpStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
                other.GetComponent<Enemy>().CanWarpChange();
            if (other.GetComponent<Enemy>().WarpMode())
            {
                other.GetComponent<Enemy>().mode = Enemy.Mode.warp;
                other.GetComponent<Enemy>().WarpPos1();
            }
        }
    }

}
