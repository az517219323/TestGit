using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace KLGame.OP.Battle.BTAI
{

	[Name("ºÏ≤Èæ‡¿Î")]
	[Category("_¿•¬ÿ/≤‚ ‘")]
	public class CheckDistanceTask : ConditionTask{

		[Name("æ‡¿Î")]
		public float distance = 10;

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
			return ran < distance;
		}
	}
}