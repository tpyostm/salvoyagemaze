using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // ใส่ชื่อ Scene ที่ต้องการเปลี่ยนไปตรงนี้
    public string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}