using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Reflection;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DestroyGameObjectAT : ActionTask {

		public BBParameter<GameObject> objectToDestroy;

		protected override void OnExecute() {

			GameObject.Destroy(objectToDestroy.value);

			objectToDestroy.value = null;

			EndAction(true);
		}

	}
}