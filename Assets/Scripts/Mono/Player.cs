using System;
using InteractionSystem;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputAsset playerInput;
        [SerializeField] private InteractorData interactorData;
        private IInteractorLogic interactorLogic;

        private void Awake()
        {
            interactorLogic = new GameInteractorLogic(transform, interactorData);
            playerInput = new PlayerInputAsset();
        }

        private void OnEnable()
        {
            playerInput.Enable();
            playerInput.Player.Interact.performed += TryInteract;
        }

        private void OnDisable()
        {
            playerInput.Disable();
            playerInput.Player.Interact.performed -= TryInteract;
        }

        private void Update()
        {
            interactorLogic.Update();
        }
        
        private void TryInteract(InputAction.CallbackContext obj)
        {
            interactorLogic.Interact();
        }
        
    }
}
