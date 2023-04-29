using System.Drawing;

namespace Hedgehog_test.src
{
    public class Processor
    {
        private readonly int[] StartArr;
        private readonly int[] EndArr;
        private int Color { get; set; }
        private readonly IComparer<State> WeightComparer = Comparer<State>.Create((s1, s2) => s1.Weight.CompareTo(s2.Weight));

        public Processor(int[] arr, int color)
        {
            int[] endArr = new int[] { 0, 0, 0 };
            endArr[color] = arr.Sum();
            State.End = endArr;
            StartArr = arr;
            EndArr = endArr;
            Color = color;
        }

        public int Start()
        {

            if ((StartArr.Sum() - StartArr[Color]) % 2 == 1)
                return -1;

            int steps = 0;

            State startState = new(StartArr);
            State endState = new(EndArr);

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
