
using UnityEngine;

public class enemyInteract : MonoBehaviour
{
    public float enHealth = 20f;
    public float damageDealt = 20f;

    GameControl gc;
    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("TagSC").GetComponent<GameControl>();
    }
    public void TakeDamage(float amount)
    {
        enHealth -= amount;
        if (enHealth <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        gc.AddXP();
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider character)
    {
        if (character.name == "Player")
        {
            Debug.Log("Player hit by enemy");
            gc.DecHealth();
        }
    }



}

