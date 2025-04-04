using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class PatrolAT : ActionTask {

		public NavMeshAgent navAgent;
		public Transform patrolLocation;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			navAgent.SetDestination(patrolLocation.position);
		}

		protected override void OnUpdate() {
			if (Vector3.Distance(navAgent.destination, agent.transform.position) < 1) EndAction(true);
        }

		protected override void OnStop() {
            navAgent.SetDestination(agent.transform.position);
        }

	}
}