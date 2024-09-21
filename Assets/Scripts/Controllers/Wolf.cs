using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent mob;

    public AIState aiState;

    public enum AIState {
        close,
        intermediate,
        far
    };

    void Start()
    {
        mob = GetComponent<NavMeshAgent>();
        aiState = AIState.close;
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 10) {
          aiState = AIState.close;
        } else if (Vector3.Distance(player.transform.position, transform.position) < 20) {
          aiState = AIState.intermediate;
        } else {
          aiState = AIState.far;
        }

        Vector3 playerVector = transform.position - player.transform.position;
        Vector3 newPosition = transform.position - playerVector;

        switch(aiState) {
          case AIState.close:
            mob.speed = 3.5f;
            mob.SetDestination(newPosition);
            break;
          case AIState.intermediate:
            mob.speed = 8f;
            mob.SetDestination(newPosition);
            break;
          case AIState.far:
            mob.speed = 12f;
            mob.SetDestination(newPosition);
            break;
          }
        }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TireCollector tireCollector = collision.gameObject.GetComponent<TireCollector>();
            int currTreeCount = tireCollector.tireTreeCount;

            if (currTreeCount < 10)
            {
                tireCollector.tireTreeCount = 0;
            }
            else
            {
                tireCollector.tireTreeCount -= 10;
            }

            tireCollector.SetCountText();

            Vector3 newPos = player.transform.position;
            int rad = 100;

            while (Vector3.Distance(player.transform.position, newPos) < 40)
            {
                Vector3 randomPoint = Random.insideUnitCircle * rad;

                NavMeshHit hit;
                NavMesh.SamplePosition(randomPoint, out hit, rad, 1);
                newPos = hit.position;
            }

            transform.position = newPos;
        }
    }
}
