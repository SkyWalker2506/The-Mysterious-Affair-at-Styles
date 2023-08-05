using InteractionSystem;
using UnityEngine;

namespace Game
{
    public class GameInteractorLogic : IInteractorLogic
    {
        public Transform transform { get; }
        public IInteractor Interactor { get; }
        private float checkInterval;
        private float lastCheckedTime {get; set; }
        private IInteractable currentInteractable {get; set; }
        public GameInteractorLogic(Transform player, InteractorData data)
        {
            Interactor = new InteractOverlapSphere(player, data.CheckRadius, data.CheckAngle, data.InteractableLayerMask);
            checkInterval = data.CheckIntervalMS*.001f;
            transform = player;
        }
            
        public void Update()
        {
            Debug.Log(lastCheckedTime);
            if (lastCheckedTime + checkInterval < Time.time)
            {
                SetCurrentInteractable();
                SetInteractionUI();
                lastCheckedTime = Time.time;
            }
        }

        public void Interact()
        {
            if (currentInteractable != null)
            {
                Interactor.Interact(currentInteractable);
                currentInteractable = null;
                Interactor.InteractionUI.HideInteractionUI();
            }
        }

        private void SetCurrentInteractable()
        {
            currentInteractable = Interactor.GetInteractable();
            Debug.Log($"Interactable {currentInteractable}");
        }
        private void SetInteractionUI()
        {
            if (currentInteractable == null)
            {
                Interactor.InteractionUI.HideInteractionUI();
            }
            else
            {
                Interactor.InteractionUI.ShowInteractionUI(currentInteractable);
            }   
        }
    }
}
