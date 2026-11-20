namespace _Project.Develop.Runtime.Gameplay.Features.HealthFeature
{
    public interface IDamageable
    {
        bool CanTakeDamage(int damage);
        void TakeDamage(int damage);
    }
}
