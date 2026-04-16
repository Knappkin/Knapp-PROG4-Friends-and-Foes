using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SearchAT : ActionTask {

		public BBParameter<GameObject> spottedTargetBBP;
		public BBParameter<bool> spotDebrisBBP;
		public BBParameter<bool> spotFallenFriendBBP;
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
			StartCoroutine(ScanTimer());
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			Collider[] hits = Physics.OverlapSphere(agent.transform.position, scanRangeBBP.value);

			Collider chosenHit;

			if (hits.Length > 0)
			{
				chosenHit = hits[0];
				for (int i = 0; i < hits.Length; i++)
				{
                    float agentToIDist = Vector3.Distance(agent.transform.position, hits[i].gameObject.transform.position);
                    float agentToChosenDist = Vector3.Distance(agent.transform.position, chosenHit.gameObject.transform.position);
                    if (hits[i].gameObject.layer == 11)
					{
						if (chosenHit.gameObject.layer != 11)
						{
							chosenHit = hits[i];
						}

						else
						{
							if (agentToIDist < agentToChosenDist)
							{
								chosenHit = hits[i];
							}
						}
					}

					
					else if (hits[i].gameObject.layer == 10)
					{
                        if (agentToIDist < agentToChosenDist)
						{
							chosenHit = hits[i];
						}
                        
					}
				}
                uiManagerBBP.value.DrawExclamationUI(agent.transform);


				if (chosenHit.gameObject.layer == 11)
				{
					spottedTargetBBP.value = chosenHit.gameObject;
					spotFallenFriendBBP.value = true;
					//EndAction(true);
				}

				else if (chosenHit.gameObject.layer == 10)
				{
                    spottedTargetBBP.value = chosenHit.gameObject;
                    spotDebrisBBP.value = true;
					//EndAction (true);
				}

				else
				{
                    spottedTargetBBP.value = null;
                    spotDebrisBBP.value = false;
					spotFallenFriendBBP.value = false;
				}
               // spotDebrisBBP.value = true;
            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		private void ScanArea()
		{

		}
		private IEnumerator ScanTimer()
		{
			yield return new WaitForSeconds(3);
			Debug.Log("Scan Failed");
			EndAction();
		}
	}
}