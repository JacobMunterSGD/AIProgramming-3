using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class BlobShootAT : ActionTask {

		float blobRadius;
		public BBParameter<GameObject> blobBody;
		public float shrinkTelegraphPercentage;

		public BBParameter<GameObject> currentTarget;

		public Color shrunkenColor;
		Color startColor;

		public float timeToShrink;
		public float timeToExpand;

		float originalRadius;

		public BBParameter<GameObject> projectile;
		public float projectileLaunchForce;

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
			GameObject _projectile = GameObject.Instantiate(projectile.value, agent.transform.position, Quaternion.identity);
			Vector3 launchDirection = (currentTarget.value.transform.position - agent.transform.position).normalized;
			launchDirection = (launchDirection + Vector3.up/3).normalized;
			_projectile.GetComponent<Rigidbody>().AddForce(launchDirection * projectileLaunchForce, ForceMode.Impulse);
			GameObject.Destroy(_projectile, 3);

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