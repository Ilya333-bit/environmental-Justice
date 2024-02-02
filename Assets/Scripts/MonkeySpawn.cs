using System.Collections.Generic;
using UnityEngine;

public class MonkeySpawn : MonoBehaviour
{   
    public List<Transform> needles;
    public GameObject monkey;
    public float intensity;
    
    void FixedUpdate()
    {
        if (Time.fixedTime % intensity == 0)
        {
            SpawnMonkey();
        }
    }

    private void SpawnMonkey()
    {
        Instantiate(monkey, transform.position, Quaternion.identity);
    }
}
