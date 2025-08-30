using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] string nextSceneName  = "Game";

    void Update()
    {
        //  左クリックされたらシーンの切り替え
        if(Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
