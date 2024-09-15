using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGene : BaseGene
{
    public BodyType body;
    public override GeneType geneType => GeneType.Body;

    public override void AddEffect(BiodInfo biodInfo)
    {
        switch (body)
        {
            case BodyType.Horse:
                biodInfo.speed *= 2;
                biodInfo.defense *= 0.8f;
                break;
            case BodyType.Wolf:
                biodInfo.speed *= 1.5f;
                biodInfo.attack *= 1.5f;
                break;
            case BodyType.Elephant:
                biodInfo.speed *= 0.8f;
                biodInfo.defense *= 2;
                break;
        }
    }

}
public class MouthGene : BaseGene
{
    public MouthType GetMouthType;

    public override GeneType geneType => throw new System.NotImplementedException();

    public override void AddEffect(BiodInfo biodInfo)
    {
        throw new System.NotImplementedException();
    }

}
public class ApparentGene : BaseGene
{
    public ApparentType GetApparentType;

    public override GeneType geneType => throw new System.NotImplementedException();

    public override void AddEffect(BiodInfo biodInfo)
    {
        throw new System.NotImplementedException();
    }

}
public class HabitGene : BaseGene
{
    public HabitType GetHabitType;

    public override GeneType geneType => throw new System.NotImplementedException();

    public override void AddEffect(BiodInfo biodInfo)
    {
        throw new System.NotImplementedException();
    }

}


