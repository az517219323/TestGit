using System;
using System.Collections.Generic;
using System.IO;

namespace ExcelTab
{
	public class CharacterPresetInfo
	{
		public Int64 Id;     // ID
		public Int64 CharacterPreset;    // 参数模型id
		public Int64 Gender;     // 展示性别
		public bool IsOpen;  // 开关
	}
	public class CharacterPresetInfoTable
	{
		public List<CharacterPresetInfo> Data;   //所有数据
		public Dictionary<UInt64, CharacterPresetInfo> IdMap; //唯一主键
		public CharacterPresetInfoTable()
		{
			this.Data = new List<CharacterPresetInfo>();
			this.IdMap = new Dictionary<UInt64, CharacterPresetInfo>();

			Loader();
		}


		public List<CharacterPresetInfo> GetDataAll()
		{
			return this.Data;
		}
		public CharacterPresetInfo GetDataById(UInt64 id)
		{
			return this.IdMap[id];
		}
		public void Loader()
		{
			var content = File.ReadAllLines(TableUtility.tablePath + "/character_preset_info.csv");
			foreach (var line in content)
			{
				Int64 value;
				CharacterPresetInfo info = new CharacterPresetInfo();
				var strList = TableUtility.SplitString(line);
				if (Int64.TryParse(strList[0], out value))
				{
					info.Id = value;
				}
				if (Int64.TryParse(strList[1], out value))
				{
					info.CharacterPreset = value;
				}
				if (Int64.TryParse(strList[2], out value))
				{
					info.Gender = value;
				}
				info.IsOpen = strList[3] == "1";

				Data.Add(info);
				IdMap.Add((UInt64)info.Id, info);
			}
		}
	}
}
