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


    [Name("����ִ��")]
    [Category("_����/��Ϊ����")]
    [Description("��ȡ��ǰʱ��͵�ǰ֡����ʱ��")]
    public class OnceAction : ActionTask
    {
        public enum DuplicateExecute
        {
            ReturnFalse,
            ReturnTrue
        }

        [Name("�ظ�ִ�з��ؽ��")]
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