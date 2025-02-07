using automacao_saucedemo.Pages;
using OpenQA.Selenium;

namespace automacao_saucedemo.Flows
{
    /// <summary>
    /// Classe que representa o fluxo de login, combinando as ações da página de login.
    /// </summary>
    public class LoginFlow
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        /// <summary>
        /// Construtor que inicializa o WebDriver e a página de login.
        /// </summary>
        public LoginFlow(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
        }

        /// <summary>
        /// Realiza o login no sistema com um usuário e senha fornecidos.
        /// </summary>
        
        public void RealizarLogin(string usuario, string senha)
        {
            loginPage.PreencherUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarLogin(); 
        }
    }
}
