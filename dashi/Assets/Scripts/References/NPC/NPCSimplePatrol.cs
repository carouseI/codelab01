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
        _navMeshAgent = this.GetComponent<NavMeshAgent>(); //check agents

        if (_navMeshAgent == null) //if not null
        {
            Debug.LogError("nav mesh agent comp not attached to " + gameObject.name); //show this debug msg
        }
        else
        {
            if (_patrolPoints != null && _patrolPoints.Count >= 2) //if null; need min 2
            {
                _currentPatrolIndex = 0; //check list
                SetDestination(); //set destination
            }
            else
            {
                Debug.Log("insufficient patrol points for basic patrolling behaviour"); //show this debug msg
            }
        }
    }

    // Update is called once per frame
    public void Update()
    {
        //check if close to destination
        if (_travelling && _navMeshAgent.remainingDistance <= 1.0f) //if travelling + certain distance reached
        {
            _travelling = false;

            //if changing to wait
            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f; //reset wait timer
            }
            else //it not
            {
                ChangePatrolPoint(); //change point
                SetDestination(); //set new destination
            }
        }

        //if waiting
        if (_waiting)
        {
            _waitTimer += Time.deltaTime; //increment wait timer by delta time
            if (_waitTimer >= _totalWaitTime) //if timer exceeds total wait time (3 sec)
            {
                _waiting = false; //no longer waiting

                ChangePatrolPoint(); //change point
                SetDestination(); //set new destination
            }
        }
    }

    private void SetDestination()
    {
        if (_patrolPoints != null) //if not null
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position; //provided patrol points, get waypoint index + target vector
            _navMeshAgent.SetDestination(targetVector); //set new destination to target vector
            _travelling = true; //reset travelling to true
        }
    }

    /// </summary>
    /// select new patrol point in available list
    /// small probability allows for movement forwards or backwards
    /// <summary>
    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= _switchProbability) //use rando, generate range between 0-1, check if less/equal to switch prob
        {
            _patrolForward = !_patrolForward; //choose to patrol forwards or backwards, make opposite of whatever value it is; negate boolean value
        }

        if (_patrolForward) //if forward patrol
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
            //get index + increment by 1; check if exceeds point count
            //modulos command = if exceed, reset to 0


            //alt method
            //_currentPatrolIndex++;

            //if(_currentPatrolIndex >= _patrolPoints.Count)
            //{
            //    _currentPatrolIndex = 0;
            //}

        }

        else
        {
            if (--_currentPatrolIndex < 0) //decrement index, then check if less than 0
            {
                _currentPatrolIndex = _patrolPoints.Count - 1; //if less than, set to count - 1
            }

            //alt method
            //_currentPatrolIndex--;

            //if(_currentPatrolIndex > 0)
            //{
            //    _currentPatrolIndex = _patrolPoints.Count - 1;
            //}
        }
    }
}