//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
//using System;
//using System.Threading;
//using WebDriverManager;
//using WebDriverManager.DriverConfigs.Impl;

//namespace SauceDemoAutomation.Tests
//{
//    public class SauceDemoLoginTest
//    {
//        private IWebDriver driver;
//        private WebDriverWait wait;
//        private IJavaScriptExecutor jsExecutor;

//        [SetUp]
//        public void Setup()
//        {
//            new DriverManager().SetUpDriver(new ChromeConfig());
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            jsExecutor = (IJavaScriptExecutor)driver;
//            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        }

//        private void TypeTextSlowly(IWebElement element, string text, int delay = 500)
//        {
//            foreach (char c in text)
//            {
//                element.SendKeys(c.ToString());
//                Thread.Sleep(delay);
//            }
//        }

//        private void ScrollToElement(By locator)
//        {
//            var element = wait.Until(ExpectedConditions.ElementExists(locator));
//            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
//            Thread.Sleep(500);
//        }

//        private IWebElement GetElementWithWait(By locator, int timeInSeconds = 10)
//        {
//            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
//        }

//        [Test]
//        public void LoginAndAddProducts()
//        {
//            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

//            // Login
//            var userField = GetElementWithWait(By.Id("user-name"));
//            TypeTextSlowly(userField, "standard_user");

//            var passwordField = GetElementWithWait(By.Id("password"));
//            TypeTextSlowly(passwordField, "secret_sauce");

//            var loginButton = GetElementWithWait(By.ClassName("submit-button"));
//            loginButton.Click();
//            wait.Until(d => d.Url.Contains("inventory.html"));

//            bool isLoggedIn = driver.Url.Contains("inventory.html");
//            Assert.That(isLoggedIn, Is.True, "Erro: O login falhou!");

//            // Selecionar Sauce Labs Backpack
//            Thread.Sleep(1000);
//            ClickElementWithWait(By.ClassName("inventory_item_name"));
//            wait.Until(d => d.Url.Contains("inventory-item.html"));

//            // Adicionar ao carrinho
//            Thread.Sleep(1000);
//            ClickElementWithWait(By.Id("add-to-cart"));

//            // Voltar para lista de produtos
//            Thread.Sleep(1000);
//            ClickElementWithWait(By.Id("back-to-products"));
//            wait.Until(d => d.Url.Contains("inventory.html"));

//            // Selecionar Sauce Labs Fleece Jacket
//            ScrollToElement(By.XPath("//div[text()='Sauce Labs Fleece Jacket']"));
//            ClickElementWithWait(By.XPath("//div[text()='Sauce Labs Fleece Jacket']"));
//            wait.Until(d => d.Url.Contains("inventory-item.html"));

//            ClickElementWithWait(By.Id("add-to-cart"));

//            ClickElementWithWait(By.Id("back-to-products"));
//            wait.Until(d => d.Url.Contains("inventory.html"));

//            // Selecionar Test.allTheThings() T-Shirt (Red)
//            ScrollToElement(By.XPath("//div[text()='Test.allTheThings() T-Shirt (Red)']"));
//            ClickElementWithWait(By.XPath("//div[text()='Test.allTheThings() T-Shirt (Red)']"));
//            wait.Until(d => d.Url.Contains("inventory-item.html"));

//            ClickElementWithWait(By.Id("add-to-cart"));

//            ClickElementWithWait(By.Id("back-to-products"));
//            wait.Until(d => d.Url.Contains("inventory.html"));

//            // Ir para o carrinho
//            Thread.Sleep(2000);
//            ClickElementWithWait(By.ClassName("shopping_cart_badge"));
//            wait.Until(d => d.Url.Contains("cart.html"));

//            bool isOnCartPage = driver.Url.Contains("cart.html");
//            Assert.That(isOnCartPage, Is.True, "Erro: Não foi possível acessar a página do carrinho!");
//        }

//        private void ClickElementWithWait(By locator)
//        {
//            int attempts = 0;
//            while (attempts < 3)
//            {
//                try
//                {
//                    var element = GetElementWithWait(locator);
//                    element.Click();
//                    return;
//                }
//                catch (StaleElementReferenceException)
//                {
//                    Console.WriteLine($"Tentativa {attempts + 1}: Elemento {locator} ficou inválido. Reencontrando...");
//                }
//                attempts++;
//            }
//            throw new Exception($"Erro ao clicar no elemento {locator} após várias tentativas.");
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            if (driver != null)
//            {
//                driver.Quit();
//                driver.Dispose();
//            }
//        }
//    }
//}
