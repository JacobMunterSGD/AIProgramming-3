using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor.UIElements;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class BlobShootAT : ActionTask {

		public BBParameter<float> blobRadius;
		public BBParameter<GameObject> blobBody;
		public float shrinkTelegraphPercentage;

		public Color shrunkenColor;
		Color startColor;

		public float timeToShrink;
		public float timeToExpand;

		float originalRadius;

		protected override string OnInit() {

			blobRadius.value = blobBody.value.transform.localScale.x;
			startColor = blobBody.value.GetComponent<MeshRenderer>().material.color;

			return null;
		}
	
		protected override void OnExecute() {

			originalRadius = blobRadius.value;
			ShrinkTelegraph();
			

			//EndAction(true);
		}

		void ShrinkTelegraph()
		{
			LeanTween.value(agent.gameObject, blobRadius.value, blobRadius.value * shrinkTelegraphPercentage, timeToShrink).setOnUpdate(UpdateBlobSize).setOnComplete(StartShoot).setEaseInOutCubic();
			LeanTween.color(blobBody.value, shrunkenColor, timeToShrink).setEaseOutCubic();
		}

		void StartShoot()
		{
			// shoot thing

			// animation
			LeanTween.value(agent.gameObject, blobRadius.value, originalRadius, timeToExpand).setOnUpdate(UpdateBlobSize).setEaseOutElastic();
			LeanTween.color(blobBody.value, startColor, timeToExpand).setEaseOutElastic();
		}

		void UpdateBlobSize(float radius)
		{
			blobRadius.value = radius;
			blobBody.value.transform.localScale = new Vector3(blobRadius.value, blobRadius.value, blobRadius.value);
		}
	}
}