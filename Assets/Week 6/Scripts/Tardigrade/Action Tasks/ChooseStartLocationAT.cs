using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChooseStartLocationAT : ActionTask {

		public BBParameter<Transform> baseCenterBBP;
		public BBParameter<float> baseRangeBBP;
		public BBParameter<float> startDestinationRangeBBP;
		public BBParameter<Vector3> chosenStartDestBBP;
		 
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
			CheckLocation();
		}

		private void CheckLocation()
		{
			float startRange = startDestinationRangeBBP.value;
			Vector3 startLocation = Vector3.zero;
			startLocation.x = Random.Range(-startRange, startRange);
			startLocation.z = Random.Range(-startRange, startRange);
			startLocation.y = 0f;

			if (Vector3.Distance(startLocation, baseCenterBBP.value.transform.position) > baseRangeBBP.value)
			{
				chosenStartDestBBP.value = startLocation;
				EndAction(true);
			}
		}
	}
}