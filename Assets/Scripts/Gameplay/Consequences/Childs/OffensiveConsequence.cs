using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consequence", menuName = "MyStuffs/Consequences/Offensive")]
public class OffensiveConsequence : StatusOnlyConsequence
{
    public ElementalType type = ElementalType.Neutral;
    public int baseDamages, howManyTimes=1,recoilDamages = 0;

    protected override void ConsequenceAction()
    {
        var attack = new Attack(baseDamages, type, _launcher,_target);
        for (int i = 0; i < howManyTimes; i++) 
        { 
            _target.ReceiveAttack(attack);
        }
        if( recoilDamages > 0 ) 
        {
            _launcher.AutoInflictedDamage(recoilDamages);
        }
        base.ConsequenceAction();
    }

    public override string GetDescription()
    {
        var retBaseDam = $"{baseDamages.ColorizeString(ColorizeExtention.DammageColor)} Damages. ";
        var retRecDam = $"{recoilDamages.ColorizeString(ColorizeExtention.DammageColor)} Recoil Damages. ";
        var retAmount = $"{howManyTimes.ColorizeString(ColorizeExtention.DammageColor)} Times. ";
        var retBase = base.GetDescription();
        return retBaseDam + (recoilDamages>0?retRecDam:string.Empty) + retBase + (howManyTimes>1?retAmount:string.Empty) ;
    }
}

