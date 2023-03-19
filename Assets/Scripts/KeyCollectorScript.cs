using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectorScript : MonoBehaviour {

    // กำหนดจำนวนกุญแจที่ต้องการเก็บ
    public int numberOfKeys;

    // กำหนดชื่อของกุญแจที่ต้องการเก็บ
    public string keyName;

    void OnTriggerEnter(Collider other) {
        // เช็คว่า GameObject ที่เข้ามาชนเป็น Key หรือไม่
        if (other.CompareTag("Key")) {

            // เพิ่มจำนวนกุญแจที่เก็บไว้ใน PlayerPrefs
            PlayerPrefs.SetInt(keyName, PlayerPrefs.GetInt(keyName) + 1);

            // ทำลาย GameObject ที่ชนกับ Key
            Destroy(other.gameObject);
        }
    }
}
