using System;
using System.Collections.Generic;
using System.Text;

namespace PlatformerTest
{
    enum Weapon
    {
        Base,
        Shotgun,
        Rapid,
        Sniper,
        Rocket,
        Laser
    }
    class Player
    {
        //Collected variables to track progress
        public bool doubleJumpCollected;
        public bool dashCollected;
        public bool gunBoostCollected;
        public bool iFrameEnhanceCollected;
        public bool slideCollected;
        public bool grappleCollected;
        public bool canJump;
        public bool onGround;
        public bool facingLeft;
        public bool storedFacing;
        public float boostTimer;
        public int boostCapacity;
        public int jumpTimer;
        public int dashTimer;
        public int dashTurnaroundTimer;
        public Weapon weapon;
        public float speed;

        public int frenzyNeeded;
        public int maxFrenzy;
        public int frenzyTimer;

        public int baseHealth;
        public int additionalHealth;
        public float healthMod;
        public float maxHealth { get { return ((baseHealth * healthMod) + additionalHealth); }}

        public int baseDamage;
        public int additionalDamage;
        public float damageMod;
        public float damage { get { return ((baseDamage * damageMod) + additionalDamage); }}

        public float baseDefense;
        public float additionalDefense;
        public float defenseMod;
        public float defense { get { return ((baseDefense * defenseMod) + additionalDefense); }}
        public Player()
        {
            onGround = true;
            maxFrenzy = 100;
            frenzyNeeded = maxFrenzy;
        }
    }
}
