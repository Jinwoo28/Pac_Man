using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private GameObject Sp = null;
    private ParticleSystem Ps = null;
    private MeshRenderer Ms = null;
    private void Start()
    {
        Ps = GetComponent<ParticleSystem>();
         Ms = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().CoinCountUp();
            Ms.enabled = false;
            Destroy(Sp);
            Ps.Play();

            StartCoroutine("CoinDestroy");

        }
    }

    IEnumerator CoinDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }


}
