using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExcelTab;

public class TableManager
{
    static TableManager instance;
    public static TableManager Instance
    {
        get
        {
            if (instance == null)
                instance = new TableManager();
            return instance;
        }
    }

    public CharacterParameterInfoTable parameterInfoTable = new CharacterParameterInfoTable();

    public CharacterPresetInfoTable presetInfoTable = new CharacterPresetInfoTable();

    public CharacterResourceInfoTable resourceInfoTable = new CharacterResourceInfoTable();

    public CharacterSettingInfoTable settingInfoTable = new CharacterSettingInfoTable();
}
