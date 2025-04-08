using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {

		public NavMeshAgent navMeshAgent;
		public BBParameter<float> wanderRadius;
		public BBParameter<float> walkMoveSpeed;

		public float waitTimeBetweenWanderSpots;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			navMeshAgent.speed = walkMoveSpeed.value;

			Vector3 wanderTarget = new Vector3(Random.Range(-wanderRadius.value, wanderRadius.value), agent.transform.position.y, Random.Range(-wanderRadius.value, wanderRadius.value));
			wanderTarget += agent.transform.position;

			navMeshAgent.SetDestination(wanderTarget);

			StartCoroutine(WaitUntilNextWander(waitTimeBetweenWanderSpots));

		}

		IEnumerator WaitUntilNextWander(float time)
		{
			yield return new WaitForSeconds(time);

			EndAction(true);

		}

	}
}