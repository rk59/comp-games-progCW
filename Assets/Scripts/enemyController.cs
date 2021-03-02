using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    // Only want enemys to chase if within radius
    public float warnRadius = 5f;

    Transform target;
    NavMeshAgent EnAgent;

    // Start is called before the first frame update
    void Start()
    {
        // Don't have to search for play tags, instead using a playerManager Singleton script
        target = PlayerManager.playerInstance.player.transform;
        EnAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= warnRadius)
        {
            EnAgent.SetDestination(target.position);

            if (distance <= EnAgent.stoppingDistance)
            {
                FaceTarget();
            }
        }       

    }

    // Ensure that enemy agent will turn to face palyer before moving, rather than any directional movement
    void FaceTarget()
    {
        // direction to target
        Vector3 direction = (target.position - transform.position).normalized;
        // rotation to point to the target
        Quaternion enemyRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // Update enemy rotation with some smoothing
        transform.rotation = Quaternion.Slerp(transform.rotation, enemyRotation, Time.deltaTime * 4);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, warnRadius);
    }
}
