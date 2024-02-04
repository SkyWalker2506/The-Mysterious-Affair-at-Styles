using System;

namespace Game.DialogueSystem
{
    [Serializable]
    public class CharacterDialogueCouple
    {
        public GameCharacter Character;
        public DialogueIndexCouple[] DialogueIndexCouples;
    }
}