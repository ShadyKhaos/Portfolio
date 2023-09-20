using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    //[SerializeField] GameObject[] balloonPrefab;
    [SerializeField] Transform[] spawnLocations;

    [SerializeField] List<GameObject> allBalloonPrefab;
    [SerializeField] List<GameObject> spawnableBalloons;
    int spawnableBallonsInd;

    [SerializeField] float spawnDelay;
    float timer;

    [SerializeField] int goldChance = 1;

    private void Start()
    {
        timer = spawnDelay;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            spawnBallon();
    }

    void spawnBallon()
    {
        if(Random.Range(0,101)<goldChance) // returns 0-100 if 0 spawn golden balloon
        {
            spawnGolden();
            return;
        }
        int ballonRnd = Random.Range(0, spawnableBalloons.Count); // -1 bec last one is golden balloon
        int locationRnd = Random.Range(0, spawnLocations.Length);
        Instantiate(spawnableBalloons[ballonRnd], spawnLocations[locationRnd].position, Quaternion.identity);
        timer = spawnDelay;
    }

    public void IncBalloonsSpawned()
    {
        spawnableBallonsInd++;
        spawnableBalloons.Add(allBalloonPrefab[spawnableBallonsInd]);
    }

    private void spawnGolden()
    {
        int locationRnd = Random.Range(0, spawnLocations.Length);
        Instantiate(allBalloonPrefab[8], spawnLocations[locationRnd].position, Quaternion.identity);
        timer = spawnDelay;
    }
}
