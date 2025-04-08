using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SetVarToCurrentTimeAT : ActionTask {

		public BBParameter<float> currentTime;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			currentTime.value = Time.time;

			EndAction(true);
		}

	}
}