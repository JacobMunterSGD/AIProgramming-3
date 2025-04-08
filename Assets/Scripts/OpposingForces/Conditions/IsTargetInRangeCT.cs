using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class IsTargetInRangeCT : ConditionTask {

		public BBParameter<Transform> currentTarget;

        public BBParameter<float> distanceToDetect;

        public LayerMask detectionLayerMask;

        protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck() {

			int maxColliders = 10;
            Collider[] hitColliders = new Collider[maxColliders];
            int numColliders = Physics.OverlapSphereNonAlloc(agent.transform.position, distanceToDetect.value, hitColliders, detectionLayerMask);

            Collider closestCollider = hitColliders[0];

            if (numColliders == 0)
            {
				currentTarget.value = null;
                return false;
			}

            for (int i = 0; i < numColliders; i++)
            {
                if (Vector3.Distance(closestCollider.transform.position, agent.transform.position) > Vector3.Distance(hitColliders[i].transform.position, agent.transform.position))
                {
                    closestCollider = hitColliders[i];
                    
                }
			}
            
            if (currentTarget.value != closestCollider.transform)
            {
                currentTarget.value = closestCollider.transform;
            }

            if (numColliders != 0) return true;
            else return false;

        }
	}
}