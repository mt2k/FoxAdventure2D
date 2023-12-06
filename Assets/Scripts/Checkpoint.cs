using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite checkpointOn, checkpointOff;

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
        if (collision.CompareTag("Player"))
        {
            CheckpointController.instance.DetectiveCheckpoints();
            spriteRenderer.sprite = checkpointOn;
            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoint()
    {
        spriteRenderer.sprite = checkpointOff;
    }
}
