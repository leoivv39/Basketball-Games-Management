using client.exception;
using client.service;
using main.dto;

namespace client
{
    public partial class LoginForm : Form
    {
        private readonly IUserService userService;
        private readonly IGameService gameService;
        private readonly ISoldTicketService soldTicketService;

        public LoginForm(IUserService userService, IGameService gameService, ISoldTicketService soldTicketService)
        {
            this.userService = userService;
            this.gameService = gameService;
            this.soldTicketService = soldTicketService;
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameField.Text;
            string password = passwordField.Text;
            if (username.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Both fields are mandatory", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                UserDto user = userService.GetUserByUsernameAndPassword(new UserDto { Username = username, Password = password });
                var mainPage = new MainPage(gameService, soldTicketService, user);
                mainPage.Show();
            }
            catch (EntityNotFoundException)
            {
                MessageBox.Show("Invalid username and/or password", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
