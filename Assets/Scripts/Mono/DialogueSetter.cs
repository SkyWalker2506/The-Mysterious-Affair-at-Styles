using System.Linq;
using DialogueSystem;
using Game.Character;
using UnityEngine;

namespace Game.DialogueSystem
{
    public class DialogueSetter : MonoBehaviour
    {
        [SerializeField] private CharacterDialogueCouple[] characterDialogueCouples;

        private void Awake()
        {
            SetCharacterDialogues(0);
        }

        private void SetCharacterDialogues(int index)
        {
            IDialogueData dialogueData = GetDialogueData(GameCharacter.AlfredInglethorp, index);
            if (dialogueData != null)
            {
                HusbandAlfred.Instance.DialogueController.SetDialogueData(dialogueData);
            }
        }
        
        private IDialogueData GetDialogueData(GameCharacter character,int index)
        {
            CharacterDialogueCouple cdc = GetCharacterDialogueCouple(character);
            if (cdc == null)
            {
                return null;
            }
            var dic = GetDialogueData(cdc,index);

            return dic?.DialogueData;
        }
        
        private CharacterDialogueCouple GetCharacterDialogueCouple(GameCharacter character)
        {
            return characterDialogueCouples.First(cdc => cdc.Character == character);
        }

        private DialogueIndexCouple GetDialogueData(CharacterDialogueCouple cdc, int index)
        {
            return cdc.DialogueIndexCouples.First(dic => dic.Index == index);
        }
    }
}