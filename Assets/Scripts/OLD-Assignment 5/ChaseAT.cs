using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class ChaseAT : ActionTask {

		public BBParameter<Transform> targetTransform;
		public NavMeshAgent navMeshAgent;

        public BBParameter<float> timeBetweenGettingNewDestination;
        float timeWhenDestinationWasLastSet;

        public BBParameter<float> chaseMoveSpeed;
       

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

            navMeshAgent.speed = chaseMoveSpeed.value;
            GetNewDestination();

        }

		protected override void OnUpdate() {

            if (Time.time - timeWhenDestinationWasLastSet > timeBetweenGettingNewDestination.value) GetNewDestination();

            if (targetTransform.value == null) return;

            if (Vector3.Distance(agent.transform.position, targetTransform.value.position) < 1)
			{
                EndAction(true);
            }

        }

        void GetNewDestination()
        {
            if (targetTransform.value == null)
            {
                navMeshAgent.SetDestination(agent.transform.position);
                EndAction(true);
            }
            else
            {
                navMeshAgent.SetDestination(targetTransform.value.position);
            }

            timeWhenDestinationWasLastSet = Time.time;
        }

	}
}