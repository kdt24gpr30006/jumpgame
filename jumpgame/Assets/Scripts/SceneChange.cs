using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] string nextSceneName  = "Game";

    void Update()
    {
        //  ���N���b�N���ꂽ��V�[���̐؂�ւ�
        if(Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
