using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.SceneManagement;


namespace NodeCanvas.Tasks.Actions {

	public class RestardSceneAT : ActionTask {

		protected override void OnExecute() {

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

            EndAction(true);
		}


	}
}