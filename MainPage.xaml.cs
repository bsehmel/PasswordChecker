using System.Runtime.CompilerServices;

namespace PasswordChecker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPasswordUpdated(object sender, EventArgs e)
        {
            string password = Password.Text;
            int criteria = 0;

            if (password.Length >= 8)
            {
                Length.TextColor = new Color(0, 255, 0);
                criteria++;
            }
            else
                Length.TextColor = new Color(0, 0, 0);

            if (ContainsCharacter(password, "0123456789"))
            {
                Number.TextColor = new Color(0, 255, 0);
                criteria++;
            }
            else
                Number.TextColor = new Color(0, 0, 0);

            if (ContainsCharacter(password, "~!@#$%^&*()_+-={}[]|\\:\";'<>?,./"))
            {
                Symbol.TextColor = new Color(0, 255, 0);
                criteria++;
            }
            else
                Symbol.TextColor = new Color(0, 0, 0);

            switch(criteria)
            {
                case 0:
                    Result.Text = "Weak Password";
                    Result.TextColor = new Color(255, 255, 255);
                    break;
                case 1:
                    Result.Text = "Okay Password";
                    Result.TextColor = new Color(255, 0, 0);
                    break;
                case 2:
                    Result.Text = "Good Password";
                    Result.TextColor = new Color(255, 255, 0);
                    break;
                case 3:
                    Result.Text = "Strong Password";
                    Result.TextColor = new Color(0, 255, 0);
                    break;
            }
        }

        private bool ContainsCharacter(string input, string characters)
        {
            int l = characters.Length;
            for(int i = 0; i < l; i++)
            {
                char c = characters[i];
                if (input.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        /*private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }*/
    }

}
