using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	public Transform[] patrolPoints;
	public int currentPatrolPoint;

	public NavMeshAgent agent;

	public Animator animator;

	public float waitAtPoint = 2f;
	private float waitCounter;

	public float chaseRange;

	public float attackRange = 1f;
	public float timeBetweenAttacks = 2f;
	private float attackCounter;

	public enum AIState
	{
		Idle,
		isPatrolling,
		Chasing,
		Attacking
	};

	public AIState currentState;

	void Start()
	{
		waitCounter = waitAtPoint;
	}


	void Update()
	{
		float distanceToPlayer = Vector3.Distance(transform.position, Controles.instance.transform.position);
		switch (currentState)
		{
			case AIState.Idle:
				animator.SetBool("IsMoving", false);

				if (waitCounter > 0)
				{
					waitCounter -= Time.deltaTime;
				}
				else
				{

					agent.SetDestination(patrolPoints[currentPatrolPoint].position);
					currentState = AIState.isPatrolling;
				}

				if (distanceToPlayer <= chaseRange)
				{
					currentState = AIState.Chasing;
					animator.SetBool("IsMoving", true);
				}
				break;

			case AIState.isPatrolling:
				//agent.SetDestination(patrolPoints[currentPatrolPoint].position);

				if (agent.remainingDistance <= .2f)
				{
					currentPatrolPoint++;
					if (currentPatrolPoint >= patrolPoints.Length)
					{
						currentPatrolPoint = 0;
					}

					//agent.SetDestination(patrolPoints[currentPatrolPoint].position);
					currentState = AIState.Idle;
					waitCounter = waitAtPoint;
				}
				if (distanceToPlayer <= chaseRange)
				{
					currentState = AIState.Chasing;
				}

				animator.SetBool("IsMoving", true);
				break;

			case AIState.Chasing:

				agent.SetDestination(Controles.instance.transform.position);

				if (distanceToPlayer < attackRange)
				{
					currentState = AIState.Attacking;
					animator.SetTrigger("Attack");
					animator.SetBool("IsMoving", false);

					agent.velocity = Vector3.zero;
					agent.isStopped = true;

					attackCounter = timeBetweenAttacks;

				}
				if (distanceToPlayer >= chaseRange)
				{
					currentState = AIState.Idle;
					waitCounter = waitAtPoint;

					agent.velocity = Vector3.zero;
					agent.SetDestination(transform.position);
				}
				break;

			case AIState.Attacking:

				transform.LookAt(Controles.instance.transform, Vector3.up);
				transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
				attackCounter -= Time.deltaTime;
				if (attackCounter < 0)
				{
					if (distanceToPlayer <= attackRange)
					{
						animator.SetTrigger("Attack");
						attackCounter = timeBetweenAttacks;
					}
					else
					{
						currentState = AIState.Idle;
						waitCounter = waitAtPoint;

						agent.isStopped = false;

					}
				}


				break;

		}

	}

}
