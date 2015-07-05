namespace MassEffect.Engine.Factories
{
    using System;

    using MassEffect.GameObjects.Enhancements;

    public class EnhancementFactory
    {
        public Enhancement Create(EnhancementType enhancementType)
        {
            switch (enhancementType)
            {
                case EnhancementType.ThanixCannon:
                    return new ThanixCannon("ThanixCannon");
                case EnhancementType.KineticBarrier:
                    return new KineticBarrier("KineticBarrier");
                case EnhancementType.ExtendedFuelCells:
                    return new ExtendedFuelCells("ExtendedFuelCells");
                default:
                    throw new ArgumentException("Not known enhancement.");
            }
        }
    }
}