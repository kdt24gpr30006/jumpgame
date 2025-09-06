using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] string nextSceneName  = "Game";

    void Update()
    {
        //  �X�y�[�X���ꂽ��V�[���̐؂�ւ�
        if(Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
