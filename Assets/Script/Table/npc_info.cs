using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ExcelTab
{
	public class NpcInfo
	{
		public Int64 Id;     // ID
		public string Name;  // 名字
		public string SubName;   // 副名
		public string Icon;  // 头像
		public List<Int64> Options;  // 功能选项
		public List<Int64> IntradayFirstDialogue;    // 日内首次默认对白
		public List<Int64> IntradayDefaultDialogue;  // 日内非首次默认对白
		public Int64 ModelId;    // 模型ID
		public Int64 MapId;  // 所在地图ID
		public string MapCoordinate;     // 所在地图坐标
		public Int64 ListOrder;  // 列表排序
		public double SightFocusRange;   // 视线跟随玩家触发范围
		public bool CanBePushed;     // 能否被推挤
		public bool CanChat;     // 能否交谈
		public double Scale;     // 模型缩放
		public Int64 StandbyRule;    // 待机规则
	}
	public class NpcInfoTable
	{
		public List<NpcInfo> Data;   //所有数据
		public Dictionary<UInt64, NpcInfo> IdMap; //唯一主键
		public NpcInfoTable()
		{
			this.Data = new List<NpcInfo>();
			this.IdMap = new Dictionary<UInt64, NpcInfo>();
		}


		public List<NpcInfo> GetDataAll()
		{
			return this.Data;
		}
		public NpcInfo GetDataById(UInt64 id)
		{
			return this.IdMap[id];
		}
		public void Loader()
		{
			var content = File.ReadAllText(Application.dataPath + "/Resources_Bundles/Table/npc_info.csv"); //Resources.Load<TextAsset>("/Table/npc_info.csv");
			string[] lineText = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < lineText.Length; i++)
			{
				lineText[i].Replace("\r", "");
				List<string> lineContent = SplitString(lineText[i]);
				if (string.IsNullOrEmpty(lineContent[0]))
                {
					continue;
                }
				NpcInfo info = new NpcInfo();
				info.Id = Int64.Parse(lineContent[0]);
				info.Name = lineContent[1];
				info.SubName = lineContent[2];
				info.Icon = lineContent[3];
				info.Options = FormatStringToList<Int64>(lineContent[4], ',');
				info.IntradayFirstDialogue = FormatStringToList<Int64>(lineContent[5], ',');
				info.IntradayDefaultDialogue = FormatStringToList<Int64>(lineContent[6], ',');
				info.ModelId = Int64.Parse(lineContent[7]);
				info.MapId = Int64.Parse(lineContent[8]);
				info.MapCoordinate = lineContent[9];
				info.ListOrder = Int64.Parse(lineContent[10]);
				info.SightFocusRange = double.Parse(lineContent[11]);
				info.CanBePushed = lineContent[12].Trim() == "1";
				info.CanChat = lineContent[13].Trim() == "1";
				info.Scale = double.Parse(lineContent[14]);
				info.StandbyRule = Int64.Parse(lineContent[15]);

				Data.Add(info);
				IdMap.Add(((uint)info.Id), info);
			}
		}

		List<T> FormatStringToList<T>(string content, char splitChar)
		{
			string[] contentList = content.Split(splitChar);
			List<T> formatToIntList = new List<T>();
			for (int i = 0; i < contentList.Length; i++)
			{
				formatToIntList.Add((T)Convert.ChangeType(contentList[i], typeof(T)));
			}
			return formatToIntList;
		}

		List<string> SplitString(string str)
        {
			List<string> strList = new List<string>();
			var contentList = str.Split(",\"");
			for (int i = 0; i < contentList.Length; i++)
			{
				if (contentList[i].Contains("\","))
				{
					string[] strArray = contentList[i].Split("\",");
					strList.Add(strArray[0]);
					string[] leftStrArray = strArray[1].Split(",");
					for (int j = 0; j < leftStrArray.Length; j++)
					{
						strList.Add(leftStrArray[j]);
					}
				}
				else if (contentList[i].Contains("\""))
				{
					strList.Add(contentList[i].Replace("\"", ""));
				}
				else
				{
					string[] strArray = contentList[i].Split(",");
					for (int j = 0; j < strArray.Length; j++)
					{
						strList.Add(strArray[j]);
					}
				}
			}

			return strList;
        }
	}
}
