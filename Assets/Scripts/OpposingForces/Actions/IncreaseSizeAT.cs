using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class IncreaseSizeAT : ActionTask {

		float blobRadius;
		public BBParameter<GameObject> body;

		public BBParameter<float> increaseSizeAmount;

		public float TimeToGrow;
		
		protected override void OnExecute() {

			blobRadius = body.value.transform.localScale.x;

			LeanTween.value(agent.gameObject, blobRadius, blobRadius + increaseSizeAmount.value, TimeToGrow).setOnUpdate(UpdateBlobSize).setOnComplete(EndActionTrue).setEaseOutElastic();
		}

		void EndActionTrue()
		{
			EndAction(true);
		}

		void UpdateBlobSize(float radius)
		{
			blobRadius = radius;
			body.value.transform.localScale = new Vector3(blobRadius, blobRadius, blobRadius);
		}


	}
}