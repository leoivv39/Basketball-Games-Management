using client.service;
using main.dto;

namespace client
{
    public partial class MainPage : Form
    {
        private readonly UserDto loggedInUser;
        private readonly IGameService gameService;
        private readonly ISoldTicketService soldTicketService;

        public MainPage(IGameService gameService, ISoldTicketService soldTicketService, UserDto loggedInUser)
        {
            this.gameService = gameService;
            this.soldTicketService = soldTicketService;
            this.loggedInUser = loggedInUser;
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            gamesPanel.AutoScroll = true;
            LoadGames(gameService.AllGames);
        }

        private void LoadGames(IEnumerable<GameDto> games)
        {
            gamesPanel.Controls.Clear();
            int y = 0;
            foreach (var game in games)
            {
                var gameCard = new GameCard(game, soldTicketService, loggedInUser);
                gameCard.Location = new Point(0, y);
                gamesPanel.Controls.Add(gameCard);
                y += gameCard.Height + 10;
            }
        }

        private void showAvailableGamesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (showAvailableGamesCheckbox.Checked)
            {
                LoadGames(gameService.AllAvailableGames);
            }
            else
            {
                LoadGames(gameService.AllGames);
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
