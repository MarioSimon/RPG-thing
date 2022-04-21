using System;
using UnityEngine;

namespace RPG.Combat
{
    class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;
        bool isDead = false;        

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print(healthPoints);
            if (healthPoints == 0 && !isDead)
                Die();
        }

        private void Die()
        {
            GetComponent<Animator>().SetTrigger("die");
            isDead = true;
        }
    }
}
