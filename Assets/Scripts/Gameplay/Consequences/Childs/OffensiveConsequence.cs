using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consequence", menuName = "MyStuffs/Consequences/Offensive")]
public class OffensiveConsequence : StatusOnlyConsequence
{
    public ElementalType type = ElementalType.Neutral;
    public int baseDamages, howManyTimes=1,recoilDamages = 0;
    public bool leechLife;
    protected override void ConsequenceAction()
    {
        var damage = baseDamages + _launcher.Stats.Strength;
        var attack = new Attack(damage, type, _launcher,_target);


        for (int i = 0; i < howManyTimes; i++) 
        { 
            if(leechLife)
            {
                _target.ReceiveAttack(attack, (int i)=> _launcher.Heal(i));
            }
            else
            {
                _target.ReceiveAttack(attack);
            }
        }
        if( recoilDamages > 0 ) 
        {
            _launcher.AutoInflictedDamage(recoilDamages);
        }
        base.ConsequenceAction();
    }

    public override string GetDescription(FightingInstance launcher = null)
    {
        var launcherStat = launcher != null? launcher.Stats.Strength : 0;
        var retBaseDam = $"{(baseDamages+launcherStat).ColorizeString(ColorizeExtention.DammageColor)} Damages. ";
        var retRecDam = $"{recoilDamages.ColorizeString(ColorizeExtention.DammageColor)} Recoil Damages. ";
        var retAmount = $"{howManyTimes.ColorizeString(ColorizeExtention.DammageColor)} Times. ";
        var retBase = base.GetDescription(launcher);
        return retBaseDam + (recoilDamages>0?retRecDam:string.Empty) + retBase + (howManyTimes>1?retAmount:string.Empty) ;
    }
}

