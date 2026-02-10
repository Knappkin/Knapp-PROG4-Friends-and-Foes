using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SpawnDebrisAT : ActionTask {

		public BBParameter<bool> isNightBBP;
		public BBParameter<GameObject> debrisPrefab;

		public float minDebrisSpawnRange;
		public float maxDebrisSpawnRange;
		public float minDebrisSpawnTime;
		public float maxDebrisSpawnTime;
		private float debrisSpawnTime;
		public float debrisTimer;
	


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			debrisTimer = 0;
			SetTimer();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			if (isNightBBP.value)
			{
				debrisTimer += Time.deltaTime;
				if (debrisTimer > debrisSpawnTime)
				{
					SetTimer();
					SpawnDebris();
				}
				
			}
		}
		private void SetTimer()
		{
			float newTimer = Random.Range(minDebrisSpawnTime, maxDebrisSpawnTime);
			debrisSpawnTime = newTimer;
			debrisTimer = 0;
		}

		private void SpawnDebris()
		{
		GameObject debrisInstance = GameObject.Instantiate(debrisPrefab.value);
		}
		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.1
		protected override void OnPause() {
			
		}
	}
}