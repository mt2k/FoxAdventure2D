using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectable;
    private string TAG_NAME = "Enemy";
    public float chanceToDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TAG_NAME)
        {
            collision.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, collision.transform.position, collision.transform.rotation);
            PlayerController.instance.BounceHit();

            float dropSelect = Random.Range(0, 100f);
            if (dropSelect <= chanceToDrop)
            {
                Instantiate(collectable, collision.transform.position, collision.transform.rotation);
            }
        }
    }
}
