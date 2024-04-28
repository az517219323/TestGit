using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-07-29 17:21
    //******************************************
    [Name("两数相加")]
    [Category("_昆仑/行为任务")]
    [Description("原值上增加目标添加值")]
    public class AddInteger: ActionTask
    {
        [BlackboardOnly]
        [Name("原值")]
        public BBParameter<int> Value;
        [Name("增加值")]
        public BBParameter<int> AddValue;
        
        /*
        protected override string info {
            get { return Value + " + " + AddValue; }
        }
        
        protected override void OnExecute()
        {
            Value.value += AddValue.value;
            EndAction(true);
        }
        */
    }
}