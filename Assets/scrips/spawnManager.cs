using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject ememyPrefab;
    private float spawnRange = 8.5f;
    // Start is called before the first frame update
    void Start()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnpos = new Vector3(xPos, ememyPrefab.transform.position.y, zPos);
        Instantiate(ememyPrefab, spawnpos, ememyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
