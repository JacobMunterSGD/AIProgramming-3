using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class TimerElapsedCT : ConditionTask {

		public float timeToEnd;
		public BBParameter<float> timeAtStart;

		protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			timeAtStart.value = Time.time;
		}

		protected override bool OnCheck() {

			if (Time.time - timeAtStart.value > timeToEnd)
			{
				return true;
			}
			else return false;
		}
	}
}