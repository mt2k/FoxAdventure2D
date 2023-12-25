using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;
    private string TAG_NAME = "Enemy";
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
        }
    }
}
