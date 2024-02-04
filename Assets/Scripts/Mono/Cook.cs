using DetectiveGame.Character;
using DetectiveGame.FiniteStateSystem;

namespace Game.Character
{
    public class Cook : CharacterBase
    {
        public static Cook Instance;

        private CookStateController cookStateController;
        protected override void Initialize()
        {
            cookStateController = new CookStateController(this);
            Instance = this;
        }
    }
}
