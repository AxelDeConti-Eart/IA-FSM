public interface IDamageable
{
    int MaxHealth { get; }
    int CurrentHealth { get; }

    void Damage(int value);
}
