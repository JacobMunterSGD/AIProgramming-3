using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class StunRecoverAT : ActionTask {

		public Color stunColor;
		Color startColor;

		public BBParameter<GameObject> body;
		MeshRenderer meshRenderer;

		public BBParameter<float> stunWaitTime;

		protected override string OnInit() {

			meshRenderer = body.value.GetComponent<MeshRenderer>();

			startColor = meshRenderer.material.color;

            return null;
		}

		protected override void OnExecute() {

			LeanTween.color(body.value, stunColor, stunWaitTime.value/2).setOnComplete(RecoverAnimation).setEaseOutElastic();

		}

		void RecoverAnimation()
		{
            LeanTween.color(body.value, startColor, stunWaitTime.value/2).setOnComplete(EndActionTrue).setEaseInCubic();
        }

		void EndActionTrue()
		{
            EndAction(true);
        }
	}
}