using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test Message");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespwanPlayer()
    { 
        
    }
}
