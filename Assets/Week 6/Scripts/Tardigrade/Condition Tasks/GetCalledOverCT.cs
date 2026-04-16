using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class GetCalledOverCT : ConditionTask {
		public BBParameter<bool> helpCalledBBP;
		public BBParameter<bool> canHelpBPP;
		public BBParameter<Vector3> helpCallPosBBP;
		public BBParameter<float> helpCallRangeBBP;
		public BBParameter<bool> helpCallAnswered;

		public BBParameter<float> checkForHelpTimeBBP;
		private float  timeSinceCheck;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
            timeSinceCheck = 0f;
            return null;		
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			timeSinceCheck += Time.deltaTime;

			if (timeSinceCheck > checkForHelpTimeBBP.value)
			{
				bool checkReq = checkForHelpAsked();
				timeSinceCheck = 0f;
				return checkReq;
			}
			
			return false;
		}

		private bool checkForHelpAsked()
		{
			float distToHelpCall = Vector3.Distance(helpCallPosBBP.value,agent.transform.position);
			if (helpCalledBBP.value == true && canHelpBPP.value == true && distToHelpCall < helpCallRangeBBP.value)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

	}

}