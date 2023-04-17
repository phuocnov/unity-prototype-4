using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuler : MonoBehaviour
{
    public bool isGameover = false;
    public GameObject prefabPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameover){
            Debug.Log("Game over! Press any to restart");
        }
        
        if(isGameover && Input.anyKey){
            Instantiate(prefabPlayer, prefabPlayer.transform.position, prefabPlayer.transform.rotation);
            isGameover = false;
        }
    }
}
