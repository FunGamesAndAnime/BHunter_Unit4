using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject powerUPPrefab;
    public GameObject ememyPrefab;
    private float spawnRange = 8.5f;
    private int enemyCount;
    private int waveNUm = 1;
    // Start is called before the first frame update
    void Start()
    {
        spwanwave(waveNUm);

    }
    void spwanwave(int enimeynum)
    {
        Instantiate(powerUPPrefab, geratespwan(), powerUPPrefab.transform.rotation);
        for (int i = 0; i < enimeynum; i++)
        { 
            Instantiate(ememyPrefab, geratespwan(), ememyPrefab.transform.rotation);
        }
    }
    Vector3 geratespwan()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnpos = new Vector3(xPos, ememyPrefab.transform.position.y, zPos);
        return spawnpos;

    }
    // Update is called once per frame
    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNUm++;
            spwanwave(waveNUm);
        }
    }
}
