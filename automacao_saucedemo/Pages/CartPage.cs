using OpenQA.Selenium;
using automacao_saucedemo.Bases;

namespace automacao_saucedemo.Pages
{
    public class CartPage : TestBase
    {
        private By carrinho = By.ClassName("shopping_cart_link");
        private By botaoCheckout = By.Id("checkout");

        public CartPage(IWebDriver driver) : base(driver) { }

        public void ClicarCarrinho()
        {
            WaitForElementToBeClickable(carrinho, 10);
            driver.FindElement(carrinho).Click();
        }

        public void ClicarCheckout()
        {
            WaitForElementToBeClickable(botaoCheckout, 10);
            driver.FindElement(botaoCheckout).Click();
        }
    }
}
