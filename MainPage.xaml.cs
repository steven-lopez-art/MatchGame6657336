namespace MatchGame6657336
{
    public partial class MainPage : ContentPage
    {

        IDispatcherTimer timer;
        int milisegundo;
        int pares; 

        int count = 0;

        public MainPage()
        {
            timer = Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;

            InitializeComponent();
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            milisegundo++;
            labelTime.Text = (milisegundo / 10f).ToString("0.00s");
            if (pares == 8)
            {
                timer.Stop();
                labelTime.Text = labelTime.Text + "Muy bien a finalizado el juego";
                Tiempo.IsVisible = true;
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐶","🐶",
                "🐵","🐵",
                "🦐","🦐",
                "🐘","🐘",
                "🦓","🦓",
                "🦒","🦒",
                "🐍","🐍",
                "🐬","🐬"
            };
            Random random = new Random();
            foreach (Button view in Grid1.Children)
            {
                int index = random.Next(animalEmoji.Count);

                string nextEmoji = animalEmoji[index];

                view.Text = nextEmoji;

                animalEmoji.RemoveAt(index);
            }
            timer.Start();
            milisegundo = 0;
            pares = 0;
        }

        Button ultimoButtonClicked;
        bool encontrandoMatch = false;

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (encontrandoMatch == false)
            {
                button.IsVisible = false;
                ultimoButtonClicked = button;
                encontrandoMatch = true;

            }else if(button.Text == ultimoButtonClicked.Text)
            {
                pares++;
                button.IsVisible = false;
                encontrandoMatch = false;
            }
            else
            {
                ultimoButtonClicked.IsVisible = true;
                encontrandoMatch = false; 
            }   
        }
        
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            SetUpGame();
            Tiempo.IsVisible = false;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            ReiniciarAplicacion();
        }
        private void ReiniciarAplicacion()
        {
            Application.Current.MainPage = new MainPage();
        }
    }
} 