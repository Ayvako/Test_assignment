namespace Hedgehog_test.src
{
    public static class Processor
    {
        private static readonly IComparer<State> WeightComparer = Comparer<State>.Create((s1, s2) => s1.Weight.CompareTo(s2.Weight));
        public static List<State> Way { get; set; } = new List<State>();
        public static int Steps { get; set; }

        public static int Start(int[] startArr, int color)
        {

            if (!ArrIsCorrect(startArr))
                throw new ArgumentException($"The starting array({string.Join(", ", startArr)}) must consist of positive numbers whose sum is greater than zero.");

            if ((color>2||color<0))
                throw new ArgumentException($"The color({color}) must be integer value in range [0; 2].");


            if ((startArr.Sum() - startArr[color]) % 2 == 1)
                return -1;
            


            State.SetStartEnd(startArr, State.CalcEndState(startArr,color));

            State start = new (State.StartState);
            State end = new (State.EndState);

            List<State> opens = new();
            List<State> closed = new();


            List<State> possibleStates;
            opens.Add(start);
            while (opens.Count != 0)
            {
                Steps++;
                State currentState = opens[0];
                opens.RemoveAt(0);

                if (currentState.Equals(end))
                {
                    Way = Methods.GetRightWay(currentState);
                    Way.Insert(0, start);
                    break;
                }

                possibleStates = Methods.AddPossibleStates(currentState);

                closed.Add(currentState);

                possibleStates = Methods.RemoveDuplicates(possibleStates, opens);
                possibleStates = Methods.RemoveDuplicates(possibleStates, closed);

                opens.AddRange(possibleStates);

                opens.Sort(WeightComparer);

            }
            return Way.Count == 0 ? -1 : Way.Count - 1;
        }


        private static bool ArrIsCorrect(int[] startArr)
        {

            foreach (int i in startArr)
            {
                if (i < 0)
                {
                    return false;
                }
            }

            return startArr.Sum() > 0;

        }

    }
}
