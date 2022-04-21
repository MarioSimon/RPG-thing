using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float attackSpeed = 1f;
        [SerializeField] float weaponDamage = 5f;

        Transform target;
        float timeSinceLastAttack;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!isInRange())
            {
                GetComponent<Mover>().MoveTo(target.position); 
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack < attackSpeed) return;
            // This will trigger the Hit() event
            GetComponent<Animator>().SetTrigger("attack");
            timeSinceLastAttack = 0;          
        }

        // Animation event
        private void Hit()
        {
            target.GetComponent<Health>().TakeDamage(weaponDamage);
        }

        private bool isInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        
    }
}
