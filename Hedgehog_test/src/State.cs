namespace Hedgehog_test.src
{
    public class State
    {
        public int[] Field { get; private set; }
        public int Weight { get; private set; }
        public State? Parent { get; private set; }
        public static int[] End { get; set; }
		
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
            return Math.Abs(End[0] - Field[0]) + Math.Abs(End[1] - Field[1]) + Math.Abs(End[2] - Field[2]);
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
    }
}