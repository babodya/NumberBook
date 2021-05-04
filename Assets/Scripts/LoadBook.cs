using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Newtonsoft.Json;

public class LoadBook : MonoBehaviour
{
    int width, height;

    string filePath;
    string imagePath;
    string imgExtension;
    public UnityEngine.UI.Image loadImage;

    public Text nameText;
    public Text ageText;
    public Text phoneText;

    [SerializeField]
    AudioClip bbie;
    AudioSource playSound;

    void Start()
    {
        playSound = GetComponent<AudioSource>();

        filePath = Application.persistentDataPath + @"\saveBook\numberBookList.json";
        //DelegateSample.Instance.LoadOperate += LoadData;

        imagePath = Application.persistentDataPath + @"\saveBook\";
        imgExtension = ".png";
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            playSound.PlayOneShot(bbie);

            // Text Load
            var stringdata = File.ReadAllText(filePath);
            // 역직렬화로 Object 형태로 변경
            var data = JsonConvert.DeserializeObject<NumberBook>(stringdata);
            nameText.text = data.name;
            ageText.text = data.age.ToString();
            phoneText.text = data.phoneNum;
            width = data.width;
            height = data.height;
            //loadImage.sprite = data.sprite;

            // Image Load
            var imageData = File.ReadAllBytes(imagePath + data.name + imgExtension);
            Texture2D texture = new Texture2D(width, height);
            texture.LoadImage(imageData);
            Sprite sp = Sprite.Create(texture, new Rect(new Vector2(0, 0), new Vector2(width, height)), new Vector2(0.5f, 0), 1);
            loadImage.sprite = sp;

        }
    }
}
