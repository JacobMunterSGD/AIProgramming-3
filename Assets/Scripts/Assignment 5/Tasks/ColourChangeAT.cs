using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ColourChangeAT : ActionTask {

		public BBParameter<float> scanRange;
        public BBParameter<float> distanceToTarget;

        Color startColor;
		public Color targetColor = Color.white;
		public Renderer renderer;

		public float durationInSeconds = 1f;
		float startTime;

		protected override string OnInit()
		{
			startColor = renderer.material.color;
			return null;
		}

		protected override void OnExecute()
		{
            //renderer.material.color = targetColor;
			startTime = Time.time;
        }

		protected override void OnUpdate()
		{
			float elapsedTime = Time.time;
			float stepValue = Mathf.PingPong(Time.time, 1f);

			renderer.material.color = Color.Lerp(startColor, targetColor, stepValue);
		}

        protected override void OnStop()
        {
            renderer.material.color = startColor;
        }

    }
}