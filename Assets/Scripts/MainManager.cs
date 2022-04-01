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

    [SerializeField]
    private TextMeshProUGUI BestTimeText;

    public static MainManager Instance;
    public string Name { get; private set; }

    public bool isGameOver;

    public string timeFormat { get; } = "{0,2:00}:{1,2:00}:{2,2:00}";

    public string BestTimeName;

    private int i_BestSeconds;
    public int BestSeconds
    {
        get { return i_BestSeconds; }
        set
        {
            if (value < i_BestSeconds)
            {

                Debug.LogError("You can't set lower number!");
            }
            else
            {
                i_BestSeconds = value;
            }
        }
    }

    private int i_BestMinutes;
    public int BestMinutes
    {
        get { return i_BestMinutes; }
        set
        {
            if (value < i_BestMinutes)
            {

                Debug.LogError("You can't set lower number!");
            }
            else
            {
                i_BestMinutes = value;
            }
        }
    }

    private int i_BestMiliSeconds;
    public int BestMiliSeconds
    {
        get { return i_BestMiliSeconds; }
        set
        {
            if (value < i_BestMiliSeconds)
            {

                Debug.LogError("You can't set lower number!");
            }
            else
            {
                i_BestMiliSeconds = value;
            }
        }
    }

    [SerializeField]
    private TMP_InputField inputField;

    public int health;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        health = 10;

        LoadHighScore();
        BestTimeText.text = $"{BestTimeName} | {string.Format(timeFormat, BestMinutes, BestSeconds, BestMiliSeconds)}";

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
        public int BestMinutes;
        public int BestSeconds;
        public int BestMiliSeconds;
        public string BestTimeName;
    }


    public void SaveHighScore(string name, int minutes, int seconds, int miliSeconds)
    {
        SaveData data = new SaveData();
        data.BestMinutes = minutes;
        data.BestSeconds = seconds;
        data.BestMiliSeconds = miliSeconds;
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

            BestMinutes = data.BestMinutes;
            BestSeconds = data.BestSeconds;
            BestMiliSeconds = data.BestMiliSeconds;
            BestTimeName = data.BestTimeName;
        }
    }

}
