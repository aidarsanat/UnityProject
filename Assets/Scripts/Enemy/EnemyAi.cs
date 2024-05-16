using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class EnemyAi : MonoBehaviour 

{
    private NavMeshAgent _agent;
    private Animator _animator;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float range = 10f; 

    public Transform centrePoint; 
    Transform player;
    float chaseRange = 10;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = movementSpeed;
        _animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        _animator.SetFloat("Speed",_agent.velocity.magnitude/movementSpeed);
        if(_agent.remainingDistance <= _agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos            
                _agent.SetDestination(point); 
                float distance = Vector3.Distance(_animator.transform.position, player.position);
                if (distance < chaseRange)
                    _animator.SetBool("isChasing", true);
            }
        }

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        { 

            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    
}
// {
 //    private NavMeshAgent _navMeshAgent;
 //    private Animator _animator;
 //    [SerializeField] private float movementSpeed;
 //    
 //    [SerializeField] private float changePositionTime = 5f;
 //    [SerializeField] private float moveDistance = 10f;
 //    
 //    
 //  
 //    private void Start()
 //    {
 //       _navMeshAgent = GetComponent<NavMeshAgent>();
 //       _navMeshAgent.speed = movementSpeed;
 //       _animator = GetComponent<Animator>();
 //       InvokeRepeating(nameof(MoveAnimal),changePositionTime,changePositionTime);
 //    }
 //  
 //    private void Update()
 //    {
 //       _animator.SetFloat("Speed",_navMeshAgent.velocity.magnitude/movementSpeed);
 //    }
 //  
 //    Vector3 RandomNavSphere (float distance) {
 //       Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
 //            
 //       randomDirection += transform.position;
 //            
 //       NavMeshHit navHit;
 //            
 //       NavMesh.SamplePosition (randomDirection, out navHit, distance, -1);
 //            
 //       return navHit.position;
 //    }
 //  
 //    private void MoveAnimal()
 //    {
 //       _navMeshAgent.SetDestination(RandomNavSphere(moveDistance));
 //    }
 // }