using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    private bool hasPowerup;
    public float pushBackPower;
    public float powerUpDuration;
    public GameObject powerUpIndicator;
    private GameRuler gameRuler;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        gameRuler = GameObject.Find("GameRuler").GetComponent<GameRuler>();
    }

    private void Update()
    {
        if (!gameRuler.isGameover)
        {
            float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
            powerUpIndicator.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);

            if (transform.position.y < -3)
            {
                Destroy(gameObject);
                gameRuler.isGameover = true;
                Destroy(powerUpIndicator);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp")
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            if (powerUpIndicator )
            {
                Instantiate(powerUpIndicator);
            }
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" && hasPowerup)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 pushBackDirection = other.gameObject.transform.position - transform.position;
            enemyRb.AddForce(pushBackDirection * pushBackPower, ForceMode.Impulse);
        }
    }
}