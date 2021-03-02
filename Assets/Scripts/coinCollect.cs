using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCollect : MonoBehaviour
{
    GameControl gc;
        
    public ParticleSystem coinSpark;
    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("TagSC").GetComponent<GameControl>();
    }

    void OnTriggerEnter(Collider character)
    {
        if(character.name == "Player")
        {
            Debug.Log("Player Collects Coin");
            Instantiate(coinSpark);
            Destroy(gameObject);
            gc.AddScore();
        }
    }
   
}
