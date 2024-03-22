using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class First : MonoBehaviour
{
    public GameObject[] fruits;
    private GameObject createdFruit; // �ΨӰl�ܤw�g�Ыت�����

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowFruit());
    }

    IEnumerator ThrowFruit()
    {
        while (true)
        {
            if (createdFruit == null)
            {
                createdFruit = Instantiate(fruits[Random.Range(0, fruits.Length)]) as GameObject;
                createdFruit.transform.position = new Vector3(0, 0, Random.Range(-5, 2));
                createdFruit.SetActive(true);
                // �N�Ыت�����W�ٵ�try_elementname�}��
                try_getelementname tryGetElementNameScript = GetComponent<try_getelementname>();
                if (tryGetElementNameScript != null)
                {
                    tryGetElementNameScript.SetLastCreatedObject(createdFruit);
                }

                Rigidbody rig;
                rig = createdFruit.GetComponent<Rigidbody>();
                rig.AddForce(Random.Range(-100, 100), Random.Range(750, 1000), 0); ///�ĤG��range�O�ߪ��O�q
                rig.AddTorque(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));

                yield return new WaitForSeconds(10f); // ����3���R�����G����
                Destroy(createdFruit);
            }

            yield return null;
        }
    }
}
