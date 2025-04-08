using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class RunAwayAT : ActionTask {

		public NavMeshAgent navMeshAgent;
		public float runAwayMoveSpeed;

		public BBParameter<Transform> currentTarget;

		public float distanceToFindNewTarget;

		public float minTimeToFindNewTarget;
		float lastTimeWhenTargetWasChosen;

		protected override void OnExecute() {

			navMeshAgent.ResetPath();
			navMeshAgent.speed = runAwayMoveSpeed;

			ChooseTarget();
		}

		void ChooseTarget()
		{
			Vector3 runDirection = (agent.transform.position - currentTarget.value.position).normalized;
			navMeshAgent.SetDestination(agent.transform.position + runDirection * 10);
			lastTimeWhenTargetWasChosen = Time.time;
		}

		protected override void OnUpdate()
		{
			if (Vector3.Distance(agent.transform.position, currentTarget.value.position) < distanceToFindNewTarget
				&& Time.time - lastTimeWhenTargetWasChosen > minTimeToFindNewTarget)
			{
				ChooseTarget();
			}
		}
	}
}