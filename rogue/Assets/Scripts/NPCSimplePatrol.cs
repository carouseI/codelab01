using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSimplePatrol : MonoBehaviour
{
    //dictate if agent waits on each node
    [SerializeField]
    bool _patrolWaiting;


    //total wait time at each node
    [SerializeField]
    float _totalWaitTime = 3f;


    //probability of switching direction
    [SerializeField]
    float _switchProbability = 0.2f;


    //patrol node list
    [SerializeField]
    List<Waypoint> _patrolPoints;


    //private variables for base behaviour
    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex;
    bool _travelling;
    bool _waiting;
    bool _patrolForward;
    float _waitTimer;


    // Start is called before the first frame update
    public void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("nav mesh agent comp not attached to " + gameObject.name);
        }
        else
        {
            Debug.Log("insufficient patrol points for basic patrolling behaviour");
        }
    }

    // Update is called once per frame
    public void Update()
    {
        //check if close to destination
        if(_travelling && _navMeshAgent.remainingDistance <= 1.0f)
        {
            _travelling = false;

            //if going to wait, wait
            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        //if waiting
        if (_waiting)
        {
            _waitTimer += Time.deltaTime;
            if(_waitTimer >= _totalWaitTime)
            {
                _waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if(_patrolPoints != null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
        }
    }

    /// </summary>
    /// select new patrol point in available list
    /// small probability allows for movement forwards or backwards
    /// <summary>
    private void ChangePatrolPoint()
}
