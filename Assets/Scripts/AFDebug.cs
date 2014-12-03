using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class AFDebug
{
    protected static string m_log = "";
    protected static uint m_bufferIndex = 0;

    protected static AFDebugSettings m_settings = new AFDebugSettings() 
    {
        LogFilePath = "Assets/Logs",
        Configs = AFDebugSettings.OUTPUT_FILE | AFDebugSettings.OUTPUT_UNITY | AFDebugSettings.OUTPUT_SCREEN | AFDebugSettings.LOG_LOCAL_FILE,
        TextColor = 0xFF0000,
        MaxCharacters = 1000,
        AFDebugCanvas = GameObject.Find("AFDebugCanvas") == null ? GameObject.Find("AFDebugCanvas") : Resources.Load<GameObject>("Common/AFDebugCanvas")
    };
    protected static bool m_initialize = false;

    public static void SetSettings(AFDebugSettings settings)
    {
        m_settings = settings;
    }

    public static void Log(string str)
    {
        m_log += "|== " + str + m_bufferIndex + "KJFKLSDJLFJLSDK:FJKL:SJDKL:FJKL:SDJFL:KJSDKL:FJKL:SDJFKL:SDJKL:FJSKL:DFJKL:SDJFKL:JSDL:KFJKL:SDFJ:KLSDJFKL:JSDKL:FJSDKL:FJKL:SDJFLKJKL:FJLDKSJFKLS ==|";

        if ((m_settings.Configs & AFDebugSettings.OUTPUT_UNITY) == AFDebugSettings.OUTPUT_UNITY)
        {
            UnityEngine.Debug.Log(str);
        }

        if ((m_settings.Configs & AFDebugSettings.OUTPUT_SCREEN) == AFDebugSettings.OUTPUT_SCREEN)
        {
            GameObject go = GameObject.Find("AFDebugText");

            if (m_log.Length > m_settings.MaxCharacters)
                go.GetComponent<Text>().text = m_log.Substring(m_log.Length - m_settings.MaxCharacters);
            else
                go.GetComponent<Text>().text = m_log;
        }

        if ((m_settings.Configs & AFDebugSettings.LOG_LOCAL_FILE) == AFDebugSettings.LOG_LOCAL_FILE)
        {
            //TODO: LOG IN FILE INFORMATIONS
        }

        m_bufferIndex++;
    }
}
