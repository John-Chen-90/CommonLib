
using System.Collections.Generic;

namespace UnitSystem
{
    /// <summary>
    /// 单位环境
    /// </summary>
    public class UnitEnv
    {
        /*
         * 基本每个游戏都会有场景,所以本类是当前场景下所有对象的管理器
         * 也可以用来做对象之间的交互,只记录所有对象
         *
         */

        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="id"></param>
        public UnitEnv(uint id)
        {
            _id = id;
        }

        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="name"></param>
        public UnitEnv(string name)
        {
            _name = name;
        }

        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public UnitEnv(uint id, string name)
        {
            _id = id;
            _name = name;
        }

        /// <summary>
        /// 进入场景
        /// </summary>
        /// <param name="units"> 场景中的所有对象 </param>
        public void EnterEnv(List<Unit> units)
        {
            if(units == null || units.Count == 0) return;

            var cnt = units.Count;
            for (int i = 0; i < cnt; i++)
            {
                var unit = units[i];
                AddUnit(unit);
            }
        }

        /// <summary>
        /// 离开场景
        /// </summary>
        public void ExitEnv()
        {
            _id = 0;
            _name = "";
            foreach (var us in _units)
            {
                foreach (var u in us.Value)
                {
                    u.Value.Release();
                }
            }

        }

        /// <summary>
        /// 添加对象到环境中,该对象已经被加载完成
        /// </summary>
        /// <param name="unit"> 环境中的对象 </param>
        public void AddUnit(Unit unit)
        {
            if (!_units.ContainsKey(unit.Category))
            {
                _units.Add(unit.Category, new Dictionary<uint, Unit>());
            }

            if (!_units[unit.Category].ContainsKey(unit.UID))
            {
                _units[unit.Category].Add(unit.UID, unit);
            }
        }

        protected uint _id;
        protected string _name;

        protected Dictionary<UnitCategory, Dictionary<uint, Unit>> _units;

    }
}
