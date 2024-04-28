using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace KLGame.OP.Battle.BTAI
{

	[Name("等待一定时间")]
	[Category("_昆仑/测试")]
	public class WaitTimeTask : ActionTask{

		[Name("等待时间")]
		private float time;

		[Name("移动最小时间")]
		public BBParameter<float> minTime;
		[Name("移动最大时间")]
		public BBParameter<float> maxTime;

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
			time = UnityEngine.Random.Range(minTime.value, maxTime.value);
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){
			if (elapsedTime >= time)
			{
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}