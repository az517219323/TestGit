using System;
using System.Collections.Generic;
using System.IO;

namespace ExcelTab
{
	public class CharacterResourceInfo
	{
		public Int64 Id;     // ID
		public Int64 Type;   // 类型
		public string Name;  // 命名
		public bool IsOpen;  // 开关
	}
	public class CharacterResourceInfoTable
	{
		public List<CharacterResourceInfo> Data;     //所有数据
		public Dictionary<UInt64, CharacterResourceInfo> IdMap; //唯一主键
		public CharacterResourceInfoTable()
		{
			this.Data = new List<CharacterResourceInfo>();
			this.IdMap = new Dictionary<UInt64, CharacterResourceInfo>();

			Loader();
		}


		public List<CharacterResourceInfo> GetDataAll()
		{
			return this.Data;
		}
		public CharacterResourceInfo GetDataById(UInt64 id)
		{
			return this.IdMap[id];
		}
		public void Loader()
		{
			var content = File.ReadAllLines(TableUtility.tablePath + "/character_resource_info.csv");
			foreach (var line in content)
			{
				var strList = TableUtility.SplitString(line);
				CharacterResourceInfo info = new CharacterResourceInfo();

				Int64 value;
				if (Int64.TryParse(strList[0], out value))
				{
					info.Id = value;
				}
				if (Int64.TryParse(strList[1], out value))
				{
					info.Type = value;
				}
				info.Name = strList[2];
				info.IsOpen = strList[3] == "1";

				Data.Add(info);
				IdMap.Add((UInt64)info.Id, info);
			}
		}
	}
}
