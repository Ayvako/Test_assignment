namespace Hedgehog_test.src
{
    public class Methods
    {

        public static List<State> GetRightWay(State currentState)
        {
            List<State> rightPath = new();
            while (!(currentState.Parent == null))
            {
                rightPath.Add(currentState);
                currentState = currentState.Parent;
            }
            rightPath.Reverse();
            return rightPath;
        }

        public static List<State> AddPossibleStates(State state)
        {
            List<State> possibleStates = new();
            int nRed;
            int nGreen;
            int nBlue;
            int[] field = state.Field;

            if (field[0] > 0 && field[1] > 0)
            {
                nRed = field[0] - 1;
                nGreen = field[1] - 1;
                nBlue = field[2] + 2;

                possibleStates.Add(new State(new[] { nRed, nGreen, nBlue }, state));

            }
            if (field[0] > 0 && field[2] > 0)
            {
                nRed = field[0] - 1;
                nGreen = field[1] + 2; ;
                nBlue = field[2] - 1;

                possibleStates.Add(new State(new[] { nRed, nGreen, nBlue }, state));

            }
            if (field[1] > 0 && field[2] > 0)
            {

                nRed = field[0] + 2;
                nGreen = field[1] - 1;
                nBlue = field[2] - 1;

                possibleStates.Add(new State(new[] { nRed, nGreen, nBlue }, state));
            }

            return possibleStates;
        }

        public static List<State> RemoveDuplicates(List<State> possibleStates, List<State> states)
        {
            foreach (State state in states)
            {
                possibleStates.RemoveAll(a => state.Equals(a));
            }
            return possibleStates;
        }

        public static void PrintList<T>(List<T> list)
        {

            foreach (var l in list)
                Console.WriteLine(l);

        }

    
    }

}