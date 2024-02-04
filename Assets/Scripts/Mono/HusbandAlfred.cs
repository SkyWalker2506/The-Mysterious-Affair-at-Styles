using DetectiveGame.Character;
using DetectiveGame.FiniteStateSystem;

namespace Game.Character
{
    public class HusbandAlfred : CharacterBase
    {
        public static HusbandAlfred Instance;
        private AlfredStateController alfredStateController;
        protected override void Initialize()
        {
            alfredStateController = new AlfredStateController(this);
            Instance = this;
        }
        
        
    }
}