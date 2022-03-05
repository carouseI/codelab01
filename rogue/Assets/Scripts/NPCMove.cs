using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //resolve compilation errors

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent; //reference


    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>(); //find nav mesh component attached to object

        if(_navMeshAgent == null) //if null
        {
            Debug.LogError("nav mesh agent component not attached to " + gameObject.name);
        }
        else //if not null
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if(_destination != null) //if destination is set
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector); //set destination as target vector
        }
    }
}
