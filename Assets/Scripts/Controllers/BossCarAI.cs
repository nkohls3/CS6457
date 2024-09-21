using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class BossCarAI : MonoBehaviour
{
    public GameObject[] waypoints;
    public AIState aiState;
    public GameObject stillPos;
    public GameObject startPos;
    public FinishTrigger finisher;

    public float regSpeed = 14f;

    private NavMeshAgent nma;
    public NavMeshAgent NMA {
        get {return nma;}
        set {}
    }
    private bool rb = false;
    public bool RB {
        get {return rb;}
        set {rb = value;}
    }
    private int currWaypoint;
    private Vector3 endDest = new Vector3(26.9f, 0f, 10.4f);
    public Vector3 ED {
        get {return endDest;}
        set {}
    }
    private bool d = false;

    public enum AIState {
        race,
        still,
        start,
        end
    };

    // Start is called before the first frame update
    void Start() {
        nma = GetComponent<NavMeshAgent>();
        currWaypoint = 0;
        aiState = AIState.still;
        nma.speed = regSpeed;
    }

    // Update is called once per frame
    void Update() {
        switch(aiState) {
            case AIState.race:
                if (!rb) {
                    if (currWaypoint == waypoints.Length - 1) {
                        nma.speed = 8f;
                    } else {
                        nma.speed = regSpeed;
                    }
                }
                nma.SetDestination(waypoints[currWaypoint].transform.position);
                if (!nma.pathPending && nma.remainingDistance < 5) {
                    setNextWaypoint();
                }
                break;
            case AIState.start:
                nma.speed = 8f;
                GetComponent<BoxCollider>().size = new Vector3(2, 1, 4.55f);
                nma.SetDestination(startPos.transform.position);
                if (nma.remainingDistance == 0) {
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
                break;
            case AIState.still:
                nma.speed = 8f;
                GetComponent<BoxCollider>().size = new Vector3(10, 4, 13);
                nma.SetDestination(stillPos.transform.position);
                if (nma.remainingDistance == 0) {
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
                break;
            case AIState.end:
                if (!d) {
                    if (!nma.pathPending && nma.remainingDistance == 0 
                    && Vector3.Distance(gameObject.transform.position, waypoints[waypoints.Length - 4].transform.position) > 10) {
                        this.transform.position = waypoints[waypoints.Length - 4].transform.position;
                        d = true;
                    }
                } else {
                    nma.speed = 8f;
                    nma.SetDestination(endDest);
                    if (nma.remainingDistance == 0) {
                        gameObject.transform.rotation = new Quaternion(0, 220, 0, 0);
                        GetComponent<BoxCollider>().size = new Vector3(10, 4, 13);
                    }
                }
                break;
        }
    }

    private void setNextWaypoint() {
        if (waypoints.Length == 0) {
            Debug.Log("Waypoints is Empty!");
        } 
        if (currWaypoint < waypoints.Length - 1) {
            currWaypoint++;
        } else {
            if (!finisher.WON) {
                finisher.win = "boss";
                finisher.WON = true;
            }
            d = true;
            aiState = AIState.end;
        }
    }

    public void ChangeState(AIState state) {
        aiState = state;
    }

    public bool NoDist() {
        return nma.remainingDistance == 0;
    }

    public void ChangeSpeed(float s) {
        nma.speed = s;
    }
}
