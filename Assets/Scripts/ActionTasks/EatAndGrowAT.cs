using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class EatAndGrowAT : ActionTask {


		private BlobertStats blobStats;
		private float goalSize;
		private float growRate = 5f;
		private Vector3 blobScale;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			blobStats = agent.GetComponent<BlobertStats>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			blobScale = agent.transform.localScale;

			blobStats.canEat = false;
			blobStats.eat = false;
			if (agent.transform.localScale.x * 1.2f < blobStats.maxSize)
			{
                goalSize = agent.transform.localScale.x * 1.2f;
            }
			else
			{
				goalSize = blobStats.maxSize;
			}
			
			Debug.Log(goalSize);

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			if (agent.transform.localScale.x < goalSize)
			{
				if (blobScale.x + growRate < goalSize)
				{

					blobScale.x += growRate*Time.deltaTime;
					blobScale.y += growRate * Time.deltaTime;
					blobScale.z += growRate * Time.deltaTime;

					agent.transform.localScale = blobScale;
				}
				else
				{
                    blobScale.x = goalSize;
                    blobScale.y = goalSize;
                    blobScale.z = goalSize;

					blobStats.canEat = true;
					EndAction(true);
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