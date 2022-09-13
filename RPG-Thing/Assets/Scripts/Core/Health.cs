using System;
using UnityEngine;
using RPG.Saving;

namespace RPG.Core
{
    class Health : MonoBehaviour, ISaveable
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
        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
            healthPoints = (float)state;

            if (healthPoints == 0)
                Die();
        }
    }
}
