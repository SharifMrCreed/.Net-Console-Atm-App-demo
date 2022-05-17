using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    class User
    {
        public string name { get; set; }
        public string dob { get; set; }
        public string sex { get; set; }
        public string occupation { get; set; }
        public string residence { get; set; }
        public Account account { get; set; }

        public bool isEmpty()
        {
            return string.IsNullOrEmpty(name)
            && string.IsNullOrEmpty(dob)
            && string.IsNullOrEmpty(sex)
            && string.IsNullOrEmpty(occupation)
            && string.IsNullOrEmpty(residence);
        }

        public string getUserInfo()
        {
            return $"Name: {name}\n" +
                $"Date of birth: {dob}\n" +
                $"Sex: {sex}\n" +
                $"Occupation: {occupation}\n" +
                $"Residence: {residence} \n" +
                $"Account type: {account.accountType}";
        }
    }

    enum AccountType
    {
        SAVINGS_ACCOUNT = 1,
        CURRENT_ACCOUNT = 2,
        STUDENT_ACCOUNT = 4,
        JOINT_ACCOUNT = 5,
        FIXED_DEPOSIT_ACCOUNT = 3
    }

    class Account
    {
        public AccountType accountType { get; set; }
        public int accountBalance { get; set; }
        public string recentTransaction { get; set; }
        public string miniStatement { get; set; }
        public bool isCreated = false;

        public string getAccountBenefits()
        {
            switch (accountType)
            {
                case AccountType.SAVINGS_ACCOUNT: return savingAccountBenefits;
                case AccountType.CURRENT_ACCOUNT: return currentAccountBenefits;
                case AccountType.FIXED_DEPOSIT_ACCOUNT: return fixedDepositAccountBenefits;
                case AccountType.JOINT_ACCOUNT: return jointAccountBenefits;
                default: return studentAccountBenefits;
            }
        }

        private const string currentAccountBenefits = "->More transactions Allowed\t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Requires a higher minimum balance\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Facilitates frequent transactions – transfer   ||\n" +
            "||\t\t\t\t\t\t   funds, receive cheques, cash, etc.\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Can be operated by individuals, proprietary    ||\n" +
            "||\t\t\t\t\t\t   concerns, public and private companies, \t  ||\n" +
            "||\t\t\t\t\t\t   associations, trusts, etc.\t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->No restriction on the number of transactions   ||\n" +
            "||\t\t\t\t\t\t   in a day\t\t\t\t\t  || \n" +
            "||\t\t\t\t\t\t ->Non-maintenance of the minimum balance can\t  ||\n" +
            "||\t\t\t\t\t\t   attract penalty charges \t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->For a single business, there cannot be multiple||\n" +
            "||\t\t\t\t\t\t   current accounts \t\t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Charge interests on short-term funds the\t  ||\n" +
            "||\t\t\t\t\t\t   account holder has borrowed from the bank \t  ||";
        private const string savingAccountBenefits = "->Savings accounts earn interest.\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Savings accounts are easy to open and access.  ||\n" +
            "||\t\t\t\t\t\t ->Your bank may have limits on savings account\t  ||\n" +
            " \t\t\t\t\t\t  transactions.\t\t\t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Savings accounts are a secure way to save.\t  ||\n" +
            "||\t\t\t\t\t\t ->Some banks charge fees on their savings \t  ||\n" +
            " \t\t\t\t\t\t  accounts.\t\t\t\t\t  ||";
        private const string studentAccountBenefits = "Interest Free Overdraft Facilities. \t\t  ||\n" +
            "||\t\t\t\t\t\t ->Freebies and Perks\t\t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Financial Advice.\t\t\t\t  ||";
        private const string jointAccountBenefits = "->Ease of bill payments\t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Simpler legal process.\t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Transparent expenses with your partner\t  ||";
        private const string fixedDepositAccountBenefits = "->Provides a higher interest rate.\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Guaranteed returns.\t\t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Flexibility: You can open up with different \t  ||\n" +
            "||\t\t\t\t\t\t   banks offering different terms.\t\t  ||\n" +
            "||\t\t\t\t\t\t ->Earn interest regularly - monthly, quarterly or||\n" +
            "||\t\t\t\t\t\t   yearly\t\t\t\t\t  ||\n" +
            "||\t\t\t\t\t\t ->High liquidity: You can terminate the money to ||\n" +
            "||\t\t\t\t\t\t   fund your short - term liquidity needs.\t  ||\n" +
            "||\t\t\t\t\t\t ->Encourages a good saving habit.\t\t  ||";

        public string getAccountInfo()
        {
            return $"\nAccount Type: {accountType.ToString()}\n" +
                $"Account Balance: {accountBalance}\n" +
                $"Recent Transaction: {(string.IsNullOrEmpty(recentTransaction) ? "No recent transactions" : recentTransaction)}\n" +
                $"Mini Statement: {(string.IsNullOrEmpty(miniStatement) ? "No recent transactions" : miniStatement)}\n" +
                $"Account Benefits: {getAccountBenefits()}";
        }
    }

    class Bank
    {
        private Account account;
        private User user;
        private static String bankName = "NATIONAL BANK KAMPALA";
        private static int pin = 1234;

        public Bank(Account account, User user)
        {
            this.account = account;
            this.user = user;
        }
        public void welcomeUser()
        {
            print("  ================================================================================================");
            print("||                                                                                                ||");
            print($"||                              WELCOME TO {bankName}                                  ||");
            print("||                                                                                                ||");
            print("  ================================================================================================");
            print("\n\n\t\t\t\tPlease enter your pin to proceed:\t\t\t\t\t  \n\n");
            Console.Write($"\t\t\t\t\t\t");
            authenticate();

            showLoadingDialog();
        }

        private void authenticate()
        {
            int pin2 = 0;
            try
            {
                pin2 = int.Parse(read());
                Load("load", 250);
            }
            catch (Exception)
            {
                int retries = 3;
                do
                {
                    print("The pin contains only numbers. \nPlease enter the pin");
                    try
                    {
                        if (retries > 0)
                        {
                            print($"Retries Left: {retries}\n");
                            print("Please enter the correct pin to proceed:\n");
                            pin2 = int.Parse(read());
                            retries--;

                        }
                        else
                        {
                            showFraudMessage();
                            return;
                        }
                        Load("Load", 250);
                    }
                    catch (Exception)
                    {

                    }
                } while (pin2 == 0);
            }
            if (pin2 != pin)
            {
                int retries = 3;
                do
                {
                    print("\nIncorrect Pin\n");
                    if (retries > 0)
                    {
                        print($"Retries Left: {retries}\n");
                        print("Please enter the correct pin to proceed:\n");
                        pin2 = int.Parse(read());
                        retries--;

                    }
                    else
                    {
                        showFraudMessage();
                        return;
                    }
                    Load("Load", 250);
                } while (pin2 != pin);
            }
        }

        private void showFraudMessage()
        {
            print("Fraudulent Activities detected...");
            System.Threading.Thread.Sleep(3000);
            for (int i = 3; i > 0; i--)
            {
                print($"program ending in: {i}");
                System.Threading.Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }

        private void printHeader()
        {

            print("  ================================================================================================");
            print("||                                                                                                ||");
            print($"||                             \t     {bankName}  \t                                  ||");
            print("||                                                                                                ||");
            print("  ================================================================================================");
        }

        private void printFooter()
        {
            print("||                                                                                                ||");
            print("||                                                                                                ||");
            print("  ================================================================================================");
        }

        public void showMainMenu()
        {
            printHeader();
            print("||                                                                                                ||");
            print($"||                             \t         MAIN MENU  \t\t                                  ||");
            print("||                                                                                                ||");
            print("||\tPlease select a number corresponding to an option\t\t\t\t\t  ||");
            print("||                                                                                                ||");
            print("||\t\t1.\t Account Details\t\t\t\t\t\t\t  ||");
            print("||\t\t2.\t Account Holders Details\t\t\t\t\t\t  ||");
            print("||\t\t3.\t Make Deposit\t\t\t\t\t\t\t\t  ||");
            print("||\t\t4.\t Withdraw\t\t\t\t\t\t\t\t  ||");
            print("||\t\t5.\t Balance Inquiry\t\t\t\t\t\t\t  ||");
            print("||\t\t6.\t Latest Transaction\t\t\t\t\t\t\t  ||");
            print("||\t\t7.\t Mini Statement\t\t\t\t\t\t\t\t  ||");
            print("||\t\t8.\t Change Pin\t\t\t\t\t\t\t\t  ||");
            print("||\t\t9.\t Create New Account\t\t\t\t\t\t\t  ||");
            printFooter();

        }

        public bool isValidSelection(string selection, int upper)
        {
            int s = 0;
            if (string.IsNullOrEmpty(selection))
            {
                print("\nYou did not select an option......");
                return false;
            }

            if (selection.ToLower().Equals("q"))
            {
                return true;
            }
            try
            {
                s = int.Parse(selection);
                if (s < 0 && s > upper)
                {
                    print("The selection must be the number coresponding to one option in the menu");
                    return false;
                }

            }
            catch (Exception)
            {
                print("The selection was invalid");
                print("The selection must a number coresponding to one option in the main");
                return false;

            }

            return true;

        }
        public bool isValidAmount(string selection, int upperAmount)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int s = 0;
            if (string.IsNullOrEmpty(selection))
            {
                print("\nYou did not enter any amount......");
                Console.ResetColor();
                return false;
            }
            try
            {
                s = int.Parse(selection);
                if (s <= 0)
                {
                    print("\n\t\t\t\tThe amount must be greater than 0");
                    Console.ResetColor();
                    return false;
                }

                if (s > upperAmount)
                {
                    print("\n\t\t    The amount you entered is above your current account balance");
                    Console.ResetColor();
                    return false;
                }

            }
            catch (Exception)
            {
                print("\n\t\t\t\t    The amount was invalid");
                print("\n\t\t\t\tThe amount must be greater than 0");
                Console.ResetColor();
                return false;

            }
            Console.ResetColor();

            return true;

        }

        public void handleSeletion(string selection)
        {
            switch (selection)
            {
                case "1":
                    showAccountDetail();
                    break;
                case "2":
                    showUserInfo();
                    break;
                case "3":
                    makeDeposit();
                    break;
                case "4":
                    withdraw();
                    break;
                case "5":
                    checkBalance();
                    break;
                case "6":
                    checkLatestTrasaction();
                    break;
                case "7":
                    showMiniStatement();
                    break;
                case "8":
                    changePin();
                    break;
                case "9":
                    startCreationProcess();
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private void changePin()
        {
            Console.Clear();
            if (!account.isCreated)
            {
                print("\n\n\t\t\t\t\t    No Account Found.");
                print("\n\t\t\t\t\tStarting Account creation Process.");
                Load("start", 400);
                startCreationProcess();
            }
            else
            {
                printHeader();
                print("\n\n\t\t\t\tPlease enter your pin to proceed:\t\t\t\t\t  \n\n");
                Console.Write($"\t\t\t\t\t\t");
                authenticate();
                deleteLines(10);
                promptForNewPins();
            }
        }

        private void promptForNewPins()
        {
            print("\n\t\t\t\t\tEnter your new pin \t\t\t\t\t");
            Console.Write($"\t\t\t\t\t\t");
            int p = 0;
            try
            {
                p = int.Parse(read());
            }
            catch (Exception)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    print("\t\t\t\tThe pin must only contain numbers.\n");
                    Console.ResetColor();
                    try
                    {

                        print("\n\n\t\t\t\tPlease enter a valid pin to proceed:\n");
                        Console.Write($"\t\t\t\t\t\t");
                        p = int.Parse(read());

                    }
                    catch (Exception)
                    {

                    }
                } while (p == 0);
            }
            print("\n\n\t\t\t\t    Please re-enter your new pin\t\t\t\t\t \n");
            Console.Write($"\t\t\t\t\t\t");
            int p1 = 0;
            try
            {
                p1 = int.Parse(read());
            }
            catch (Exception)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    print("\t\t\t\tThe pin must only contain numbers.");
                    Console.ResetColor();
                    try
                    {

                        print("\n\n\t\t\t\tPlease enter a valid pin to proceed:\n");
                        Console.Write($"\t\t\t\t\t\t");
                        p1 = int.Parse(read());

                    }
                    catch (Exception)
                    {

                    }
                } while (p1 == 0);
                
            }

            while (p1 != p)
            {
                Console.Clear();
                printHeader();
                Console.ForegroundColor = ConsoleColor.Red;
                print("\t\t\t\t\tThe pins did not match");
                Console.ResetColor();
                promptForNewPins();
            }
            pin = p;

            Load("Chang", 250);
            Console.ForegroundColor = ConsoleColor.Red;
            print("\n\t\t\t\t    Pin Updated successfully");
            Console.ResetColor();
            print("\n\t\t    Press any key to return to main menu or q to quit");
            Console.Write($"\t\t\t\t   ");


        }

        private void checkLatestTrasaction()
        {
            if (!account.isCreated)
            {
                print("\n\n\t\t\t\t\t    No Account Found.");
                print("\n\t\t\t\t\tStarting Account creation Process.");
                Load("start", 400);
                startCreationProcess();
            }
            else
            {

                print("\n\n  ================================================================================================");
                print("||                                                                                                ||");
                print($"||            \t\tThe latest transaction is: {account.recentTransaction}  \t\t                  ||");
                print("||                                                                                                ||");
                print("  ================================================================================================");
                print("\n\t\t    Press any key to return to main menu or q to quit");
                Console.Write($"\t\t\t\t   ");
            }
        }
        private void showMiniStatement()
        {
            Console.Clear();
            if (!account.isCreated)
            {
                print("\n\n\t\t\t\t\t    No Account Found.");
                print("\n\t\t\t\t\tStarting Account creation Process.");
                Load("start", 400);
                startCreationProcess();
            }
            else
            {
                printHeader();
                print("||                                                                                                ||");
                print($"||            \t\t\t\tMini Statement:  \t\t\t                  ||");
                print("||                                                                                                ||");
                print($"||            \t\t\t{account.miniStatement}\t");
                print("||                                                                                                ||");
                print("  ================================================================================================");
                print("\n\t\t    Press any key to return to main menu or q to quit");
                Console.Write($"\t\t\t\t   ");
            }
        }

        private void checkBalance()
        {
            if (!account.isCreated)
            {

                print("\n\n\t\t\t\t\t    No Account Found.");
                print("\n\t\t\t\t\tStarting Account creation Process.");
                Load("start", 400);
                startCreationProcess();
            }
            else
            {
                print("\n\n  ================================================================================================");
                print("||                                                                                                ||");
                print($"||                \tAccount Balance: {account.accountBalance}  \t\t\t                          ||");
                print("||                                                                                                ||");
                print("  ================================================================================================");
                print("\n\t\t\tPress any key to return to main menu or q to quit");
                Console.Write($"\n\t\t\t\t   ");

            }

        }

        private void withdraw()
        {
            Console.Clear();
            printHeader();
            if (!account.isCreated)
            {
                print("\n\n\t\t\t\t\t    No Account Found.");
                print("\n\t\t\t\t\tStarting Account creation Process.");
                Load("start", 400);
                startCreationProcess();
            }
            else if (account.accountBalance <= 0)
            {

                print($"\n\n\t\t\t\t\tAccount Balance: {account.accountBalance}");

                Console.ForegroundColor = ConsoleColor.Red;
                print("\n\n\t\t\t\t  your account balance is too low");
                print("\n\t\t\t\t    You cant make any withdrawals");
                Console.ResetColor();
                print("\n\n\t\t\t  Press any key to return to main menu or q to quit");
                Console.Write($"\n\t\t\t\t\t\t   ");
            }
            else
            {
                print($"\n\n\t\t\t\t\tAccount Balance: {account.accountBalance}");
                print("\n\t\t\t    Enter the amount you would like to withdraw");
                Console.Write($"\n\t\t\t\t\t\t");
                string selection = read();
                while (!isValidAmount(selection, account.accountBalance))
                {
                    print("\n\t\t\t\t  Please Enter the correct amount");
                    Console.Write($"\n\t\t\t\t\t\t");
                    selection = read();
                }
                account.accountBalance -= int.Parse(selection);
                account.recentTransaction = $"Withdraw of {selection}";
                account.miniStatement += $"\n||\t\t\t\t\t\t Withdraw of {selection}\t\t\t\t  ||";
                Load("Withdraw", 400);
                Console.ForegroundColor = ConsoleColor.Green;
                print($"\n\t\t\t\t\t    {selection} Withdrawn\n\n");
                Console.ResetColor();
                print("\n\n\t\t\t    Press any key to return to main menu or q to quit");
                Console.Write($"\n\t\t\t\t\t\t   ");


            }

        }

        private void makeDeposit()
        {
            Console.Clear();
            printHeader();
            if (!account.isCreated)
            {

                print("\n\n\t\t\t\t\t    No Account Found.");
                print("\n\t\t\t\t\tStarting Account creation Process.");
                Load("start", 400);
                startCreationProcess();
            }
            else
            {
                print("\n\n\t\t\t\t    Enter the amount you wish to deposit:\t\t\t");
                Console.Write($"\n\t\t\t\t\t\t   ");
                string selection = read();
                while (!isValidAmount(selection, 500000000))
                {
                    selection = read();
                }
                account.accountBalance += int.Parse(selection);
                account.recentTransaction = $"Deposit of {selection}";
                account.miniStatement += $"\n||\t\t\t\t\t\t Deposit of {selection}\t\t\t\t  ||";
                Load("Deposit", 500);
                Console.ForegroundColor = ConsoleColor.Green;
                print("\n\t\t\t\t\t\tDEPOSITED\n\n");
                Console.ResetColor();
                print("\t\t\t    Press any key to return to main menu or q to quit");
                Console.Write($"\n\t\t\t\t\t\t   ");

            }
        }

        private void showUserInfo()
        {
            Console.Clear();
            printHeader();
            if (!account.isCreated)
            {

                print("\n\n\t\t\t\t\t    No User data Found.");
                print("\n\t\t\t\t\tStarting Registration Process.");
                Load("start", 400);
                startCreationProcess();
            }
            else
            {
                print("||                                                                                                ||");
                print("||\t\t\t\t    CUSTOMER INFORMATION\t\t\t\t\t  ||");
                print("||                                                                                                ||");

                print($"||\t\t\tName: \t\t {user.name}\t\t\t\t\t  ||");
                print($"||\t\t\tDate of birth:\t {user.dob}\t\t\t\t\t\t  ||");
                print($"||\t\t\tSex:\t\t {user.sex}\t\t\t\t\t\t\t  ||");
                print($"||\t\t\tOccupation: \t {user.occupation}\t\t\t\t\t\t  ||");
                print($"||\t\t\tResidence: \t {user.residence}\t\t\t\t\t\t\t  ||");
                print($"||\t\t\tAccount Type: \t {account.accountType}\t\t\t\t\t  ||");
                printFooter();
                print("\t\t\t    Press any key to return to main menu or q to quit");
                Console.Write($"\n\t\t\t\t\t\t   ");

            }
        }

        private void showAccountDetail()
        {
            Console.Clear();
            printHeader();
            if (!account.isCreated)
            {
                print("\n\n\t\t\t\t\t    No Account Found.");
                print("\n\t\t\t\t\tStarting Creation Process.");
                Load("start", 400);
                startCreationProcess();
            }
            else
            {
                print("||                                                                                                ||");
                print("||\t\t\t\tACCOUNT INFORMATION\t\t\t\t\t\t  ||");
                print("||                                                                                                ||");

                print($"||\t\t\tAccount Type: \t\t {account.accountType}\t\t\t\t  ");
                print($"||\t\t\tAccount Balance:\t {account.accountBalance}\t\t\t\t\t\t  ||");
                print($"||\t\t\tRecent Transaction: \t {(string.IsNullOrEmpty(account.recentTransaction) ? "No recent transactions" : account.recentTransaction)}\t\t\t\t  ||");
                print($"||\t\t\tMini Statement: \t {(string.IsNullOrEmpty(account.miniStatement) ? "No recent transactions" : account.miniStatement)}");
                print("||                                                                                                ||");
                print($"||\t\t\tAccount Benefits: \t {account.getAccountBenefits()}");
                printFooter();
                print("\t\t\t    Press any key to return to main menu or q to quit");
                Console.Write($"\n\t\t\t\t\t\t   ");

            }
        }

        private void startCreationProcess()
        {
            Console.Clear();
            printHeader();

            print($"\n\n\t\t\t\t\tCUSTOMER DETAILS\n\n");
            print("\t\t\t\tEnter Your Full Names");
            Console.Write($"\t\t\t\t\t");
            string name = read();
            while (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                print("\t\t\t\t\tName cant be empty.\n");
                Console.ResetColor();
                print("\t\t\t\tPlease Enter your Full names");
                Console.Write($"\t\t\t\t\t");
                name = read();
            }
            user.name = name;

            print("\n\n\t\t\t\tEnter Your Date of Birth: (dd/mm/yyyy)");
            Console.Write($"\t\t\t\t\t");
            string dob = read();
            while (string.IsNullOrEmpty(dob))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                print("\t\t\t\tDate of birth cant be empty.\n");
                Console.ResetColor();
                print("\n\t\t\t\tPlease Enter your date of birth");
                Console.Write($"\t\t\t\t\t");
                dob = read();
            }
            user.dob = dob;

            print("\n\n\t\t\t\tEnter your sex: (Male/Female)");
            Console.Write($"\t\t\t\t\t");
            string sex = read();
            while (string.IsNullOrEmpty(sex) && (!sex.ToLower().Equals("male") || sex.ToLower().Equals("female")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                print($"\t\t\t\t{sex} is not a valid entry");
                Console.ResetColor();
                print("\t\t\t\tPlease type male or female");
                Console.Write($"\t\t\t\t\t");
                sex = read();
            }

            print("\n\n\t\t\t\tEnter your occupation");
            Console.Write($"\t\t\t\t\t");
            string occupation = read();
            while (string.IsNullOrEmpty(occupation))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                print($"\t\t\t\tOccupation cant be empty.");
                Console.ResetColor();
                print("\t\t\t\tPlease enter your occupation");
                Console.Write($"\t\t\t\t\t");
                occupation = read();
            }
            user.occupation = occupation;

            print("\n\n\t\t\t\tPlease enter your Residence");
            Console.Write($"\t\t\t\t\t");
            string residence = read();
            while (string.IsNullOrEmpty(residence))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                print($"\t\t\t\tResidence cant be empty.");
                Console.ResetColor();
                print("\t\t\t\tPlease enter your Residence");
                Console.Write($"\t\t\t\t\t");
                occupation = read();
            }
            user.residence = residence;

            Load("Sav", 500);
            Console.Clear();
            printHeader();

            displayAccountTypesMenu();
            Console.Write($"\t\t\t\t\t\t");
            string selection = read();
            while (!isValidSelection(selection, 6))
            {
                Console.Clear();
                printHeader();
                displayAccountTypesMenu();
                Console.Write($"\t\t\t\t\t\t");
                selection = read();
            }
            int s = int.Parse(selection);

            switch (s)
            {
                case 1:
                    account.accountType = AccountType.SAVINGS_ACCOUNT;
                    break;
                case 2:
                    account.accountType = AccountType.CURRENT_ACCOUNT;
                    break;
                case 3:
                    account.accountType = AccountType.FIXED_DEPOSIT_ACCOUNT;
                    break;
                case 4:
                    account.accountType = AccountType.STUDENT_ACCOUNT;
                    break;
                case 5:
                    account.accountType = AccountType.JOINT_ACCOUNT;
                    break;

            }
            account.isCreated = true;
            user.account = account;
            Load("sav", 500);
            Console.ForegroundColor = ConsoleColor.Green;
            print("\n\t\t\t\t\t\tSAVED\n\n");
            Console.ResetColor();
            print("\t\t\t    Press any key to return to main menu or q to quit");
            Console.Write($"\n\t\t\t\t\t\t   ");



        }

        private void displayAccountTypesMenu()
        {
            print("||                                                                                                ||");
            print("||    Please select a number corresponding to an Account type to choose it as your account\t  ||");
            print("||                                                                                                ||");

            print("||\t\t1.\t Savings Account\t\t\t\t\t\t\t  ||");
            print("||\t\t2.\t Current Account\t\t\t\t\t\t\t  ||");
            print("||\t\t3.\t Fixed Deposit Account\t\t\t\t\t\t\t  ||");
            print("||\t\t4.\t Student Account\t\t\t\t\t\t\t  ||");
            print("||\t\t5.\t Joint Account\t\t\t\t\t\t\t\t  ||");
            printFooter();


        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public void deleteLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
        }

        private void showLoadingDialog()
        {
            deleteLines(3);
            print("\n\t\t\t\t\t    Authenticating\n");
            Console.Write("\t\t\t\t   ");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("|");
                System.Threading.Thread.Sleep(150);
            }

            deleteLines(3);
            print("\n\t\t\t\t\t    Validating\n");
            Console.Write("\t\t\t\t   ");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("|");
                System.Threading.Thread.Sleep(150);
            }
            Console.Write("\n\n\t\t\t\t\tLogin Successfull");
            System.Threading.Thread.Sleep(3000);
        }

        public void Load(string action, int time)
        {
            print($"\n\n\t\t\t\t\t\t{action}ing");
            Console.Write("\t\t\t\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("....");
                System.Threading.Thread.Sleep(time);
            }
            print("\n");
        }

        public void print(String statement)
        {
            Console.WriteLine(statement);
        }
        public static String read()
        {
            return Console.ReadLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            account.accountType = AccountType.CURRENT_ACCOUNT;
            account.isCreated = true;
            account.accountBalance = 50000;
            account.recentTransaction = "Deposit of 50000";
            account.miniStatement = "Deposit of 50000\t\t\t\t  ||";
            User user = new User();
            user.name = "Sharif Ssemujju";
            user.dob = "4\\4\\1998";
            user.sex = "Male";
            user.occupation = "Student";
            user.residence = "Banda";
            user.account = account;
            Bank bank = new Bank(new Account(), new User());
            Console.Write("\t\t\t\t");
            string selection = "";
            bank.welcomeUser();
            do
            {
                Console.Clear();
                bank.showMainMenu();
                Console.Write("\t\t\t\t");
                selection = Bank.read();
                if (bank.isValidSelection(selection, 10))
                {

                    bank.handleSeletion(selection);
                    selection = Bank.read();
                }
                else
                {
                    bank.Load("restart", 300);
                }
            } while (selection != "q");
        }
    }
}
