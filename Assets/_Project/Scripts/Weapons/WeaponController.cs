using UnityEngine;
using FirstRoguelike.Core;
using FirstRoguelike.Stats;
using FirstRoguelike.Player;

namespace FirstRoguelike.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [Header("Weapon Settings")]
        [SerializeField] private GameObject projectilePrefab;

        private IAttackStrategy _attackStrategy;
        private PlayerStatSheet _playerStatSheet;
        private float _attackTimer;

        private void Awake()
        {
            _playerStatSheet = GetComponent<PlayerStatSheet>();
            _attackStrategy = new MageAttackStrategy(projectilePrefab, _playerStatSheet.StatSheet);
        }

        private void Update()
        {
            _attackTimer += Time.deltaTime;
            float cooldown = _attackStrategy.GetAttackCooldown();

            if (_attackTimer >= cooldown)
            {
                _attackTimer = 0f;
                Transform nearest = FindNearestEnemy();
                _attackStrategy.Attack(transform, nearest);
            }
        }

        private Transform FindNearestEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Transform nearest = null;
            float minDist = Mathf.Infinity;

            foreach (GameObject enemy in enemies)
            {
                float dist = Vector2.Distance(transform.position, enemy.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    nearest = enemy.transform;
                }
            }
            return nearest;
        }
    }
}