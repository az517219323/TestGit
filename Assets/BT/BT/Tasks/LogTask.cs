using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;

namespace KLGame.OP.Battle.BTAI
{

	[Name("输出日志")]
	[Category("_昆仑/测试")]
	public class LogTask : ActionTask{
		[Name("信息")]
		public string message = "";
		public int[] intArray;
		public BBParameter<List<UnityEngine.Vector3>> rangs;


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
			UnityEngine.Debug.Log("LogTask OnExecute "+ message);
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