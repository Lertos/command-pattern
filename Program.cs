namespace command_pattern
{
    //A demonstration of the Command pattern in C#
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Receiver 
            Canvas canvas = new Canvas();
            //The Sender
            Tool tool = new Tool();

            //Setting the state of the current Tool for testing purposes
            Tool.state = "brush";

            //Imagine a click event on the canvas
            tool.GetCommand().Execute(canvas);

            //Setting the state of the current Tool for testing purposes
            Tool.state = "fillbucket";

            //Imagine a click event on the canvas
            tool.GetCommand().Execute(canvas);

            /* OUTPUT:
             
                I am now using the Brush
                I am now using the FillBucket
             
             */
        }
    }

    public class Canvas { }

    interface Command
    {
        public void Execute(Canvas canvas);
    }

    class Tool
    {
        public static string state;

        public Command GetCommand()
        {
            if (state == "brush")
                return new Brush();
            else if (state == "fillbucket")
                return new FillBucket();

            return null;
        }
    }

    class Brush : Command
    {
        public void Execute(Canvas canvas)
        {
            Console.WriteLine("I am now using the Brush");
        }
    }

    class FillBucket : Command
    {
        public void Execute(Canvas canvas)
        {
            Console.WriteLine("I am now using the FillBucket");
        }
    }
}
