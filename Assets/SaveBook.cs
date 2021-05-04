using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;


public class SaveBook : MonoBehaviour
{
    string filePath;
    string files;
    string imgFiles;
    string imgExtension;

    public InputField ifName;
    public InputField ifAge;
    public InputField ifPhoneNum;

    public Image imageSource;

    private void Start()
    {
        filePath = Application.persistentDataPath + @"\saveBook";
        files = @"\numberBookList.json";
        imgFiles = $@"\";
        imgExtension =".png";
    }

    public void SaveFile()
    {

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        // 이름 나이 휴대폰번호 이미지경로 - name, age, phoneNum, imgUrl
        NumberBook nb = new NumberBook(ifName.text, int.Parse(ifAge.text), ifPhoneNum.text, filePath + imgFiles + ifName.text + imgExtension);

        var t = JsonUtility.ToJson(nb);
        var t2 = JsonConvert.SerializeObject(nb);

        File.WriteAllText(filePath + files, t);
        File.WriteAllText(filePath + files, t2);
    }

    public void SaveImage()
    {
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        SaveImage si = new SaveImage();
        si.images = imageSource.sprite.texture;
        var bytes = si.images.EncodeToPNG();
        File.WriteAllBytes(filePath + imgFiles + ifName.text + imgExtension, bytes);
    }

}
