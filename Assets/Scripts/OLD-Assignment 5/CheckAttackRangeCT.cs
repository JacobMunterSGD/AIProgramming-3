using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CheckAttackRangeCT : ConditionTask {

		public BBParameter<Transform> currentTarget;
		public BBParameter<float> attackRange;

		protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck() {

			if (Vector3.Distance(currentTarget.value.position, agent.transform.position) < attackRange.value) return true;
			else return false;
		}
	}
}