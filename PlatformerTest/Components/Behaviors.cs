using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;

namespace PlatformerTest
{
    public class Behavior
    {
        public bool Loop;
        public List<Condition> IndependentConditions;
        public List<Condition> OrderedConditions;
        public int OrderedIndex;
        public World World;

        public Behavior(bool loop, World world)
        {
            Loop = loop;
            World = world;
        }

        public void RegisterCondition(Condition condition)
        {
            if (condition.IndepedentCondition)
            {
                IndependentConditions.Add(condition);
            }
            else
            {
                OrderedConditions.Add(condition);
            }
        }

        public void RegisterCondition(List<Condition> conditions)
        {
            foreach (Condition c in conditions)
            {
                this.RegisterCondition(c);
            }
        }
    }

    public class Condition
    {
        public ConditionType Type;
        public bool IndepedentCondition;
        public int Time;
        public List<Effect> Effects;
        public bool RemoveOnUse;
        public Condition(ConditionType type, bool ind)
        {
            Type = type;
            IndepedentCondition = ind;
        }

        public Condition(int timer, bool ind, bool remove)
        {
            Type = ConditionType.Timer;
            IndepedentCondition = ind;
            Time = timer;
            RemoveOnUse = remove;
        }

        public void RegisterEffect(Effect effect)
        {
            Effects.Add(effect);
        }
    }


    public class Effect
    { }

    public class VelocityEffect : Effect
    {
        bool replaceVelocity;
        Vector2 velocityUpdate;

        public VelocityEffect(Vector2 update, bool replace)
        {
            velocityUpdate = update;
            replaceVelocity = replace;
        }
    }

    public class HealthEffect : Effect
    {
        bool replaceHealth;
        int healthUpdate;

        public HealthEffect(int update, bool replace)
        {
            replaceHealth = replace;
            healthUpdate = update;
        }
    }

    /*class RenderEffect : Effect
    {

    }*/

    public enum ConditionType
    {
        Timer,
        PlayerShoot,
        PlayerDash,
        PlayerJump,
        GroundEdge,
        Wall,
        EnemyCollision,
        Death,
        PlayerCollision
    }
}
