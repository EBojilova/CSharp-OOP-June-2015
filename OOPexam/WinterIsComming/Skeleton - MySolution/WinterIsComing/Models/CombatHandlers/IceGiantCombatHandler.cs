namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Models.Spells;

    internal class IceGiantCombatHandler : CombatHandler
    {
        public IceGiantCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            ////- casts Stomp on all units in range.
            ////  If his health is less or equal to 150, Stomp is cast only on the first unit in range
            this.ValidateTargets(candidateTargets);
            if (this.Unit.HealthPoints <= 150)
            {
                return candidateTargets.Take(1).ToList();
            }

            return candidateTargets.ToList();
        }

        public override ISpell GenerateAttack()
        {
            /////Each time he casts Stomp, the Ice Giant's attack points are increased by 5. 
            /////Stomp damage: Equal to the Ice Giant's attack points.
            var spell = new Stomp(this.Unit.AttackPoints);
            this.ValidateEnergyPoints(this.Unit, spell);
            this.Unit.AttackPoints += 5;
            this.Unit.EnergyPoints -= spell.EnergyCost;
            return spell;
        }
    }
}