namespace ConsoleApp14
{
    class Sub : IExpr
    {
        public IExpr Lhs;

        public Sub(IExpr lhs, IExpr rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public IExpr Rhs;
        public int Accept(IVisitor v)
        {
            return v.VisitSub(this);
        }
    }
}