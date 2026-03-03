using GameCore.Base;

namespace GameCore.Classes {

    class Warrior : Character {

        public Warrior() {

            currentHealth = maxHealth =  100;
            currentMana = maxMana = 20;
            level = 1;
            experience = 0;
            gold = 10;
        }
    }
}
