using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class orbCollector : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LSDVisionEffect lsdEffect;

    private void Awake(){
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent<ICollectable>(out ICollectable icoll)) {
            icoll.OnCollected();

            if (icoll is orb) {
                _animator.SetTrigger("Collected");
                _animator.SetLayerWeight(1, 1);
                Camera.main.GetComponent<CinemachineBrain>().enabled = true;

                var playerMover = GetComponent<PlayerMover>();
                if (playerMover != null) {
                    playerMover.canMove = false;
                    playerMover.ResetMovement();
                }

                var rb = GetComponent<Rigidbody>();
                if (rb != null) {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }

                // ACTIVAR EFECTO LSD
                if (lsdEffect != null) {
                    lsdEffect.ActivateEffect();
                }
            }
        }
    }
}
