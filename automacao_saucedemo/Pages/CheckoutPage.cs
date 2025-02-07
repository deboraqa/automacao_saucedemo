using OpenQA.Selenium;
using automacao_saucedemo.Bases;

namespace automacao_saucedemo.Pages
{
    public class CheckoutPage : TestBase
    {
        private By campoNome = By.Id("first-name");
        private By campoSobrenome = By.Id("last-name");
        private By campoCep = By.Id("postal-code");
        private By botaoContinuar = By.Id("continue");
        private By botaoFinalizar = By.Id("finish");

        public CheckoutPage(IWebDriver driver) : base(driver) { }

        public void PreencherNome(string nome)
        {
            WaitForElementToBeVisible(campoNome, 10);
            driver.FindElement(campoNome).SendKeys(nome);
        }

        public void PreencherSobrenome(string sobrenome)
        {
            WaitForElementToBeVisible(campoSobrenome, 10);
            driver.FindElement(campoSobrenome).SendKeys(sobrenome);
        }

        public void PreencherCep(string cep)
        {
            WaitForElementToBeVisible(campoCep, 10);
            driver.FindElement(campoCep).SendKeys(cep);
        }

        public void ClicarContinuar()
        {
            WaitForElementToBeClickable(botaoContinuar, 10);
            driver.FindElement(botaoContinuar).Click();
        }

        public void ClicarFinalizar()
        {
            WaitForElementToBeClickable(botaoFinalizar, 10);
            driver.FindElement(botaoFinalizar).Click();
        }
    }
}
