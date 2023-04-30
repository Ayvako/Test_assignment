using System.Drawing;

namespace Hedgehog_test.src
{
    public static class Processor
    {
        private static readonly IComparer<State> WeightComparer = Comparer<State>.Create((s1, s2) => s1.Weight.CompareTo(s2.Weight));
        public static List<State> Way { get; set; }
        public static int Steps { get; set; }

        public static int Start(int[] startArr, int color)
        {
            int[] endArr = new int[] { 0, 0, 0 };
            endArr[color] = startArr.Sum();
            State.End = endArr;



            if ((startArr.Sum() - startArr[color]) % 2 == 1)
                return -1;


            State startState = new(startArr);
            State endState = new(endArr);

            List<State> opens = new();
            List<State> closed = new();


            List<State> possibleStates;
            opens.Add(startState);
            while (opens.Count != 0)
            {
                Steps++;
                State currentState = opens[0];
                opens.RemoveAt(0);

                if (currentState.Equals(endState))
                {
                    Way = Methods.GetRightWay(currentState);
                    Way.Insert(0, startState);
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

    }
}
