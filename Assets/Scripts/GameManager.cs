using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int coins;

    [SerializeField] private Employee employee = new Employee();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("coins"));
        coins = PlayerPrefs.GetInt("coins", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteKey("coins");
        }
    }

    public void SaveEmployee()
    {
        string saveString = JsonUtility.ToJson(employee);
        Debug.Log(saveString);
        PlayerPrefs.SetString("emp", saveString);
    }

    public void LoadEmployee()
    {
        string loadedString = PlayerPrefs.GetString("emp", "{}");
        Debug.Log(loadedString);
        employee = JsonUtility.FromJson<Employee>(loadedString);
    }

    public string GetEmployeeString()
    {
        return $"Name: {employee.name}, Title: {employee.title}, desc: {employee.description}";
    }
}