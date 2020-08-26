using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GM;
using System;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public Transform platformsHolder;
    public List<Transform> platformsList = new List<Transform>();
    public List<Transform> temporaryList = new List<Transform>();
    public int numberOfPlatforms;
    readonly private float platformWidth = 16;
    private float zSpawn = 0;

    private void Awake()
    {
        GlobalManager.PlatformManager = this;
        PopulatePlatformsList();
        SpawnPlatforms();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalManager.PlayerController.transform.position.z > zSpawn - ((numberOfPlatforms-1) * platformWidth))
        {
            MoveFirstPlatform();
        }
    }

    private void PopulatePlatformsList()
    {
        GameObject initialPlatform = Instantiate(platformPrefabs[0], platformsHolder);
        initialPlatform.name = platformPrefabs[0].name;
        initialPlatform.SetActive(false);

        platformsList.Add(initialPlatform.transform);
        for (int i = 0; i < numberOfPlatforms - 1; i++)
        {
            //Add to active list
            GameObject platformPrefab = platformPrefabs[UnityEngine.Random.Range(1, platformPrefabs.Length - 1)];
            GameObject platform = Instantiate(platformPrefab, platformsHolder);
            platform.name = platformPrefab.name;
            platform.SetActive(false);

            platformsList.Add(platform.transform);

        }
    }

    private void SpawnPlatforms()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            if (i == 0)
            {
                platformsList[i].position = Vector3.zero;
                zSpawn = platformsList[i].position.z + platformWidth;
            } else
            {
                platformsList[i].position = new Vector3(platformsList[i - 1].position.x, platformsList[i - 1].position.y, zSpawn);
                zSpawn = platformsList[i].position.z + platformWidth;
            }
            platformsList[i].gameObject.SetActive(true);
        }
    }

    private void MoveFirstPlatform()
    {
        Transform obj = platformsList[0];
        if (obj != null)
        {
            platformsList.RemoveAt(0);
            Destroy(obj.gameObject);
        }
        int rndNumber = UnityEngine.Random.Range(1, platformPrefabs.Length - 1);
        GameObject randPlatform = Instantiate(platformPrefabs[rndNumber], platformsHolder);
        randPlatform.name = platformPrefabs[rndNumber].name;
        randPlatform.transform.position = new Vector3(platformsList[1].position.x, platformsList[1].position.y, zSpawn);
        randPlatform.SetActive(true);

        platformsList.Add(randPlatform.transform);

        zSpawn = platformsList[platformsList.Count - 1].position.z + platformWidth;
    }
}
