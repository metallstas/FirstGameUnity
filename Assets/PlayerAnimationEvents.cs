using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Entity player;

    private void Awake()
    {
        player = GetComponentInParent<Entity>();
    }

    public void DamageEnemies() => player.DamageEnemies();
    private void DisabledMovmentAndJump() => player.EnableMovmentAndJump(false);
    
    private void EnabledMovmentAndJump() => player.EnableMovmentAndJump(true);
}
