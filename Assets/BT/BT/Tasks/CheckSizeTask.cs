using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace KLGame.OP.Battle.BTAI
{

	[Name("检查大小")]
	[Category("_昆仑/测试")]
	public class CheckSizeTask : ConditionTask{

		[Name("大小")]
		public float size = 50; 

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable(){
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable(){
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck()
		{
			float ran = UnityEngine.Random.Range(0, 100.0f);
			return ran < size;
		}
	}
}