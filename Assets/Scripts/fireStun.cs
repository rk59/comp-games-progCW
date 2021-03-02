using UnityEngine;

public class fireStun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float hitForce = 10f;

    public Camera playerCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Stun();
        }

    }

    void Stun()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            worldObjects obstacle = hit.transform.GetComponent<worldObjects>();
            enemyInteract enemy = hit.transform.GetComponent<enemyInteract>();           

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hit.rigidbody != null && obstacle != null)
            {
                obstacle.TakeDamage(damage);
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }                
            
            GameObject impactreaction = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactreaction, 1.5f);

        }
    }
}
