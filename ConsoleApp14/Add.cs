namespace ConsoleApp14
{
    class Add : IExpr
    {

        public IExpr Lhs;

        public Add(IExpr lhs, IExpr rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public IExpr Rhs;

        public int Accept(IVisitor v)
        {
            return v.VisitAdd(this);
        }
    }
}