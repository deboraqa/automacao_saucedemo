using OpenQA.Selenium;
using automacao_saucedemo.Pages;
using automacao_saucedemo.Bases;

namespace automacao_saucedemo.Flows
{
    public class CheckoutFlow : TestBase
    {
        private CartPage cartPage;
        private CheckoutPage checkoutPage;

        public CheckoutFlow(IWebDriver driver) : base(driver)
        {
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
        }

        public void RealizarCheckout(string primeiroNome, string sobrenome, string cep)
        {
            WaitForElementToBeClickable(By.ClassName("shopping_cart_link"), 10);
            cartPage.ClicarCarrinho();

            WaitForURLToContain("cart.html", 10);
            cartPage.ClicarCheckout();

            WaitForURLToContain("checkout-step-one.html", 10);
            checkoutPage.PreencherNome(primeiroNome);
            checkoutPage.PreencherSobrenome(sobrenome);
            checkoutPage.PreencherCep(cep);
            checkoutPage.ClicarContinuar();

            WaitForURLToContain("checkout-step-two.html", 10);
            checkoutPage.ClicarFinalizar();

            WaitForURLToContain("checkout-complete.html", 10);
        }
    }
}
