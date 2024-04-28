using System.Collections.Generic;
using KLGame.OP.Battle.Validator;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-11-03 11:33
    //******************************************
    [Category("_昆仑/行为任务/目标选择、过滤、排序")]
    [Name("目标选择与过滤")]
    public class TargetSelectorAction : ActionTask
    {
        //[Name("参数条件会不会在运行时修改，如果不会，不开启动态选项性能会更高")]
        //public BBParameter<bool> Dynamic = false;
        
        [Name("AI主体")]
        public BBParameter<BattleUnit> Owner;
        [Name("范围（米）")]
        public BBParameter<float> Range;
        [Name("阵营关系")]
        public BBParameter<RangeUnitSelector.CampType[]> CampTypes = new []{ RangeUnitSelector.CampType.Attackable };
        [Name("单位类型")]
        public BBParameter<TargetTypeUnitValidator.TargetType[]> TargetTypes = new []{ TargetTypeUnitValidator.TargetType.Any };
        //[Name("数量限制:小于等于0表示不限制")]
        //public BBParameter<int> Limit;
        [Name("结果设置到单位列表")]
        public BBParameter<List<BattleUnit>> SetToTargets;
        [Name("结果设置到战斗单位")]
        public BBParameter<BattleUnit> SetToTarget;
        /*
        private List<BattleUnit> _Temp;
        private IUnitSelector _UnitSelector;

        protected override string info
        {
            get
            {
                string _info = "查找范围" + Range + "米";

                if (CampTypes != null)
                {
                    var campTypesValue = CampTypes.value;
                    if (campTypesValue.Length > 0)
                    {
                        _info += "且阵营关系为（";
                        for (int i = 0; i < campTypesValue.Length; i++)
                        {
                            var campType = campTypesValue[i];
                            _info += campType;
                            if (i < campTypesValue.Length - 1)
                            {
                                _info += ", ";
                            }
                        }
                        _info += "）";
                    }
                }

                if (TargetTypes != null)
                {
                    var targetTypesValue = TargetTypes.value;
                    if (targetTypesValue.Length > 0)
                    {
                        _info += "且单位类型为（";
                        for (int i = 0; i < targetTypesValue.Length; i++)
                        {
                            var targetType = targetTypesValue[i];
                            _info += targetType;
                            if (i < targetTypesValue.Length - 1)
                            {
                                _info += ", ";
                            }
                        }
                        _info += "）";
                    }
                }

                _info += "的单位";
                if (Limit != null && Limit.value > 0)
                {
                    _info += "[限制:" + Limit.value + "]";
                }
                else
                {
                    _info += "[无限制]";
                }

                return _info;
            }
        }

        protected override void OnExecute()
        {
            if (_Temp == null)
            {
                _Temp = new List<BattleUnit>();
            }
            else
            {
                _Temp.Clear();
            }
            
            #if UNITY_EDITOR
            if (true)
            #else
            if (_UnitSelector == null || Dynamic.value)
            #endif
            {
                AndUnitValidator validator = new AndUnitValidator();
                foreach (var targetTypes in TargetTypes.value)
                {
                    validator.Add(TargetTypeUnitValidator.Get(targetTypes));
                }
            
                _UnitSelector = new RangeUnitSelector(Range.value, CampTypes.value, validator);
            }

            _UnitSelector.Select(Owner.value, _Temp);
            
            if (SetToTargets != null)
            {
                SetToTargets.value = _Temp;    
            }

            if (SetToTarget != null)
            {
                SetToTarget.value = _Temp.Count > 0 ? _Temp[0] : null;    
            }
            EndAction(true);
        }
        */
    }
}