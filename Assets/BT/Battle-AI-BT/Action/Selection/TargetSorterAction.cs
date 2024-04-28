using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-11-09 18:34
    //******************************************
    [Category("_昆仑/行为任务/目标选择、过滤、排序")]
    [Name("目标排序与限制")]
    public class TargetSorterAction : ActionTask
    {
        public struct SortInfo
        {
            public bool Desc;
            public SortType Type;
            [ShowIf("Type", (int)SortType.Property)]
            public List<PropertyType> Info;
        }
        public enum SortType
        {
            Distance,
            Property
        }
        public enum PropertyType
        {
            HP,
            Attack
        }

        [Name("参数条件会不会在运行时修改，如果不会，不开启动态选项性能会更高")]
        public BBParameter<bool> Dynamic = false;
        
        [Name("AI主体")]
        public BBParameter<BattleUnit> Owner;
        [Name("数据源")]
        public BBParameter<List<BattleUnit>> SrcUnits;        
        [Name("数量限制:小于等于0表示不限制")]
        public BBParameter<int> Limit;
        [Name("排序信息")]
        public BBParameter<List<SortInfo>> SortInfos;
        [Name("结果设置到单位列表")]
        public BBParameter<List<BattleUnit>> SetToTargets;
        [Name("结果设置到战斗单位")]
        public BBParameter<BattleUnit> SetToTarget;
        /*
        private IUnitFilter _Sorter;
        
        protected override string info
        {
            get
            {
                string _info = "";
                var sortInfos = SortInfos.value;
                if (sortInfos == null || sortInfos.Count == 0)
                {
                    _info = "排序器(未选择排序条件)";
                }
                else
                {
                    for (int i = 0; i < sortInfos.Count; i++)
                    {
                        var sortInfo = sortInfos[i];
                        var type = SortType.GetByType(sortInfo.Type);
                        _info += type.Desc;
                    
                        if (sortInfo.Info != null)
                        {
                            var argString = sortInfo.Info.ToString();
                            if (!string.IsNullOrEmpty(argString))
                            {
                                _info += "[" + argString + "]";
                            }    
                        }

                        if (i < sortInfos.Count - 1)
                        {
                            _info += ", ";
                        }
                    }

                    if (!string.IsNullOrEmpty(_info))
                    {
                        _info = "按" + _info + "排序";
                    }
                }

                if (Limit.value <= 0)
                {
                    _info += "[无限制]";    
                }
                else
                {
                    _info += "[限制:" + Limit.value + "]"; 
                }

                return _info;
            }
        }

        protected override void OnExecute()
        {
            #if UNITY_EDITOR
            if (true)
            #else
            if (_Comparer == null || Dynamic.value)
            #endif
            {
                var sortInfos = SortInfos.value;
                List<IUnitComparer> list = new List<IUnitComparer>(sortInfos.Count);
                for (int i = 0; i < sortInfos.Count; i++)
                {
                    var sortInfo = sortInfos[i];
                    list.Add(sortInfo.Info.Create(sortInfo.Desc));           
                }
                _Sorter = new UnitSorter(new PriorityUnitComparer(list, false), Limit.value);
            }
            
            _Sorter.Sorter(Owner.value, SrcUnits.value);

            if (SetToTargets != null)
            {
                SetToTargets.value = SrcUnits.value;    
            }
            if (SetToTarget != null)
            {
                SetToTarget.value = SrcUnits.value.Count > 0 ? SrcUnits.value[0] : null;    
            }
            EndAction(true);
        }
        */
    }
}