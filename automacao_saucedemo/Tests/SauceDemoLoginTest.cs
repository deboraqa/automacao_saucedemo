using NUnit.Framework;
using automacao_saucedemo.Bases;
using automacao_saucedemo.Flows;
using automacao_saucedemo.Pages;
using OpenQA.Selenium;

namespace automacao_saucedemo.Tests
{
    /// <summary>
    /// Classe de testes para o fluxo de login do SauceDemo.
    /// </summary>
    
    [TestFixture]
    public class SauceDemoLoginTest : TestBase
    {
        private LoginFlow loginFlow;
        private LoginPage loginPage;

        /// <summary>
        /// Configuração inicial antes de cada teste.
        /// </summary>

        [SetUp]
        public void Inicializar()
        {
            loginFlow = new LoginFlow(driver);
            loginPage = new LoginPage(driver);
        }

        /// <summary>
        /// Teste de login bem-sucedido com credenciais válidas.
        /// </summary>
        [Test]
        public void LoginComCredenciaisValidas()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WaitForPageToLoad(30); //  Espera a página carregar completamente

            loginFlow.RealizarLogin("standard_user", "secret_sauce");

            WaitForURLToContain("inventory.html", 30); //  Espera até a URL mudar para a página do inventário

            Assert.That(driver.Url.Contains("inventory.html"), Is.True, "Erro ao realizar login!");
        }

        /// <summary>
        /// Teste de login com usuário inválido.
        /// </summary>
        /// 
        [Test]
        public void LoginComUsuarioInvalido()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WaitForPageToLoad(30);
            loginFlow.RealizarLogin("usuario_invalido", "secret_sauce");

            WaitForElementToBeVisible(loginPage.ObterMensagemDeErroElemento(), 30); //  Espera a mensagem de erro aparecer

            Assert.That(loginPage.ObterMensagemDeErro(), Is.EqualTo("Epic sadface: Username and password do not match any user in this service"), "Usuário inválido.");
        }

        [Test]
        public void LoginComSenhaInvalida()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WaitForPageToLoad(30);
            loginFlow.RealizarLogin("standard_user", "senha_errada");

            WaitForElementToBeVisible(loginPage.ObterMensagemDeErroElemento(), 30);

            Assert.That(loginPage.ObterMensagemDeErro(), Is.EqualTo("Epic sadface: Username and password do not match any user in this service"), "Senha incorreta.");
        }

        /// <summary>
        /// Teste de login com senha inválida.
        /// </summary>

        [Test]
        public void LoginComUsuarioESenhaInvalidos()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WaitForPageToLoad(30);
            loginFlow.RealizarLogin("usuario_invalido", "senha_errada");

            WaitForElementToBeVisible(loginPage.ObterMensagemDeErroElemento(), 30);

            Assert.That(loginPage.ObterMensagemDeErro(), Is.EqualTo("Epic sadface: Username and password do not match any user in this service"), "Usuário e senha incorretos.");
        }

        [Test]
        public void LoginComCamposVazios()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WaitForPageToLoad(30);
            loginFlow.RealizarLogin("", "");

            WaitForElementToBeVisible(loginPage.ObterMensagemDeErroElemento(), 30);

            Assert.That(loginPage.ObterMensagemDeErro(), Is.EqualTo("Epic sadface: Username is required"), "Campos vazios.");
        }
        /// <summary>
        /// Finaliza os testes fechando o navegador após todos serem concluídos.
        /// </summary>

        [OneTimeTearDown]
        public void FinalizarTestes()
        {
            CloseDriver(); //  Fecha o navegador APENAS após todos os testes finalizarem
        }
    }
}
