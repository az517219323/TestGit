using System;
using System.Collections.Generic;

namespace ExcelTab
{
	public class MapInfo
	{
		public Int64 Id;     // ID
		public string Name;  // 名字
		public Int64 Type;   // 类型
	}
	public class MapInfoTable
	{
		public List<MapInfo> Data;   //所有数据
		public Dictionary<UInt64, MapInfo> IdMap; //唯一主键
		public MapInfoTable()
		{
			this.Data = new List<MapInfo>();
			this.IdMap = new Dictionary<UInt64, MapInfo>();
		}


		public List<MapInfo> GetDataAll()
		{
			return this.Data;
		}
		public MapInfo GetDataById(UInt64 id)
		{
			return this.IdMap[id];
		}
		public void Loader()
		{
			
		}
	}
}
