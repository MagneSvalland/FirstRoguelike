using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using FirstRoguelike.Blessings;
using FirstRoguelike.Bloodlines;
using UnityEngine.InputSystem;

namespace FirstRoguelike.UI
{
    public class BlessingSelectionUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject selectionPanel;
        [SerializeField] private List<BlessingCardUI> cards;
        [SerializeField] private BlessingManager blessingManager;
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private TraitTracker traitTracker;

        private List<(BlessingSO blessing, BloodlineSO bloodline)> _currentOffer;

        private void Update()
        {
            if (Keyboard.current.lKey.wasPressedThisFrame)
                ShowSelection();
        }

        public void ShowSelection()
        {
            _currentOffer = blessingManager.GetRandomOffer(3);
            selectionPanel.SetActive(true);
            Time.timeScale = 0f;

            for (int i = 0; i < cards.Count; i++)
            {
                if (i < _currentOffer.Count)
                    cards[i].Setup(_currentOffer[i].blessing, _currentOffer[i].bloodline, OnCardSelected);
            }
        }

        private void OnCardSelected(BlessingSO blessing, BloodlineSO bloodline)
        {
            playerInventory.AddBlessing(blessing, bloodline);
            traitTracker.AddBloodline(bloodline);
            selectionPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}