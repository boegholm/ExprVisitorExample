namespace ConsoleApp14
{
    interface IExpr
    {
        public int Accept(IVisitor v);
    }
}