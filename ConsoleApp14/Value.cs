namespace ConsoleApp14
{
    class Value : IExpr
    {
        public int v;

        public Value(int v)
        {
            this.v = v;
        }
        public int Accept(IVisitor v)
        {
            return v.VisitValue(this);
        }
    }
}