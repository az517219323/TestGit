using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableUtility
{
	public static string tablePath = Application.dataPath + "/Table";
	public static List<T> FormatStringToList<T>(string content, char splitChar)
    {
		List<T> formatToIntList = new List<T>();
		if (content == "" || string.IsNullOrEmpty(content))
		{
			return formatToIntList;
		}
		string[] contentList = content.Split(splitChar);
		for (int i = 0; i < contentList.Length; i++)
		{
			formatToIntList.Add((T)Convert.ChangeType(contentList[i], typeof(T)));
		}
		return formatToIntList;
	}

	public static List<string> SplitString(string str)
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
