using System.Reflection.Metadata;

namespace ConsoleApp14
{



    interface IVisitor
    {
        int VisitAdd(Add e);
        int VisitSub(Sub e);
        int VisitValue(Value e);
        int VisitParanExpr(ParanExpr e);
    }

    class Calc : IVisitor
    {
        public int VisitAdd(Add e)
        {
            return e.Lhs.Accept(this) + e.Rhs.Accept(this);
        }

        public int VisitParanExpr(ParanExpr e)
        {
            return e.sub.Accept(this);
        }

        public int VisitSub(Sub e)
        {
            return e.Lhs.Accept(this) - e.Rhs.Accept(this);
        }

        public int VisitValue(Value e)
        {
            return e.v;
        }
    }

    interface IStmt
    {

    }

    class BlockStmt : IStmt
    {

    }

    class Print : IStmt
    {
        public Print(string s)
        {
            Console.WriteLine(s);
        }
    }

    class IfStatement : IStmt
    {
        public IfStatement(IExpr cond, IStmt then, IStmt @else)
        {
            Cond = cond;
            Then = then;
            Else = @else;
        }
        public IExpr Cond { get; set; }

        public IStmt Then;
        public IStmt Else;
    }


    class ParanExpr : IExpr

    {
        public IExpr sub;

        public ParanExpr(IExpr sub)
        {
            this.sub = sub;
        }

        public int Accept(IVisitor v)
        {
            return v.VisitParanExpr(this);
        }
    }


    internal class Program
    {

        static void Foo(int k)
        {
            Console.WriteLine("Jeg blev kaldt med en tal");
        }
        static void Foo(string s)
        {
            Console.WriteLine("Jeg blev kaldt med en streng");
        }


        static void Main(string[] args)
        {


            IStmt s = new IfStatement(new Value(1), 
                new IfStatement(new Add(new Value(1), new Value(1)), 
                    new Print("en anden then"), 
                    new Print("else")),
                new Print("else"));

            Foo(1);
            Foo("String");

           
            Value lhs = new Value(1);
            Value rhs = new Value(2);

            // ((2))+3
            Add subexpr = new Add(new ParanExpr(new ParanExpr(new Value(2))), new Value(3));

            IExpr e = new Add(subexpr, 
                              new Sub(subexpr, 
                                      new Value(10)));

            //if (subexpr.Lhs is Add && subexpr.Rhs is Add)
            //{

            //}
            //else if (subexpr.Lhs is Value && Sub.Rhs is Add)

            Printer printervisitor = new Printer();

            e.Accept(printervisitor);

            printervisitor.VisitAdd((Add)e);

            Console.WriteLine();

            Calc c = new Calc();
            int result = e.Accept(c);
            Console.WriteLine(result);


        }
    }
}