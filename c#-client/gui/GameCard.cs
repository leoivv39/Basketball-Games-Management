using client.service;
using main.dto;

namespace client
{
    public partial class GameCard : UserControl
    {
        private readonly ISoldTicketService soldTicketService;
        private readonly UserDto loggedInUser;
        private GameDto gameModel;

        public GameCard(GameDto gameModel, ISoldTicketService soldTicketService, UserDto loggedInUser)
        {
            this.gameModel = gameModel;
            this.soldTicketService = soldTicketService;
            this.loggedInUser = loggedInUser;
            soldTicketService.OnNewSoldTicket(OnNewSoldTicket);
            InitializeComponent();
        }

        private void GameCard_Load(object sender, EventArgs e)
        {
            LoadCard();
        }

        private void noOfTicketsField_TextChanged(object sender, EventArgs e)
        {
            string txt = ((TextBox)sender).Text;
            if (txt.Length > 0 && !int.TryParse(txt, out int res))
            {
                noOfTicketsField.Text = txt.Remove(txt.Length - 1);
            }
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            var buyerName = buyerNameField.Text;
            var noOfTicketsStr = noOfTicketsField.Text;
            if (buyerName.Length == 0 || noOfTicketsStr.Length == 0)
            {
                MessageBox.Show("Both fields are mandatory", "Buy error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int.TryParse(noOfTicketsField.Text, out int noOfTickets);
            if (noOfTickets > gameModel.NumberOfSeats)
            {
                MessageBox.Show("There are not that many tickets in stock", "Buy error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SoldTicketDto savedTicket = soldTicketService.AddSoldTicket(new SoldTicketDto
            {
                SoldBy = loggedInUser,
                Game = gameModel,
                SoldAt = DateTime.Now,
                NumberOfSeats = noOfTickets,
                Username = buyerName
            });
            gameModel = savedTicket.Game;
            LoadCard();
            MessageBox.Show("Ticket(s) bought successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadCard()
        {
            if (gameModel.NumberOfSeats == 0)
            {
                BackColor = Color.DarkRed;
                buyButton.Visible = false;
                soldOutLabel.Visible = true;
            }
            firstCityLabel.Text = gameModel.FirstTeam.City.ToString();
            secondCityLabel.Text = gameModel.SecondTeam.City.ToString();
            firstTeamLabel.Text = gameModel.FirstTeam.Name;
            secondTeamLabel.Text = gameModel.SecondTeam.Name;
            gameTypeLabel.Text = gameModel.Type.ToString();
            timeLabel.Text = gameModel.Time.ToString();
            priceLabel.Text = gameModel.TicketPrice.ToString();
            availableTicketsLabel.Text = gameModel.NumberOfSeats.ToString();
        }

        private void OnNewSoldTicket(SoldTicketDto newTicket)
        {
            if (newTicket.Game.Id == gameModel.Id)
            {
                gameModel = newTicket.Game;
            }
            LoadCard();
        }
    }
}
