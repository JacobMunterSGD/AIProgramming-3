using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckCollidedTagCT : ConditionTask {

		float blobRadius;
		public BBParameter<GameObject> body;
		public BBParameter<GameObject> absorbedSmallBlob;

		public LayerMask smallBlobLayerMask;

		protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck() {

			blobRadius = body.value.transform.localScale.x/2;

			Collider[] hitColliders = Physics.OverlapSphere(agent.transform.position, blobRadius, smallBlobLayerMask);

            foreach (Collider c in hitColliders)
			{
				absorbedSmallBlob.value = c.gameObject;
			}

			if (hitColliders.Length > 0) return true;
			else return false;
		}
	}
}