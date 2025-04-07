using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AttackAT : ActionTask {

		public BBParameter<Transform> currentTarget;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			Debug.Log("Attack!");

			Vector3 attackKnockback = (new Vector3(currentTarget.value.position.x, 0, currentTarget.value.position.z)
									- new Vector3(agent.transform.position.x, 0, agent.transform.position.z))
									.normalized * 3;

			currentTarget.value.position = currentTarget.value.position + attackKnockback;


			EndAction(true);
		}

	}
}