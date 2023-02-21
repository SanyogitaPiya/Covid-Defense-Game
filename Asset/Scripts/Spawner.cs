using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] enemyType;
    public float spawnInterval;

    public int numberOfEnemy1;
    public int numberOfEnemy2;
    public int numberOfEnemy3;

}

public class Spawner : MonoBehaviour
{

    //TEST BUTTON LISTENER
    private Button _button;
    private bool buttonClicked = false;

    public Wave[] waves;
    //public Transform spawnpoints;

    public Transform[] spawnPoint;

    //testing text
    //DELETE LATER
    public Text testText;


    //keep track of which wave you are in
    private Wave currentWave;
    private int currentWaveIndex;
    private float nextSpawnTime;

    //boolean to allow spawning of covid
    private bool canSpawn = true;


    private void Start()
    {
        //REFERENCE BUTTON
        _button = GameObject.Find("StartButton").GetComponent<Button>();
    }
    private void Update()
    {
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Character");

        if (buttonClicked == true)
        {
            _button.interactable = false;
        }
        else
        {
            if (totalEnemies.Length == 0)
            {
                _button.interactable = true;
                _button.onClick.AddListener(delegate{ParameterOnClick(ref buttonClicked);});
            }
            
        }
        /*
        if (buttonClicked == false)
        {
            _button.onClick.AddListener(delegate{ParameterOnClick(ref buttonClicked);});
        }
        */
        
        

        
        
        //keep track of waves
        currentWave = waves[currentWaveIndex];

        //call spawn wave function
        SpawnWave();


        //spawn new wave after previous wave is eliminated
        //GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Character");
        if(totalEnemies.Length == 0 && !canSpawn && currentWaveIndex + 1 != waves.Length)
        {
            if(buttonClicked == true)
            {
                currentWaveIndex++;
                canSpawn = true;
            }
            
        }
    }

    void SpawnWave()
    {
        if (canSpawn && buttonClicked && nextSpawnTime < Time.time)
        {
            /*
            //test random spawn
            //GameObject randomEnemy = currentWave.enemyType[Random.Range(0, currentWave.enemyType.Length)];
            GameObject randomEnemy = currentWave.enemyType[1];
            Transform spawnLocation = spawnPoint[Random.Range(0, spawnPoint.Length)];
            Instantiate(randomEnemy, spawnLocation.position, Quaternion.identity);

            //DELETE LATER - TESTING TEXT
            testText.text = currentWave.numberOfEnemies.ToString();

            //spawn proper number of enemies
            currentWave.numberOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
            }
            */

            //TEST SPAWN WAVES -------------------------------------------------------------------------- MY VERSION
            if(currentWave.numberOfEnemy1 > 0)
            {
                GameObject randomEnemy = currentWave.enemyType[0];
                Transform spawnLocation = spawnPoint[Random.Range(0, spawnPoint.Length)];
                Instantiate(randomEnemy, spawnLocation.position, Quaternion.identity);
                currentWave.numberOfEnemy1--;
                nextSpawnTime = Time.time + currentWave.spawnInterval;
            }
            if(currentWave.numberOfEnemy1 == 0 && currentWave.numberOfEnemy2 > 0)
            {
                GameObject randomEnemy = currentWave.enemyType[1];
                Transform spawnLocation = spawnPoint[Random.Range(0, spawnPoint.Length)];
                Instantiate(randomEnemy, spawnLocation.position, Quaternion.identity);
                currentWave.numberOfEnemy2--;
                nextSpawnTime = Time.time + currentWave.spawnInterval;
            }
            if(currentWave.numberOfEnemy1 == 0 && currentWave.numberOfEnemy2 == 0 && currentWave.numberOfEnemy3 > 0)
            {
                GameObject randomEnemy = currentWave.enemyType[2];
                Transform spawnLocation = spawnPoint[Random.Range(0, spawnPoint.Length)];
                Instantiate(randomEnemy, spawnLocation.position, Quaternion.identity);
                currentWave.numberOfEnemy3--;
                nextSpawnTime = Time.time + currentWave.spawnInterval;
            }

            if(currentWave.numberOfEnemy1 == 0 && currentWave.numberOfEnemy2 == 0 && currentWave.numberOfEnemy3 == 0)
            {
                canSpawn = false;
                buttonClicked = false;
            }
        }
        

    }

    
    private void ParameterOnClick(ref bool buttonClicked)
    {
        buttonClicked = true;
    }
    
    
    
}
























/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] enemyType;
    public float spawnInterval;
}

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    //public Transform spawnpoints;

    public Transform[] spawnPoint;

    //testing text
    //DELETE LATER
    // public Text testText;


    //keep track of which wave you are in
    private Wave currentWave;
    private int currentWaveIndex;
    private float nextSpawnTime;

    //boolean to allow spawning of covid
    private bool canSpawn = true;

    private void Update()
    {
        //keep track of waves
        currentWave = waves[currentWaveIndex];

        //call spawn wave function
        SpawnWave();
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            //test random spawn
            GameObject randomEnemy = currentWave.enemyType[Random.Range(0, currentWave.enemyType.Length)];
            Transform spawnLocation = spawnPoint[Random.Range(0, spawnPoint.Length)];
            Instantiate(randomEnemy, spawnLocation.position, Quaternion.identity);

            //DELETE LATER
            // testText.text = currentWave.numberOfEnemies.ToString();

            //spawn proper number of enemies
            currentWave.numberOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
        



    }
    
    
}

*/