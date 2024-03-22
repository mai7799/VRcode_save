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
        // �ˬd�O�_���̫�Ыت�����λy���ѧO���奻
        if (lastCreatedObject != null)
        {
            string objectNameWithoutClone = lastCreatedObject.name.Replace("(Clone)", "").Trim();
            text.text = objectNameWithoutClone;
            // ���y���ѧO�奻�P����W��(�h��clone���)
            if (recognizedText.ToLower() == objectNameWithoutClone.ToLower())
            {
                Destroy(lastCreatedObject); // �P������
            }
        }
    }

    //�]�m�̫�Ыت�����
    public void SetLastCreatedObject(GameObject obj)
    {
        lastCreatedObject = obj;
    }
}
