using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions {

	public class BlobShootAT : ActionTask {

		float blobRadius;
		public BBParameter<GameObject> blobBody;
		public float shrinkTelegraphPercentage;

		public Color shrunkenColor;
		Color startColor;

		public float timeToShrink;
		public float timeToExpand;

		float originalRadius;

		protected override string OnInit() {

			blobRadius = blobBody.value.transform.localScale.x;
			startColor = blobBody.value.GetComponent<MeshRenderer>().material.color;

			return null;
		}
	
		protected override void OnExecute() {

			originalRadius = blobRadius;
			ShrinkTelegraph();
			

			//EndAction(true);
		}

		void ShrinkTelegraph()
		{
			LeanTween.value(agent.gameObject, blobRadius, blobRadius * shrinkTelegraphPercentage, timeToShrink).setOnUpdate(UpdateBlobSize).setOnComplete(StartShoot).setEaseInOutCubic();
			LeanTween.color(blobBody.value, shrunkenColor, timeToShrink).setEaseOutCubic();
		}

		void StartShoot()
		{
			// shoot thing

			// animation
			LeanTween.value(agent.gameObject, blobRadius, originalRadius, timeToExpand).setOnUpdate(UpdateBlobSize).setEaseOutElastic().setOnComplete(EndActionTrue);
			LeanTween.color(blobBody.value, startColor, timeToExpand).setEaseOutElastic();
		}

		void UpdateBlobSize(float radius)
		{
			blobRadius = radius;
			blobBody.value.transform.localScale = new Vector3(blobRadius, blobRadius, blobRadius);
		}

		void EndActionTrue()
		{
			EndAction(true);
		}
	}
}