using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace KLGame.OP.Battle.BTAI
{

	[Name("�ȴ�һ��ʱ��")]
	[Category("_����/����")]
	public class WaitTimeTask : ActionTask{

		[Name("�ȴ�ʱ��")]
		private float time;

		[Name("�ƶ���Сʱ��")]
		public BBParameter<float> minTime;
		[Name("�ƶ����ʱ��")]
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