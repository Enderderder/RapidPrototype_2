using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OfficemanMovement : MonoBehaviour {
    Animator anim;

    [SerializeField]
    bool _patrolWaiting;

    [SerializeField]
    float _totalWaitTime = 3;

    [SerializeField]
    float _switchProbability = 0.3f;

    [SerializeField]
    List<Transform> _patrolPoints;

    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex;
    bool _travelling;
    bool _waiting;
    bool _patrolForward;
    float _waitTimer;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        _navMeshAgent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached");
        }
        else
        {
            if (_patrolPoints != null && _patrolPoints.Count >= 2) {
                _currentPatrolIndex = 0;
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

    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f,1f) <= _switchProbability)
        {
            _patrolForward = !_patrolForward;
        }

        if (_patrolForward)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
        }
        else
        {
            if(--_currentPatrolIndex < 0)
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
        }
    }

    public void Update()
    {
        if (_travelling)
        {
            anim.SetBool("Iswalking", true);
        }
        else
        {
            anim.SetBool("Iswalking", false);
        }

        if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
        {
            _travelling = false;

            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        if (_waiting) {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= _totalWaitTime)
            {
                _waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }


}
