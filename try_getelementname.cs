using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class try_getelementname : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private GameObject lastCreatedObject;



    private void OnEnable()
    {
        SpeechRecognitionTest.SpeechRecognitionCompleted += OnSpeechRecognitionCompleted;
    }

    private void OnDisable()
    {
        SpeechRecognitionTest.SpeechRecognitionCompleted -= OnSpeechRecognitionCompleted;
    }

    private void OnSpeechRecognitionCompleted(string recognizedText)
    {
        // 檢查是否有最後創建的物體或語音識別的文本
        if (lastCreatedObject != null)
        {
            string objectNameWithoutClone = lastCreatedObject.name.Replace("(Clone)", "").Trim();
            text.text = objectNameWithoutClone;
            // 比對語音識別文本與物體名稱(去除clone後綴)
            if (recognizedText.ToLower() == objectNameWithoutClone.ToLower())
            {
                Destroy(lastCreatedObject); // 銷毀物件
            }
        }
    }

    //設置最後創建的物體
    public void SetLastCreatedObject(GameObject obj)
    {
        lastCreatedObject = obj;
    }
}
