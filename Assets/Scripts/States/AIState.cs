using UnityEngine;

public abstract class AIState : StateMachineBehaviour
{
    protected Enemy _enemy = null;

    [SerializeField] private Color _color = Color.white;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_enemy == null)
            _enemy = animator.GetComponent<Enemy>();

        _enemy.SpriteRenderer.color = _color;
        OnEnter(stateInfo);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnUpdate(stateInfo);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnExit(stateInfo);
    }

    protected abstract void OnEnter(AnimatorStateInfo stateInfo);
    protected abstract void OnUpdate(AnimatorStateInfo stateInfo);
    protected abstract void OnExit(AnimatorStateInfo stateInfo);
}