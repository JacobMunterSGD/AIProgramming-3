using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AttackAT : ActionTask {

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			Debug.Log("Attack!");

			EndAction(true);
		}

	}
}