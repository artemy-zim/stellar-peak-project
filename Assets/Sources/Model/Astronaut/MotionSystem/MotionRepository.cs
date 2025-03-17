using System;
using System.Collections.Generic;
using UnityEngine;

public class MotionRepository
{
    private readonly IEnumerable<MotionStage> _stages;
    private readonly IEnumerator<MotionStage> _enumerator;

    public MotionRepository(IEnumerable<MotionStage> stages)
    {
        Validate(stages);

        _stages = stages;
        _enumerator = _stages.GetEnumerator();
    }

    public MotionStage GetNextStage()
    {
        ValidationExtensions.ValidateIfNull(_enumerator);

        MoveToNext();

        return _enumerator.Current;
    }

    private void MoveToNext()
    {
        if(_enumerator.MoveNext() == false) 
        {
            _enumerator.Reset();
            _enumerator.MoveNext();
        }
    }

    private void Validate(IEnumerable<MotionStage> stages)
    {
        try
        {
            ValidationExtensions.ValidateIfNull(stages);

            foreach (MotionStage stage in stages)
                ValidationExtensions.ValidateIfNull(stage);
        }
        catch (ArgumentNullException ex)
        {
            string message = $"{ex.Message} can not be null in {GetType().Name}";

            Debug.LogError(message);
            throw ex;
        }
    }
}
