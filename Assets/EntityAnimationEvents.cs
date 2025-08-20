using UnityEngine;

public class EntityAnimationEvents : MonoBehaviour
{
    private Entity entity;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }

    public void DamageTargets() => entity.DamageTargets();
    private void DisabledMovmentAndJump() => entity.EnableMovmentAndJump(false);
    
    private void EnabledMovmentAndJump() => entity.EnableMovmentAndJump(true);
}
