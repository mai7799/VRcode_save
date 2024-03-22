using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class First : MonoBehaviour
{
    public GameObject[] fruits;
    private GameObject createdFruit; // 用來追蹤已經創建的物件

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
                // 將創建的物件名稱給try_elementname腳本
                try_getelementname tryGetElementNameScript = GetComponent<try_getelementname>();
                if (tryGetElementNameScript != null)
                {
                    tryGetElementNameScript.SetLastCreatedObject(createdFruit);
                }

                Rigidbody rig;
                rig = createdFruit.GetComponent<Rigidbody>();
                rig.AddForce(Random.Range(-100, 100), Random.Range(750, 1000), 0); ///第二個range是拋物力量
                rig.AddTorque(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));

                yield return new WaitForSeconds(10f); // 等待3秒後摧毀水果物件
                Destroy(createdFruit);
            }

            yield return null;
        }
    }
}
