using OpenQA.Selenium;

namespace automacao_saucedemo.Pages
{
    /// <summary>
    /// Esta classe representa a página de login do site SauceDemo.
    /// Contém métodos para interagir com os elementos de login.
    /// </summary>
    public class LoginPage
    {
        private IWebDriver driver;
        private By campoUsuario = By.Id("user-name");
        private By campoSenha = By.Id("password");
        private By botaoLogin = By.Id("login-button"); //  Botão de login correto
        private By mensagemErro = By.CssSelector("[data-test='error']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Preenche o campo de usuário no formulário de login.
        /// </summary>
        
        public void PreencherUsuario(string usuario)
        {
            driver.FindElement(campoUsuario).SendKeys(usuario);
        }

        public void PreencherSenha(string senha)
        {
            driver.FindElement(campoSenha).SendKeys(senha);
        }

        public void ClicarLogin() 
        {
            driver.FindElement(botaoLogin).Click();
        }

        public string ObterMensagemDeErro()
        {
            return driver.FindElement(mensagemErro).Text;
        }

        public By ObterMensagemDeErroElemento()
        {
            return mensagemErro;
        }
    }
}
