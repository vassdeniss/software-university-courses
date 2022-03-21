using System;

public class Dummy
{
    private int health;
    private int experience;

    public Dummy(int health, int experience)
    {
        this.health = health;
        this.experience = experience;
    }

    public int Health => health;

    public void TakeAttack(int attackPoints)
    {
        if (IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return experience;
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
