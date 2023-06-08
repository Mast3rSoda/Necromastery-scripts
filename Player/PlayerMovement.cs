using Scripts.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private InputAction _moveAction;
        private Vector2 _moveDirection;
        
        private Rigidbody _rb;

        [SerializeField] private LayerMask _groundLayer;

        //Movement consts
        private readonly float f_moveSpeed = 40f;
        private readonly float f_maxSpeed = 12f;

        //Countermovement consts
        private readonly float f_stopThreshold = 0.3f;
        private readonly float f_counterActionThreshold = 0.05f;
        private readonly float f_counterMovementMult = 0.5f;

        //Variables
        private bool b_isGrounded = true;


        [Inject]
        public void Init(Rigidbody rb)
        {
            _rb = rb;
        }

        public void ReceiveInputAction(InputActionSignal inputActionSignal)
        {
            _moveAction = inputActionSignal.inputAction;
        }

        private void FixedUpdate()
        {
            if (!b_isGrounded) return;

            Vector3 moveDirection = GetNormalizedMoveDirection(_moveAction.ReadValue<Vector2>());
            _rb.AddForce(f_moveSpeed * moveDirection, ForceMode.Force);

            CounterMovement(moveDirection);

            SpeedCheck();
        }

        private Vector3 GetNormalizedMoveDirection(Vector2 inputVector)
        {
            Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
            moveDirection.Normalize();
            return moveDirection;
        }

        private void SpeedCheck()
        {
            Vector3 xzPlaneVelocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
            if (xzPlaneVelocity.magnitude > f_maxSpeed) _rb.AddForce(f_moveSpeed * -xzPlaneVelocity.normalized, ForceMode.Force);
        }

        private void CounterMovement(Vector3 moveDirection)
        {
            if (!b_isGrounded) return;

            Vector3 xzPlaneVelocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            //when no keypress and low velocity -> stop the player
            if (moveDirection.magnitude <= f_counterActionThreshold && xzPlaneVelocity.magnitude <= f_stopThreshold && xzPlaneVelocity.magnitude > 0.0001f)
            {
                _rb.velocity = Vector3.zero;
                return;
            }

            //when no keypress and high velocity -> slow down the player
            if (moveDirection.magnitude <= f_counterActionThreshold && xzPlaneVelocity.magnitude > f_stopThreshold)
            {
                _rb.AddForce(f_counterMovementMult * f_moveSpeed * -xzPlaneVelocity, ForceMode.Force);
                return;
            }

            //when the keypress is different than the move direction -> add force to change move direction
            if ((moveDirection - xzPlaneVelocity.normalized).magnitude > f_counterActionThreshold && xzPlaneVelocity.magnitude > f_stopThreshold)
            {
                _rb.AddForce(f_counterMovementMult * f_moveSpeed * xzPlaneVelocity.magnitude * (moveDirection - xzPlaneVelocity.normalized), ForceMode.Force);
                return;
            }
        }

        public void ExecuteRoll()
        {

        }

        private void OnCollisionStay(Collision collision)
        {
            if ((_groundLayer.value | (1 << collision.gameObject.layer)) != _groundLayer.value) return;

            b_isGrounded = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            if ((_groundLayer.value | (1 << collision.gameObject.layer)) != _groundLayer.value) return;

            b_isGrounded = false;
        }
    }
}
