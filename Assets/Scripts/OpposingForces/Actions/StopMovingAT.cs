using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class StopMovingAT : ActionTask
	{

		NavMeshAgent navMeshAgent;

		protected override string OnInit()
		{
			agent.TryGetComponent<NavMeshAgent>(out navMeshAgent);
			return null;
		}

		protected override void OnExecute()
		{

			if (navMeshAgent != null) navMeshAgent.ResetPath();

			EndAction(true);
		}

	}
}