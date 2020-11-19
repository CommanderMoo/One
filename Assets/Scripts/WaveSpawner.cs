using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public static int EnemiesAlive = 0;
    //public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public Text waveCountdownText;
    //public GameManager gameManager;
    private int waveIndex = 0;


    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */
    // Update is called once per frame
    void Update()
    {

        if (EnemiesAlive > 0)
        {
            return;
        }

        /*
        if (waveIndex == waveIndex.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        */

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            //SpawnWave();
            countdown = timeBetweenWaves;
            //return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = Mathf.Floor(countdown).ToString();
        //waveCountdownText.text = string.Format("{0:00.00}, countdown");
    }

    /*
    IEnumerator Spawn()
    {
        PlayerStats.Rounds++;
        WaveSpawner wave = waves[waveIndex];
        EnemiesAlive = wave.countdown;

        for(int i = 0; i < wave.countdown; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }
    */
 /// <summary>
 /// changed from void 623
 /// </summary>
 /// <returns></returns>
    IEnumerator SpawnWave()
    {
         waveIndex++; 
        for (int i = 0; i < waveIndex; i++)
        {
            Debug.Log("Incoming");
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);
        }

        
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
