using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;

    private Checkpoint[] checkpoints;

    public Vector3 spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //checkpoints = GetComponentsInChildren<Checkpoint>();
        checkpoints = FindObjectsOfType<Checkpoint>();
        //Alaways Sets position spawnPoint (0;0;0) == player position (-4.25;-2;0)
        spawnPoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectiveCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++) 
        {
            checkpoints[i].ResetCheckpoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
