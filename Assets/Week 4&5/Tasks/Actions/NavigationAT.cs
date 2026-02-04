using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class NavigationAT : ActionTask {

		public BBParameter<Vector3> targetPositionBBP;
		public BBParameter<float> timeSinceLastSampleBBP;
		public BBParameter<bool> isMovingBBP;

		public float sampleRateInSeconds;
		public float sampleRadiusInUnits;

		private Vector3 lastTargetPosition;
		private NavMeshAgent navAgent;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();

			if (navAgent == null)
			{
				return $"{agent.name} - NavigationTask: Unable to get NavMesh Agent Reference!";
			}
			else
			{
				return null;
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			timeSinceLastSampleBBP.value += Time.deltaTime;
			if (timeSinceLastSampleBBP.value > sampleRateInSeconds)
			{
				timeSinceLastSampleBBP.value = 0;

				if (lastTargetPosition != targetPositionBBP.value)
				{
					lastTargetPosition = targetPositionBBP.value;
					if (NavMesh.SamplePosition(targetPositionBBP.value, out NavMeshHit hitInfo, sampleRadiusInUnits, NavMesh.AllAreas))
					{
						navAgent.SetDestination(hitInfo.position);
					}
				}

				isMovingBBP.value =
					navAgent.remainingDistance != 0 &&
					navAgent.remainingDistance != Mathf.Infinity ||
					navAgent.pathPending;
			}
		}
	}
}