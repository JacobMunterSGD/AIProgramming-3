using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class StunRecoverAT : ActionTask {

		protected override string OnInit() {
			return null;
		}


		protected override void OnExecute() {

			// animation to be stunned

			EndAction(true);
		}

		protected override void OnUpdate() {
			
		}


	}
}