using System;

public class Axe
{
    private int attackPoints;
    private int durabilityPoints;

    public Axe(int attack, int durability)
    {
        attackPoints = attack;
        durabilityPoints = durability;
    }

    public int AttackPoints => attackPoints;

    public int DurabilityPoints => durabilityPoints;

    public void Attack(Dummy target)
    {
        if (durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(attackPoints);
        durabilityPoints -= 1;
    }
}
