namespace ConsoleApp14
{
    class Printer : IVisitor
    {
        public int VisitAdd(Add e)
        {
            e.Lhs.Accept(this);

            Console.Write(" + ");

            e.Rhs.Accept(this);
            return 0;
        }

        public int VisitParanExpr(ParanExpr e)
        {
            Console.Write("(");
            e.sub.Accept(this);
            Console.Write(")");
            return 0;
        }

        public int VisitSub(Sub e)
        {
            e.Lhs.Accept(this);

            Console.Write(" - ");

            e.Rhs.Accept(this);
            return 0;
        }

        public int VisitValue(Value e)
        {
            Console.Write(e.v);
            return 0;
        }
    }
}