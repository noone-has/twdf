using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies
{
    public class Damageable : MonoBehaviour
    {
        [FormerlySerializedAs("Health")] [SerializeField]
        private float health;
        [FormerlySerializedAs("Armor")] [SerializeField]
        private float armor;

        public float GetHealth()
        {
            return health;
        }
        public float GetArmor()
        {
            return armor;
        }

        public void TakeDamage(float damage)
        {
            health -= damage / armor;
            if(health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
