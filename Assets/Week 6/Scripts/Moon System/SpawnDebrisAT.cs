using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.AI.Navigation;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SpawnDebrisAT : ActionTask {

		public BBParameter<bool> isNightBBP;
		public BBParameter<GameObject> debrisPrefab;
		public BBParameter<float> baseRangeBBP;
		public BBParameter<Transform> baseCenterBBP;
		public BBParameter<NavMeshSurface> moonNavSurfaceBBP;

		public float minDebrisSpawnRange;
		public float maxDebrisSpawnRange;

		public float debrisSpawnRange;

		public float minDebrisSpawnTime;
		public float maxDebrisSpawnTime;
		private float debrisSpawnTime;
		private float debrisTimer;
	


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
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//Debug.Log(debrisTimer);
			if (isNightBBP.value)
			{
				debrisTimer += Time.deltaTime;
				if (debrisTimer > debrisSpawnTime)
				{
					
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
			Vector3 spawnLocation;
			spawnLocation.x = Random.Range(-debrisSpawnRange, debrisSpawnRange);
			spawnLocation.z = Random.Range(-debrisSpawnRange, debrisSpawnRange);
			spawnLocation.y = 0f;
			if (Vector3.Distance(spawnLocation, baseCenterBBP.value.transform.position) > baseRangeBBP.value)
			{
                GameObject debrisInstance = GameObject.Instantiate(debrisPrefab.value);
				Debug.Log(spawnLocation);
				debrisInstance.transform.localEulerAngles = new Vector3(0f,Random.Range(0, 360),0f);
                debrisInstance.transform.position = spawnLocation;
                Debug.Log("Debris Spawned");
                SetTimer();
				RecalcNavSurface();
            }
			
		}

		private void RecalcNavSurface()
		{
			moonNavSurfaceBBP.value.BuildNavMesh();
		}
		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.1
		protected override void OnPause() {
			
		}
	}
}