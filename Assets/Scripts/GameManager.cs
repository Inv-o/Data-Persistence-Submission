using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] Button startButton;
    public string nameString;
    public int highScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        nameInput.onValueChanged.AddListener(delegate { UpdateName(); });
        LoadScore();
    }

    IEnumerator NameChanger()
    {
        yield return new WaitForSeconds(0.03f);
        nameString = nameText.text;
    }

    public void UpdateName()
    {
        StartCoroutine(NameChanger());
    }

    class SaveData
    {
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
        }
    }
}
