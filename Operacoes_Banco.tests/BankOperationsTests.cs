using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BankOperationsE2ETests
{
    [TestFixture]
    public class BankOperationsTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Inicializa o ChromeDriver e navega até a URL da aplicação web
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000"); // Altere para a URL correta da sua aplicação
        }

        [Test]
        public void Test_Successful_Deposit()
        {
            // Localiza o campo de valor de depósito e insere o valor
            driver.FindElement(By.Id("depositAmount")).SendKeys("80");
            // Clica no botão de depósito
            driver.FindElement(By.Id("depositButton")).Click();

            // Verifica o saldo após o depósito
            var balanceText = driver.FindElement(By.Id("balance")).Text;
            Assert.AreEqual("180.00", balanceText);
        }

        [Test]
        public void Test_Successful_Withdrawal()
        {
            // Localiza o campo de valor de saque e insere o valor
            driver.FindElement(By.Id("withdrawAmount")).SendKeys("80");
            // Clica no botão de saque
            driver.FindElement(By.Id("withdrawButton")).Click();

            // Verifica o saldo após o saque
            var balanceText = driver.FindElement(By.Id("balance")).Text;
            Assert.AreEqual("20.00", balanceText);
        }

        [Test]
        public void Test_OverLimit_Withdrawal()
        {
            // Teste para verificar saque acima do limite
            driver.FindElement(By.Id("withdrawAmount")).SendKeys("120");
            driver.FindElement(By.Id("withdrawButton")).Click();

            // Verifica a mensagem de erro
            var errorText = driver.FindElement(By.Id("error")).Text;
            Assert.AreEqual("Saldo insuficiente", errorText);
        }

        [Test]
        public void Test_Overtime_Withdrawal()
        {
            // Simula a mudança de horário se a interface permitir
            driver.FindElement(By.Id("setTime")).SendKeys("01:00 AM");
            driver.FindElement(By.Id("withdrawAmount")).SendKeys("50");
            driver.FindElement(By.Id("withdrawButton")).Click();

            // Verifica a mensagem de erro
            var errorText = driver.FindElement(By.Id("error")).Text;
            Assert.AreEqual("Operação não permitida nesse horário", errorText);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit(); // Fecha o navegador
        }
    }
}
