using NUnit.Framework;
using automacao_saucedemo.Bases;
using automacao_saucedemo.Flows;
using OpenQA.Selenium;

namespace automacao_saucedemo.Tests
{
    [TestFixture]
    public class SauceDemoCheckoutTest : TestBase
    {
        private LoginFlow loginFlow;
        private CheckoutFlow checkoutFlow;

        [SetUp]
        public void Inicializar()
        {
            loginFlow = new LoginFlow(driver);
            checkoutFlow = new CheckoutFlow(driver);
        }


        [Test]
        public void FinalizarCompraComSucesso()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WaitForPageToLoad(30); //  Aguardando a página carregar completamente

            loginFlow.RealizarLogin("standard_user", "secret_sauce");

            WaitForURLToContain("inventory.html", 30); //  Espera até a URL mudar para a página do inventário

            checkoutFlow.RealizarCheckout("Débora", "Silva", "30170-040");

            WaitForURLToContain("checkout-complete.html", 30); //  Espera até a URL mudar para checkout completo

            Assert.That(driver.Url.Contains("checkout-complete.html"), Is.True, "Erro ao concluir a compra!");
        }

        [OneTimeTearDown]
        public void FinalizarTestes()
        {
            CloseDriver(); //  Fecha o navegador APENAS após todos os testes finalizarem
        }
    }
}
