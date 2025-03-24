using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class ChaseAT : ActionTask {

		public BBParameter<Vector3> targetTransform;
		public NavMeshAgent navMeshAgent;
        public BBParameter<float> distanceToDetect;

        public LayerMask detectionLayerMask;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

            int maxColliders = 10;
            Collider[] hitColliders = new Collider[maxColliders];
            int numColliders = Physics.OverlapSphereNonAlloc(agent.transform.position, distanceToDetect.value, hitColliders, detectionLayerMask);

            Collider closestCollider = hitColliders[0];

            for (int i = 0; i < numColliders; i++)
            {
                if (Vector3.Distance(closestCollider.transform.position, agent.transform.position) > Vector3.Distance(hitColliders[i].transform.position, agent.transform.position))
                {
                    closestCollider = hitColliders[i];
                }
            }

            //Debug.Log(targetTransform.value != closestCollider.transform.position);

            if (targetTransform.value != closestCollider.transform.position)
            {
                Debug.Log(closestCollider.transform.position);
                targetTransform.value = closestCollider.transform.position;
            }

            navMeshAgent.SetDestination(targetTransform.value);


			//EndAction(true);
		}

		protected override void OnUpdate() {
            //Debug.Log(Vector3.Distance(agent.transform.position, targetTransform.value.position));
            if (Vector3.Distance(agent.transform.position, targetTransform.value) < 1)
			{
				Debug.Log("AHH!");
                //EndAction(true);
            }

        }

	}
}