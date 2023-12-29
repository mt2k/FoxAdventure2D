using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHealth;
    private bool isCollected;
    public GameObject pickupEffects;
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
        if (collision.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemCount++;
                isCollected = true;
                Instantiate(pickupEffects, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (isHealth)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    //Instantiate(pickupEffects, collision.transform.position, collision.transform.rotation);
                    Instantiate(pickupEffects, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
    }
}
