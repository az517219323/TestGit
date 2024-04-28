using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace KLGame.OP.Battle.BTAI
{

	[Name("寻找目标")]
	[Category("_昆仑/测试")]
	public class FindTargetTask : ActionTask{

		[Name("目标名称")]
		public string targetName = "Player";
		[Name("目标对象")]
		public BBParameter<UnityEngine.Transform> target;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			UnityEngine.GameObject go = UnityEngine.GameObject.Find(targetName);
			if (go != null) 
			{
				target.value = go.transform;
			}
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){
			
		}

		//Called when the task is disabled.
		protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}