using NodeCanvas.Framework;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-09-16 23:38
    //******************************************
    public abstract class PlayAction : ActionTask
    {
        public enum ResultTypes
        {
            EndImmediately,
            EndUntilFinish
        }
        
        public enum ExeStatus
        {
            Running,
            Succ,
            Fail
        }

        public BBParameter<ResultTypes> ResultType;

        protected override void OnExecute()
        {
            bool succ = _OnExecute();
            if (ResultType.value == ResultTypes.EndImmediately)
            {
                EndAction(succ);
            }
        }

        protected override void OnUpdate()
        {
            var status = _CheckRunningStatus();
            if (status == ExeStatus.Running)
            {
                return;
            }
            EndAction(status == ExeStatus.Succ);
        }

        protected abstract bool _OnExecute();

        protected abstract ExeStatus _CheckRunningStatus();
    }
}