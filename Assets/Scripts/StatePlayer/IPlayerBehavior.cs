using UnityEngine;
public interface IPlayerBehavior {
    void Enter(GameObject player);
    void FixedUpdate();
    void Update();
    void Exit();
}