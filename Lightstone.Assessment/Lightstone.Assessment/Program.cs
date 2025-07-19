namespace Lightstone.Assessment
{
    public interface IReverseWord
    {
        string ReversWords(string input);
    }

    public class ReversWord : IReverseWord
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}