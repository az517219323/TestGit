using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI.Math
{
    [Name("随机坐标")]
    [Category("_昆仑/行为任务/数学")]
    [Description("获取指定范围内的一个随机坐标")]
    public class RandomVector3Action : ActionTask
    {
        [Name("最小坐标")]
        public BBParameter<Vector3> Min;
        [Name("最大坐标")]
        public BBParameter<Vector3> Max;
        [Name("保存到")]
        public BBParameter<Vector3> SaveTo;
        /*
        protected override void OnExecute()
        {
            var vec3 = new Vector3(
                _RandomRange(Min.value.x, Max.value.x),
                _RandomRange(Min.value.y, Max.value.y),
                _RandomRange(Min.value.z, Max.value.z)
            );
            SaveTo.value = vec3;
            EndAction(true);
        }

        private float _RandomRange(float v1, float v2)
        {
            return v1 < v2 ? Random.Range(v1, v2) : Random.Range(v2, v1);
        }
        */
    }
}