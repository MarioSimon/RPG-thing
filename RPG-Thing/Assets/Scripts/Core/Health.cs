using System;
using UnityEngine;

namespace RPG.Core
{
    class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;
        bool isDead = false;        

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print(gameObject.name + ": " + healthPoints);
            if (healthPoints == 0 && !isDead)
                Die();
        }

        private void Die()
        {
            if (IsDead()) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
}
