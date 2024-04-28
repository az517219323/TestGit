using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-09-17 16:38
    //******************************************


    [Name("单次执行")]
    [Category("_昆仑/行为任务")]
    [Description("获取当前时间和当前帧更新时间")]
    public class OnceAction : ActionTask
    {
        public enum DuplicateExecute
        {
            ReturnFalse,
            ReturnTrue
        }

        [Name("重复执行返回结果")]
        public DuplicateExecute DuplicateExecuteResult;
        /*
        private bool _Executed;
        protected override void OnExecute()
        {
            if (_Executed)
            {
                EndAction(DuplicateExecuteResult == DuplicateExecute.ReturnTrue);
                return;
            }

            _Executed = true;
            EndAction(true);
        }
        */
    }
}