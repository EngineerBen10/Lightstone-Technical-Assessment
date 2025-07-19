namespace Lightstone.Assessment
{
    public interface IReverseWord
    {
        string ReversWords(string input);
    }

    public class ReverseWord : IReverseWord
    {
        public string ReversWords(string input)
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
                var result = _reverseWord.ReversWords(line);

                reverseDict.Add($"Case {i}", result);
            }

            foreach (var kvp in reverseDict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var reverseWord = new ReverseWord();
            var reverseWordHandler = new ReversWordHandler(reverseWord);

            reverseWordHandler.Proccess();
        }
    }
}