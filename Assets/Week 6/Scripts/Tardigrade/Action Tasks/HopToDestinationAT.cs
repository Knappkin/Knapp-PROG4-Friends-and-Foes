using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class HopToDestinationAT : ActionTask {

		private Animation animation;
		public BBParameter<Vector3> destinationBBP;
		private NavMeshAgent meshAgent;
		public BBParameter<float> destinationBufferBBP;
	

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			
			meshAgent = agent.GetComponent<NavMeshAgent>();
			animation = agent.GetComponent<Animation>();

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            animation["HoppingTardigrade"].wrapMode = WrapMode.Loop;
            animation.Play("HoppingTardigrade");
			meshAgent.SetDestination(destinationBBP.value);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			if (Vector3.Distance(agent.transform.position, destinationBBP.value) < destinationBufferBBP.value) 
			{
				EndAction(true);
			}

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			animation["HoppingTardigrade"].wrapMode = WrapMode.Once;
			Vector3 ensureOnGround = agent.transform.position;
			ensureOnGround.y = 0;
			agent.transform.position = ensureOnGround;

		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}