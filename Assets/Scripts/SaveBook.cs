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

    [SerializeField]
    AudioClip dingDong;
    AudioSource playSound;

    [SerializeField]
    GameObject msgPop;
    [SerializeField]
    Text alretMsg;

    private void Start()
    {
        playSound = GetComponent<AudioSource>();

        filePath = Application.persistentDataPath + @"\saveBook";
        files = @"\numberBookList.json";
        imgFiles = $@"\";
        imgExtension =".png";

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        //DelegateSample.Instance.SaveOperate += SaveFile;
        //DelegateSample.Instance.SaveOperate += SaveImage;

    }

    public void SaveFile()
    {

        playSound.PlayOneShot(dingDong);

        // 이름 나이 휴대폰번호 이미지경로 - name, age, phoneNum, imgUrl
        NumberBook nb = new NumberBook(ifName.text, int.Parse(ifAge.text), ifPhoneNum.text, filePath + imgFiles + ifName.text + imgExtension, width: imageSource.sprite.texture.width, height: imageSource.sprite.texture.height);

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
