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
    [Name("�������")]
    [Category("_����/��Ϊ����")]
    [Description("ԭֵ������Ŀ�����ֵ")]
    public class AddInteger: ActionTask
    {
        [BlackboardOnly]
        [Name("ԭֵ")]
        public BBParameter<int> Value;
        [Name("����ֵ")]
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