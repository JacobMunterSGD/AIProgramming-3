using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ScaleChangeAT : ActionTask {

		public Transform transform;
		public float targetScale = 2f;

		private float originalScale;

		protected override string OnInit()
		{
			originalScale = transform.localScale.x;
			return null;
		}

        protected override void OnExecute()
        {

        }

        protected override void OnUpdate()
		{
			float stepValue = Mathf.PingPong(Time.time, 1f);
			float currentScale = Mathf.Lerp(originalScale, targetScale, stepValue);

			transform.localScale = new Vector3(currentScale, currentScale, currentScale);
		}

		protected override void OnStop()
		{
			//transform.localScale = new Vector3(originalScale, originalScale, originalScale);
		}
	}
}