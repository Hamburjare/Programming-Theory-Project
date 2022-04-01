using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainManager : MonoBehaviour
{

    public TextMeshProUGUI BestTimeText;

    public static MainManager Instance;
    public string Name { get; private set; }

    public string BestTimeName;

    private int i_BestTime;
    public int BestTime
    {
        get { return i_BestTime; }
        set
        {
            if (value < i_BestTime)
            {

                Debug.LogError("You can't set lower number!");
            }
            else
            {
                i_BestTime = value;
            }
        }
    }

    public TMP_InputField inputField;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
        if (BestTimeName == null)
        {
            BestTimeText.text = $"{BestTimeName} | {i_BestTime}";
        }

    }

    public void StartNew()
    {
        Name = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
                Application.Quit();
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public string BestTimeName;
        public int i_BestTime;
    }


    public void SaveHighScore(string name, int score)
    {
        SaveData data = new SaveData();
        data.i_BestTime = score;
        data.BestTimeName = name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestTime = data.i_BestTime;
            BestTimeName = data.BestTimeName;
        }
    }

}
