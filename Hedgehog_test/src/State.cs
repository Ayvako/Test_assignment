namespace Hedgehog_test.src
{
    public class State
    {
        public int[] Field { get; private set; }
        public int Weight { get; private set; }
        public State? Parent { get; private set; }
        public static int[] EndState { get; set; }
        public static int[] StartState { get; set; }


        public static void SetStartEnd(int[] startState, int[] endState)
        {
            StartState = startState;
            EndState = endState;
        }

        public State(int[] field, State parent)
        {
            Field = field;
            Parent = parent;
            Weight = CalcWeight();
        }

        public State(int[] field)
        {
            Field = field;
            Parent = null;
            Weight = CalcWeight();
        }

        private int CalcWeight()
        {
            return Math.Abs(EndState[0] - Field[0]) + Math.Abs(EndState[1] - Field[1]) + Math.Abs(EndState[2] - Field[2]);
        }

        public override string ToString()
        {
            return $"[Red: {Field[0]}, Green: {Field[1]}, Blue: {Field[2]}]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            State other = (State)obj;
            return Field.SequenceEqual(other.Field);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static int[] CalcEndState(int[] startState, int color)
        {
            int[] endArr = new int[] { 0, 0, 0 };
            endArr[color] = startState.Sum();
            return endArr;
        }

    }
}