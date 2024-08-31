using Xunit;

namespace Operacoes_Banco.tests
{
    public class TestBank
    {
        [Fact]
        public void Withdraw_RealizeSuccessfulWithdrawal()
        {
            int timeNow = 12;

            Conta conta = new Conta(100.00, timeNow);

            conta.Withdraw(80.00);

            double balance = conta.GetBalance();

            Assert.Equal(20.00, balance);
        }

        [Fact]
        public void Deposit_RealizeSuccessfulDeposit()
        {
            int timeNow = 12;

            Conta conta = new Conta(100.00, timeNow);

            conta.Deposit(80.00);

            double balance = conta.GetBalance();

            Assert.Equal(180.00, balance);
        }

        [Fact]
        public void Withdraw_RealizeOvertimeWithdrawal()
        {
            int timeNow = 1;

            Conta conta = new Conta(100.00, timeNow);

            Assert.Throws<Exception>(() => conta.Withdraw(80.00));
        }

        [Fact]
        public void Deposit_RealizeOvertimeDeposit()
        {
            int timeNow = 23;

            Conta conta = new Conta(100.00, timeNow);

            Assert.Throws<Exception>(() => conta.Deposit(80.00));
        }

        [Fact]
        public void Withdraw_RealizeLimitAmountWithdrawal()
        {
            int timeNow = 12;

            Conta conta = new Conta(100.00, timeNow);

            Assert.Throws<Exception>(() => conta.Withdraw(120.00));
        }
    }
} 