using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabEmeny;
    public GameObject prefabPowerup;
    public int enemiesToSpawn;
    public int enemiesCount;
    private GameRuler gameRuler;

    public float spawnRange = 9.0f;

    private void Start()
    {
        spawnWave(enemiesToSpawn);
        gameRuler = GameObject.Find("GameRuler").GetComponent<GameRuler>();
    }
    private void Update()
    {
        if (enemiesCount == 0 && !gameRuler.isGameover)
        {
            enemiesToSpawn++;
            spawnWave(enemiesToSpawn);
        }
    }
    private void spawnWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            instanceEnemy();
        }
        enemiesCount = enemiesToSpawn;
        
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Instantiate(prefabPowerup, new Vector3(spawnPosX, 0, spawnPosZ), transform.rotation);
    }
    private void instanceEnemy()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Instantiate(prefabEmeny, new Vector3(spawnPosX, 0, spawnPosZ), transform.rotation);
    }
}