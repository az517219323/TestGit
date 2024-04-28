using System;
using System.Collections.Generic;
using System.IO;

namespace ExcelTab
{
	public class CharacterParameterInfo
	{
		public Int64 ParameterId;    // 参数模型id
		public Int64 FashionId;  // 时装id
		public string BackgroundId;  // 背景id
		public Int64 CharacterId;    // 捏脸id
		public double Value;     // 属性值
	}
	public class CharacterParameterInfoTable
	{
		public List<CharacterParameterInfo> Data;    //所有数据
		public Dictionary<UInt64, CharacterParameterInfo> IdMap; //唯一主键
		public CharacterParameterInfoTable()
		{
			this.Data = new List<CharacterParameterInfo>();
			this.IdMap = new Dictionary<UInt64, CharacterParameterInfo>();

			Loader();
		}


		public List<CharacterParameterInfo> GetDataAll()
		{
			return this.Data;
		}
		public CharacterParameterInfo GetDataById(UInt64 id)
		{
			return this.IdMap[id];
		}
		public void Loader()
		{
			var content = File.ReadAllLines(TableUtility.tablePath + "/character_parameter_info.csv");
			foreach (var line in content)
			{
				long idValue;
				List<string> strList = TableUtility.SplitString(line);
				CharacterParameterInfo info = new CharacterParameterInfo();
				if(Int64.TryParse(strList[0], out idValue))
                {
					info.ParameterId = idValue;
				}
				if(Int64.TryParse(strList[1], out idValue))
                {
					info.FashionId = idValue;
				}
				info.BackgroundId = strList[2];
				if (Int64.TryParse(strList[3], out idValue))
				{
					info.CharacterId = idValue;
				}
				double value;
				if(double.TryParse(strList[4], out value))
                {
					info.Value = value;
				}

				if (info.ParameterId != 0)
				{
					Data.Add(info);
					IdMap.Add((UInt64)info.ParameterId, info);
				}
			}
		}
	}
}
