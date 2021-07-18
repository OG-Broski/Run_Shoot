using UnityEngine;
using UnityEngine.SceneManagement;
public class InputControllerPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            _player.SetBehaviorMove();
        }
        if(Input.GetKeyDown(KeyCode.I)){
            SceneManager.LoadScene(0);
        }
    }
}
