using UnityEngine;
using UnityEngine.InputSystem;
using FirstRoguelike.Stats;

namespace FirstRoguelike.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerStatSheet _playerStatSheet;
        private Vector2 _moveInput;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerStatSheet = GetComponent<PlayerStatSheet>();
        }

        public void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
        }

        private void FixedUpdate()
        {
            float speed = _playerStatSheet.StatSheet.GetStat(StatType.MoveSpeed);
            _rb.linearVelocity = _moveInput * speed;
        }
    }
}