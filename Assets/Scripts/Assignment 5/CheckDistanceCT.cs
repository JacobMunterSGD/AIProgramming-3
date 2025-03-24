using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CheckDistanceCT : ConditionTask {

		public BBParameter<Transform> agentTransform;
        public BBParameter<Transform> targetTransform;
        public BBParameter<Transform> currentTarget;

        public BBParameter<float> distanceToDetect;

        protected override string OnInit(){
			return null;
		}
		protected override bool OnCheck() {

            if (Vector3.Distance(targetTransform.value.position, agentTransform.value.position) < distanceToDetect.value)
			{
				currentTarget.value = targetTransform.value;
                return true;
			}
			else return false;
		}
	}
}