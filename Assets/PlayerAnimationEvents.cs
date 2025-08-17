using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    private void DisabledMovmentAndJump() => player.EnableMovmentAndJump(false);
    
    private void EnabledMovmentAndJump() => player.EnableMovmentAndJump(true);
}
