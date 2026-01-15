using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.Mathematics;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class PlayWithToyAT : ActionTask {

		private BlobertStats blobstats;
		public GameObject toy;
		private float energyCost = 10f;
		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			blobstats = agent.GetComponent<BlobertStats>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			toy.transform.Rotate(0,1,0);
			blobstats.energy -= energyCost * Time.deltaTime;

			if (blobstats.energy <= 0)
			{
				blobstats.energy = 0;
				EndAction(true);
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