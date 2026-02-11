using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Module4Challenge.Pages
{
    public class DadjokesGeneratorModel : PageModel
    {
        // Arrey with (12) dad jokes 
        public string[] AllJokes { get; set;} = new string[]
        {
            "I once heard a joke about amnesia, but I forgot how it goes.",
            "What do you call a bear with no teeth? A gummy bear",
            "I would avoid the sushi if I was you. It is a little fishy.",
            "Want to hear a joke about construction? I am still working on it.",
            "I used to play piano by ear, but now I use my hands.",
            "Why don't skeletons fight each other? They don't have the guts.",
            "I used to be indecisive. Now I'm not sure.",
            "I don't trust stairs. They're always up to something.",
            "Why did the cookie go to the doctor? It felt crummy.",
            "I used to be a banker but I lost interest.",
            "I used to be a baker, but I couldn't make enough dough.",
            "I'm on a seafood diet. When I see food, I eat it."   
        };

        //Property that holds the current displayed jokes.
        public List<string> DisplayedJokes { get; set; } = new List<string>();

        //Property for how many jokes to show at once.
        public int JokesCount { get; set; } = 2;

        public void OnGet()
        {
            // Generates initial jokes when the page first loads
            CreateRandomJokes();
        }
        
        public void OnPost()
        {
           // Select new jokes when the button is clicked
           CreateRandomJokes();
        }

        private void CreateRandomJokes()
        {
            // Random class to create random numbers
            Random rnd = new Random();
            
            // Clear the list to make sure it's empty before we add new jokes
            DisplayedJokes = new List<string>();

            // Loop until we have reached our desired count (2 jokes) 
            for (int i = 0; i < JokesCount; i++)
            {
                // Pick a random joke from the array.
                int index = rnd.Next(0, AllJokes.Length);
                string selectedJoke = AllJokes[index];

                // Check if the joke is already in our display list
                if (!DisplayedJokes.Contains(selectedJoke))
                {
                    DisplayedJokes.Add(selectedJoke);
                }
                else
                {
                    // If it was a duplicate, decrement 'i' so the loop tries this again
                    i--;
                }
            }
        }
    }
}