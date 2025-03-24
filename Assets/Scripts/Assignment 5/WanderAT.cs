using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {

		public NavMeshAgent navMeshAgent;
		public BBParameter<float> wanderRadius;


		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			Vector3 wanderTarget = new Vector3(Random.Range(-wanderRadius.value, wanderRadius.value), agent.transform.position.y, Random.Range(-wanderRadius.value, wanderRadius.value));

			navMeshAgent.SetDestination(wanderTarget);

			EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

	}
}