using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stats : MonoBehaviour, IDataPersistence
{
    public float speed;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.health = data.health;
    }
    public void SaveData(ref GameData data)
    {
        data.health = this.health;
    }


}
