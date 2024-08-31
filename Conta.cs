namespace Operacoes_Banco
{
    public class Conta
    {
        private double _balance;

        private int _transactionsLimitHour;

        public Conta(double balance, int transactionsLimitHour)
        {
            _balance = balance;
            _transactionsLimitHour = transactionsLimitHour;
        }

        public void Deposit(double amount)
        {
            BankPolicy(amount);

            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            BankPolicy(amount, true);

            _balance -= amount;
        }

        public double GetBalance()
        {
            return _balance;
        }

        private void BankPolicy(double amount, bool isWithdraw = false)
        {
            if (isWithdraw && amount > _balance)
                throw new Exception("Saldo Insuficiente");

            TimeSpan limiteInicio = new TimeSpan(6, 0, 0); // 06:00
            TimeSpan limiteFim = new TimeSpan(22, 0, 0);   // 22:00

            // Verifica se o horário está dentro dos limites permitidos
            if (_transactionsLimitHour <= limiteInicio.Hours || _transactionsLimitHour >= limiteFim.Hours)
                throw new Exception("Transações de depósito e saque só podem ser realizadas até 22:00H");
        }
    }
}