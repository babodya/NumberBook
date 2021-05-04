using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class NumberBook
{
    public string name;
    public int age;
    public string phoneNum;
    public string imgUrl;

    //public Dictionary<string, int> personaladdress;
    //public Sprite sprite;

    public NumberBook(string name, int age, string phoneNum, string imgUrl)
    {
        this.name = name;
        this.age = age;
        this.phoneNum = phoneNum;
        this.imgUrl = imgUrl;
    }
}
