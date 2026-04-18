using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class setUiImageAT : ActionTask {

		public BBParameter<Image> imageBBP;
		public BBParameter<Sprite> newImgSpriteBBP;
	
		protected override void OnExecute() {
			imageBBP.value.sprite = newImgSpriteBBP.value;
		}

	}
}