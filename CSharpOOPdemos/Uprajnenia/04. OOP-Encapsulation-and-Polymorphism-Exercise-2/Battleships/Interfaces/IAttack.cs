namespace Battleships.Interfaces
{
    using Battleships.Ships;

    internal interface IAttack
    {
        string Attack(Ship targetShip);
    }
}