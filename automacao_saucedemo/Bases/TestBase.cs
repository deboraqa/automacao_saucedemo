using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace automacao_saucedemo.Bases
{
    /// <summary>
    /// Classe base para testes automatizados, responsável por gerenciar o WebDriver e métodos auxiliares.
    /// </summary>
    public class TestBase
    {
        protected IWebDriver driver;

        /// <summary>
        /// Construtor da classe base. Inicializa o WebDriver.
        /// </summary>
        // Construtor padrão para inicializar o WebDriver automaticamente
        public TestBase()
        {
            driver = WebDriverFactory.GetDriver();
        }

        /// <summary>
        /// Aguarda um elemento estar visível antes de interagir com ele.
        /// </summary>

        // Construtor que aceita um driver existente
        public TestBase(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver), "O driver não pode ser null.");
        }

        /// <summary>
        /// Aguarda um elemento estar clicável antes de interagir com ele.
        /// </summary>
        
        protected void WaitForElementToBeVisible(By locator, int timeout = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Aguarda o carregamento completo da página.
        /// </summary>
        
        protected void WaitForElementToBeClickable(By locator, int timeout = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        /// <summary>
        /// Aguarda até que a URL contenha um determinado texto.
        /// </summary>
        
        protected void WaitForPageToLoad(int timeout = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected void WaitForURLToContain(string expectedText, int timeout = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => d.Url.Contains(expectedText));
        }

        /// <summary>
        /// Fecha o WebDriver após a execução de todos os testes.
        /// </summary>
        
        public void CloseDriver()
        {
            WebDriverFactory.CloseDriver();
        }
    }
}
