using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ExcelTab
{
	public class CharacterSettingInfo
	{
		public Int64 CharacterId;    // ID
		public Int64 FuncType;   // 捏脸类型
		public List<Int64> Order;    // 页签排序
		public Int64 ChangeOrder;    // 修改排序
		public Int64 ChangeType;     // 修改类型
		public Int64 DisplayType;    // 展示类型
		public List<Int64> Range;    // 参数范围
	}
	public class CharacterSettingInfoTable
	{
		public List<CharacterSettingInfo> Data;      //所有数据
		public Dictionary<UInt64, CharacterSettingInfo> IdMap; //唯一主键
		public CharacterSettingInfoTable()
		{
			this.Data = new List<CharacterSettingInfo>();
			this.IdMap = new Dictionary<UInt64, CharacterSettingInfo>();

			Loader();
		}


		public List<CharacterSettingInfo> GetDataAll()
		{
			return this.Data;
		}
		public CharacterSettingInfo GetDataById(UInt64 id)
		{
			return this.IdMap[id];
		}
		public void Loader()
		{
			var content = File.ReadAllLines(TableUtility.tablePath + "/character_setting_info.csv");
			foreach (var line in content)
			{
				var strList = TableUtility.SplitString(line);
				long value;
				CharacterSettingInfo info = new CharacterSettingInfo();
				if (Int64.TryParse(strList[0], out value))
				{
					info.CharacterId = value;
				}
				if (Int64.TryParse(strList[1], out value))
				{
					info.FuncType = value;
				}
				info.Order = TableUtility.FormatStringToList<long>(strList[2], ',');
				if (Int64.TryParse(strList[3], out value))
				{
					info.ChangeOrder = value;
				}
				if (Int64.TryParse(strList[4], out value))
				{
					info.ChangeType = value;
				}
				if (Int64.TryParse(strList[5], out value))
				{
					info.DisplayType = value;
				}
				info.Range = TableUtility.FormatStringToList<long>(strList[6], ',');
				Data.Add(info);
				IdMap.Add((UInt64)info.CharacterId, info);
			}
		}

		public List<CharacterSettingInfo> GetDataListById(Int64 id)
        {
			List<CharacterSettingInfo> list = new List<CharacterSettingInfo>();
			list = Data.FindAll(x => x.Order[0] == id);
			return list;
		}
	}
}
