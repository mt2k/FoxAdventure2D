using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGem : MonoBehaviour
{
    public bool isGem;
    private bool isCollected;
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
                Destroy(gameObject);
            }
        }
    }
}
