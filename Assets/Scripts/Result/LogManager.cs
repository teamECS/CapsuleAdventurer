using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using System.IO;

public class LogManager : MonoBehaviour
{
    private string filePath;
    private IList logList;

	// Use this for initialization
	void Start () {

        filePath = Application.dataPath + "/data/log.json";
        if (!File.Exists(filePath)){
            Debug.Log(filePath);
            Debug.Log("logファイルがありません！");
            return;
        }

        string jsonStr = File.ReadAllText(filePath);
        logList = Json.Deserialize(jsonStr) as IList;
	}

    void AddLog(string name, int score)
    {
        var dic = new Dictionary<string, object>();
        dic.Add("name", name);
        dic.Add("score", score);

        logList.Add(dic);
        string jsonStr = Json.Serialize(logList);
        File.WriteAllText(filePath, jsonStr);
    }

    void PrintLog() {
        foreach (IDictionary player in logList)
        {
            Debug.Log(player["name"]);
            Debug.Log(player["score"]);
        }
    }
}
