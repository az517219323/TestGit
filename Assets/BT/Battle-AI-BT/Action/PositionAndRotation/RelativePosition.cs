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
    // @Date: 2021-11-10 11:13
    //******************************************
    [Category("_昆仑/行为任务/位置和旋转")]
    [Name("相对坐标")]
    [Description("取目标的的世界坐标位置，并将其本地坐标的偏移转换到新的世界坐标")]
    public class RelativePosition : ActionTask
    {
        [Name("目标")]
        public BBParameter<BattleUnit> Owner;
        [Name("本地坐标偏移")]
        public BBParameter<Vector3> LocalPosition;
        [Name("得到的世界坐标")]
        public BBParameter<Vector3> SetToPosition;
        /*
        #if UNITY_EDITOR
        private void _AddInfo(string info, string add)
        {
            if (!string.IsNullOrEmpty(info))
            {
                info += ", ";
            }

            info += add;
        }

        protected override string info
        {
            get
            {
                var local = LocalPosition.value;
                if (Mathf.Approximately(local.sqrMagnitude, 0))
                {
                    return "和Owner同一位置";    
                }

                string _info = "";

                if (local.z > 0)
                {
                    _AddInfo(_info, "前方" + local.z);
                }
                else if (local.z < 0)
                {
                    _AddInfo(_info, "后方" + (-local.z));
                }
                
                if (local.y > 0)
                {
                    _AddInfo(_info, "上方" + local.y);
                }
                else if (local.y < 0)
                {
                    _AddInfo(_info, "下方" + (-local.y));
                }
                
                if (local.x > 0)
                {
                    _AddInfo(_info, "右方" + local.x);
                }
                else if (local.x < 0)
                {
                    _AddInfo(_info, "左方" + (-local.x));
                }

                _info = "在Owner" + _info;
                return _info;
            }
        }
        #endif
        
        protected override void OnExecute()
        {
            var transform = Owner.value.Transform;
            var worldPos = transform.TransformPoint(LocalPosition.value);
            SetToPosition.value = worldPos;
            EndAction(true);
        }
        */
    }
}