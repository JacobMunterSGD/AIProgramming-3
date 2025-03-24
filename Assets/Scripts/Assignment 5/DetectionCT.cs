using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class DetectionCT : ConditionTask {

        public BBParameter<Transform> agentTransform;
        public BBParameter<Vector3> targetTransform;

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

            if (numColliders == 0) return false;

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
                return true;
            }
            else
            {
                return false;
            }

        }
	}
}