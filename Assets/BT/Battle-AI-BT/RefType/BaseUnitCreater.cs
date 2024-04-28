using System;
using UnityEngine;


namespace KLGame.OP.Battle.UnitCreater {

    public interface IBattleUnitCreater { }
    public class BaseUnitCreater 
    {
        [Serializable]
        public class Range
        {
            public Vector3 Position;
            public float Radius;

            public Vector3 Random()
            {
                return Position + Vector3.Scale(UnityEngine.Random.insideUnitSphere * Radius, new Vector3(1, 0, 1));
            }
        }
    }
}
