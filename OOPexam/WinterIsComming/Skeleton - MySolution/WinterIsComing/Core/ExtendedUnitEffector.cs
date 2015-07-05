namespace WinterIsComing.Core
{
    using System.Collections.Generic;

    using WinterIsComing.Contracts;

    public sealed class ExtendedUnitEffector : IUnitEffector
    {
        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (var unit in units)
            {
                unit.HealthPoints += 50;
            }
        }
    }
}