using UnityEngine;

public interface IDistanceFinder
{
    bool isAggroed { get; set; }
    bool isWithinAttackDistance { get; set; }

    void SetAggroStatus(bool IsAggroed);
    void AttackDistance(bool isWithingAttackDistance);
}
