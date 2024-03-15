internal class Program
{
    private static void Main(string[] args)
    {
        CreditManager creditManager = new CreditManager();
        creditManager.Calculate();
        creditManager.Save();

        Customer customer = new Customer();//instance oluşturmak, instance creation
        customer.Id = 1;    
        customer.City = "Malatya";

        //CustomerManager customerManager = new CustomerManager(customer); 
        //customerManager.Save();
        //customerManager.Delete();

        Company company = new Company();
        company.TaxNumber = "100000";
        company.CompanyName ="Arçelik";
        company.Id = 2;

        //CustomerManager customerManager1 = new CustomerManager(company);
        //Person person = new Person();
        //person.NationalIdentity = "123456";

        CustomerManager customerManager = new CustomerManager(new Customer(), new MilitaryCreditManager());
        customerManager.GiveCredit();

        IntValueTypes();
        ArrayReferenceTypes();

    }
    class CreditManager()
    {
        //kredi ile ilgili operasyonları tutan sınıf 
        public void Calculate()
        {
            Console.WriteLine("Hesaplandı");
        }
        public void Save()
        {
            Console.WriteLine("Kredi Verildi");
        }
    }

    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate();


        public virtual void Save()
        {
            Console.WriteLine("Kaydedildi");
        }
    }
    class TeacherCreditManager :BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine(" Öğretmen Kredisi Hesaplandı");
        }

        public override void Save()
        {
            //
            base.Save();
            //
        }

    }
    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine(" Asker Kredisi Hesaplandı");

        }
    }
    class Customer
    {
        public Customer()
        {
            Console.WriteLine("müşteri nesnesi başlatıldı");
        }
        public int Id { get; set; }

        public string City { get; set; }
    }
    class Company:Customer
    {
        public string CompanyName { get; set; }

        public string TaxNumber { get; set; }
    }
    class Person : Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

    }
    class CustomerManager
    {
        private Customer _customer;
        private ICreditManager _creditManager;

        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;
            _creditManager = creditManager;
        }
        public void Save()
        {
            Console.WriteLine(" müşteri kaydedildi");
        }
        public void Delete()
        {
            Console.WriteLine( "  müşteri silindi");

        }
        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi Verildi");
        }
    }
    private static void ArrayReferenceTypes()
    {
        int[] sayilar1 = new[] { 1, 2, 3, };
        int[] sayilar2 = new[] { 10, 20, 30, };
        sayilar1 = sayilar2; //artık sayilar1 sayilar2 nin adresini tutar. sayilar1 garbage collector tarafından temizlenir.
        sayilar2[0] = 1000;
        Console.WriteLine(sayilar1[0]);
    }

    private static void IntValueTypes()
    {
        int sayi1 = 10;
        int sayi2 = 20;
        sayi1 = sayi2; //sayi1 in değeri sayi2 nin değeri oldu
        sayi2 = 100;
        Console.WriteLine(sayi1);
    }
}