using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-08-11 14:34
    //******************************************
    [Name("空行为")]
    [Category("_昆仑/行为任务")]
    [Description("直接返回设置的结果")]
    public class EmptyAction : ActionTask
    {
        [Name("返回结果")]
        public bool ReturnTrue;
        
        protected override string info {
            get { return "" + ReturnTrue; }
        }
        
        protected override void OnExecute()
        {
            EndAction(ReturnTrue);
        }
    }
}