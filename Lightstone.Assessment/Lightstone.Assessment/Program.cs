namespace Lightstone.Assessment
{
    public interface IReverseWord
    {
        string ReverseWords(string input);
    }

    public class ReverseWord : IReverseWord
    {
        public string ReverseWords(string input)
        {
            if (string.IsNullOrWhiteSpace((input))) return string.Empty; // return empty string for whiteSpaces

            var words = input.Split(' '); // split string from the input

            Array.Reverse(words); // reverse words

            return string.Join(' ', words);

            /**  var reverseInput = ""; another solution that can work
          
              for (var i = words.Length - 1; i >= 0; i--)
              {
                  reverseInput += words[i];
                  if (i > 0) reverseInput += " "; // adding spaces between the words
              }

              return reverseInput; **/

        }
    }

    public class ReversWordHandler
    {
        private readonly IReverseWord _reverseWord;

        public ReversWordHandler(IReverseWord reverseWord)
        {
            _reverseWord = reverseWord;
        }

        public void Proccess()
        {
            Console.WriteLine("Enter the number of cases: ");

            var input = Console.ReadLine();
  
            Dictionary<string, string> reverseDict = new Dictionary<string, string>();
            // validate input base on requirements
            if (!int.TryParse(input, out int number) || number < 1 || number > 25)
            {
                Console.WriteLine("Invalid number of test cases \n");
                Proccess(); // excecute the process again
            }

            for (var i = 1; i <= number; i++)
            {
                Console.WriteLine($"Enter test cases: {i}");
                var line = Console.ReadLine();
                if (line == null) continue; // break if this happens
                var result = _reverseWord.ReverseWords(line);

                reverseDict.Add($"Case {i}", result);
            }

            foreach (var kvp in reverseDict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }


    public static class UnitTest
    {
        public static void Proccess()
        {
            var reverser = new ReverseWord();

            Assert(reverser.ReverseWords("Deploy microservices to Kubernetes") == "Kubernetes to microservices Deploy", "Test 1");
            Assert(reverser.ReverseWords("Continuous integration improves quality") == "quality improves integration Continuous", "Test 2");
            Assert(reverser.ReverseWords("Data-driven decisions require analytics") == "analytics requiredecisions Data-driven", "Test 3");

            Console.WriteLine("All tests passed.\n");
        }

        private static void Assert(bool condition, string testName)
        {
            if (!condition)
            {
                Console.WriteLine($"{testName} FAILED");
                Environment.Exit(1);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UnitTest.Proccess();
            // var reverseWord = new ReverseWord();
            // var reverseWordHandler = new ReversWordHandler(reverseWord);

            // reverseWordHandler.Proccess();
        }
    }
}