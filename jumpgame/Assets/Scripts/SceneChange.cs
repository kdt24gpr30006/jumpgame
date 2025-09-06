using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] string nextSceneName  = "Game";

    void Update()
    {
        //  スペースされたらシーンの切り替え
        if(Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
