using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menus for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter an input!\n");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                        
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.


            Svar till frågor:
             2. Kapaciteten ökar först när behover finns, alltså när ett element läggs i listan och mängden element blir högre än nuvarande kapacitet.

             3. Kapaciteten ökar först med 4 (enligt standard, ska gå att justera), sedan fördubblas varje gång. I och med att listan aldrig minskar i kapacitet kan detta bli ett problem.
                
             4. Enligt ett svar på stackoverflow sker detta för att skriva om den bakomliggande arrayn till en ny och större array krävs en hel del arbeteskraft.
                Jag gissar på att för att undvika göra detta så mycket som möjligt så dubbleras arrayns storlek varje gång.

             5. theList minskar aldrig i storlek. Även om listan blir helt tömd behåller den sin minnesreservering för att bibehålla sin kapacitet.

             6. Om man vill ha kontroll på exakt hur mycket minne listan får som mest ta plats i systemet kan det vara bra att då använda en fördefinierad array istället.

            */
            List<string> theList = new List<string>();
            bool running = true;

            while (running)
            {

                Console.WriteLine("The list has a capacity of  " + theList.Capacity + " elements right now.\n" +
                    "You can add elements to the list by adding a + prefix to a string e.g. "+ '"' + "Adam" + '"' + ".\n" +
                    "You can remove elements from the list by adding a - prefix to a string e.g. "+'"'+"-Adam" +'"' + ".\n" +
                    "You can print out the entire list using the 'p' command.\n" +
                    "To return back to the Main Menu, write 0.");
                string input = Console.ReadLine()!;
                char nav = ' ';
                string value = "";

                try
                {
                    nav = input[0]; //Tries to fetch the first character in the input string.
                    //ToDo: Validate that substring isnt empty.
                    value = input.Substring(1); //Creates a substring that ignores the first character of the input string.
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    //Error message found in switches default-case.
                }
                switch (nav)
                    {
                    case '+':
                        Console.Clear();
                        theList.Add(value);
                        Console.WriteLine(value + " has been added to the list");
                        break;

                    case '-':
                        Console.Clear();
                        theList.Remove(value);
                        Console.WriteLine(value + " has been removed from the list");
                        break;

                    case 'p':
                        Console.Clear();
                        foreach (string s in theList) {Console.WriteLine(s); }
                        Console.WriteLine();
                        break;

                    case '0':
                        running = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid input.");
                        break;
                    }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new Queue<string>();
            bool running = true;

            while (running)
            {

                Console.WriteLine("You can add elements to the queue by adding a + prefix to a string e.g. " + '"' + "Adam" + '"' + ".\n" +
                    "You can remove elements from the queue by using the '-' command. \n" +
                    "To return back to the Main Menu, write 0.");
                string input = Console.ReadLine()!;
                char nav = ' ';
                string value = "";

                try
                {
                    nav = input[0]; //Tries to fetch the first character in the input string.

                    //ToDo: Validate that substring isnt empty.
                    value = input.Substring(1); //Creates a substring that ignores the first character of the input string.
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    //Error message found in switches default-case.
                }
                switch (nav)
                {
                    case '+':
                        Console.Clear();
                        theQueue.Enqueue(value);
                        Console.WriteLine(value + " has joined the queue which now consists of: ");
                        foreach (string s in theQueue) { Console.WriteLine(s); }
                        Console.WriteLine();
                        break;

                    case '-':
                        Console.Clear();
                        string removed = theQueue.First();
                        theQueue.Dequeue();
                        Console.WriteLine(removed + " has left the queue and it now consists of:");
                        foreach (string s in theQueue) { Console.WriteLine(s); }
                        Console.WriteLine();
                        break;

                    case '0':
                        running = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<string> theStack = new Stack<string>();
            bool running = true;

            while (running)
            {

                Console.WriteLine("You can add elements to the stack by adding a + prefix to a string e.g. " + '"' + "Adam" + '"' + ".\n" +
                    "You can remove elements from the stack by using the '-' command. \n" +
                    "You can reverse and input string by using the 'r' command. \n" +
                    "To return back to the Main Menu, write 0.");
                string input = Console.ReadLine()!;
                char nav = ' ';
                string value = "";

                try
                {
                    nav = input[0]; //Tries to fetch the first character in the input string.

                    //ToDo: Validate that substring isnt empty.
                    value = input.Substring(1); //Creates a substring that ignores the first character of the input string.
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    //Error message found in switches default-case.
                }
                switch (nav)
                {
                    case '+':
                        Console.Clear();
                        theStack.Push(value);
                        Console.WriteLine(value + " has joined the stack which now consists of: ");
                        foreach (string s in theStack) { Console.WriteLine(s); }
                        Console.WriteLine();
                        break;

                    case '-':
                        Console.Clear();
                        string removed = theStack.LastOrDefault()!; //Can return null if stack is empty.
                        theStack.Pop();
                        Console.WriteLine(removed + " has left the stack and it now consists of:");
                        foreach (string s in theStack) { Console.WriteLine(s); }
                        Console.WriteLine();
                        break;

                    case 'r':
                        Console.WriteLine("Enter the text to be reversed.");
                        string reverse = Console.ReadLine()!;
                        if (!string.IsNullOrEmpty(reverse) || !string.IsNullOrWhiteSpace(reverse)) { Console.WriteLine(ReverseString(reverse)); }
                        else { Console.WriteLine("This can't be left empty."); }
                        break;

                    case '0':
                        running = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            }
        }

        private static string ReverseString(string input)
        {
            StringBuilder result = new();
            Stack<char> stack = new Stack<char>();
            char[] chars = input.ToCharArray(); //Take input string, turn it into a char[].
            foreach (char c in chars) {stack.Push(c); } //Go through the char[], place elements in order to the stack.
            foreach (char c in stack) {result.Append(c);} //Going through the stack now reverses the order of the elements.
            return result.ToString(); //Return the reversed input string.
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            //THE PLAN: Gör en stack, gå igenom strängen en karaktär i taget, om karaktären är {, [ eller (, lägg den i stacken.
            //Om karaktären är en ), ] eller }, kolla i stacken. Om den Pop'ade karaktären från stacken är motsvarande öppnare så allt bra.
            //Om stacken är tom eller Pop'ade karaktären inte är korrekt öppningsparantes är strängen ogiltigt skriven.
            Stack<char> stack = new Stack<char>();
            bool stringIsValid = true;
            Console.WriteLine("Input the string you would like to check:");
            string str = Console.ReadLine()!;
            foreach (char c in str)
            {
                if (c == '{' || c == '[' || c == '(') { stack.Push(c); }
                else if (c == '}' || c == ']' || c == ')')
                {
                    switch (c)
                    {
                        case '}':
                            if (stack.Count == 0 ||stack.First<char>() != '{') { stringIsValid = false; }
                            else { stack.Pop(); }
                            break;

                        case ']':
                            if (stack.Count == 0 || stack.First<char>() != '[') { stringIsValid = false; }
                            else { stack.Pop(); }
                            break;

                        case ')':
                            if (stack.Count == 0 || stack.First<char>() != '(') { stringIsValid = false; }
                            else { stack.Pop(); }
                            break;
                    }
                }
            }
            if (stack.Count > 0) { stringIsValid = false; }

            Console.Clear();
            if (stringIsValid)
            {
                Console.WriteLine("The input string has properly closed parantheses.\n");
            }
            else { Console.WriteLine("The input string did -not- have properly closed parantheses.\n"); }
         }
    }
}

