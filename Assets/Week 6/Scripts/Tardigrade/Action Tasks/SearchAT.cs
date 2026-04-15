using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SearchAT : ActionTask {

		public BBParameter<GameObject> spottedTargetBBP;
		public BBParameter<bool> spotDebrisBBP;
		public BBParameter<bool> spotDownedFriendBBP;
		public BBParameter<float> scanRangeBBP;
		public BBParameter<UiManager> uiManagerBBP;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Collider[] hits = Physics.OverlapSphere(agent.transform.position, scanRangeBBP.value);

			if (hits.Length > 0)
			{
				for (int i = 0; i < hits.Length; i++)
				{

					if (hits[i].gameObject.layer == 10)
					{
						uiManagerBBP.value.DrawExclamationUI(agent.transform);
						spotDebrisBBP.value = true;
					}
				}
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}