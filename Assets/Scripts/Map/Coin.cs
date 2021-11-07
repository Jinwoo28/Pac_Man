using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem Ps = null;
    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().CoinCountUp();
            ParticleSystem ps =  Instantiate(Ps, this.transform.position,Quaternion.Euler(90,0,180));
            ps.Play();
            Destroy(this.gameObject);

        }
    }



}
