using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CheckDistanceCT : ConditionTask {

		public BBParameter<Transform> guardTransform;
        public BBParameter<Transform> playerTransform;

		public BBParameter<float> distanceToDetect;

        protected override string OnInit(){
			return null;
		}
		protected override bool OnCheck() {
			if (Vector3.Distance(playerTransform.value.position, guardTransform.value.position) < distanceToDetect.value) return true;
			else return false;
		}
	}
}