using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace KLGame.OP.Battle.BTAI
{

	[Name("һ��ʱ������Ŀ���ƶ�")]
	[Category("_����/����")]
	public class MoveTask : ActionTask{

		[Name("�ƶ��ٶ�")]
		public float speed = 6;

		[Name("�ƶ���Сʱ��")]
		public BBParameter<float> minTime;
		[Name("�ƶ����ʱ��")]
		public BBParameter<float> maxTime;
		private float time = 1;
	

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
			time = UnityEngine.Random.Range(minTime.value, maxTime.value);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			if (elapsedTime >= time)
			{
				EndAction(true);
			}
			else 
			{
				Vector3 v3 = agent.gameObject.transform.position;
				Vector3 dir = target.value.position - v3;
				dir = dir.normalized;
				v3 += dir * UnityEngine.Time.deltaTime * speed;
				agent.gameObject.transform.position = v3;

				if (Vector3.Distance(target.value.position, v3) < 0.5) 
				{
					EndAction(true);
				}
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