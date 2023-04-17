using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;
    public float speed;
    private Vector3 lookDirection;
    private SpawnManager manager;
    private GameRuler gameRuler;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
        manager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameRuler = GameObject.Find("GameRuler").GetComponent<GameRuler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameRuler.isGameover)
        {
            lookDirection = player.transform.position - transform.position;
            enemyRb.AddForce(lookDirection * speed);

            if (gameObject.transform.position.y < -3)
            {
                Destroy(gameObject);
                manager.enemiesCount--;
            }
        }
        else {
            Destroy(gameObject);
            manager.enemiesCount--;
        }
    }
}
