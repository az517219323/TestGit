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
    [Name("����Ϊ")]
    [Category("_����/��Ϊ����")]
    [Description("ֱ�ӷ������õĽ��")]
    public class EmptyAction : ActionTask
    {
        [Name("���ؽ��")]
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