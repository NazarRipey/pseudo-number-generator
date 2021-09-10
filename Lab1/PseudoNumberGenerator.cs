using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    class PseudoNumberGenerator
    {
        private ulong _mod;
        private ulong _multiplier;
        private ulong _cummulative;
        private ulong _startingValue;

        private List<ulong> _sequence;
        private ulong _period;

        public PseudoNumberGenerator(ulong mod, ulong multiplier, ulong cummulative, ulong startingValue)
        {
            _mod = mod;
            _multiplier = multiplier;
            _cummulative = cummulative;
            _startingValue = startingValue;

            _sequence = new List<ulong>();
            _period = 0;
        }

        public List<ulong> GenerateNumbers(ulong counter)
        {
            for (ulong i = 0; i < counter; ++i)
            {
                ulong n;
                if (_sequence.Count == 0)
                {
                    n = _startingValue;
                }
                else
                {
                    n = _sequence.Last();
                }
                _sequence.Add(SequenceFormulaGetNext(n));
            }

            CheckPeriod();

            return _sequence;
        }

        public string GetPeriod()
        {
            return _period != 0 ? $"Period = {_period}" :
                "Period hasn't been found, try generating more numbers";
        }

        private ulong SequenceFormulaGetNext(ulong currentNumber)
        {
            return (_multiplier * currentNumber + _cummulative) % _mod;
        }

        private void CheckPeriod()
        {
            int duplicationIndex = _sequence.IndexOf(_sequence.First(), 1);
            _period = duplicationIndex > 0 ? (ulong)duplicationIndex : 0;
        }
    }
}
