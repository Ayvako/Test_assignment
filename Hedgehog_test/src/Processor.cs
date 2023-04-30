using System.Drawing;

namespace Hedgehog_test.src
{
    public static class Processor
    {
        private static readonly IComparer<State> WeightComparer = Comparer<State>.Create((s1, s2) => s1.Weight.CompareTo(s2.Weight));


        public static int Start(int[] startArr, int color)
        {
            int[] endArr = new int[] { 0, 0, 0 };
            endArr[color] = startArr.Sum();
            State.End = endArr;



            if ((startArr.Sum() - startArr[color]) % 2 == 1)
                return -1;

            int steps = 0;

            State startState = new(startArr);
            State endState = new(endArr);

            List<State> opens = new();
            List<State> closed = new();


            List<State> possibleStates;
            List<State> way = new();
            opens.Add(startState);
            while (opens.Count != 0)
            {
                steps++;
                State currentState = opens[0];
                opens.RemoveAt(0);

                if (currentState.Equals(endState))
                {
                    way = Methods.GetRightWay(currentState);
                    way.Insert(0, startState);
                    break;
                }

                possibleStates = Methods.AddPossibleStates(currentState);

                closed.Add(currentState);

                possibleStates = Methods.RemoveDuplicates(possibleStates, opens);
                possibleStates = Methods.RemoveDuplicates(possibleStates, closed);

                opens.AddRange(possibleStates);

                opens.Sort(WeightComparer);

            }
            return way.Count == 0 ? -1 : way.Count - 1;
        }

    }
}
