using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-07-29 17:21
    //******************************************
    [Name("����CD")]
    [Category("_����/��Ϊ����")]
    [Description("����CDֵ�������سɹ�")]
    public class UpdateCD: ActionTask
    {
        public BBParameter<float> CD;
        

        protected override string info {
            get { return CD + ""; }
        }
        
        protected override void OnExecute()
        {
            CD.value -= Time.deltaTime;
            EndAction(true);
        }
    }
}