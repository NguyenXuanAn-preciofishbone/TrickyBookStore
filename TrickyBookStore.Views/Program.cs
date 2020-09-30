using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Services;
using TrickyBookStore.Services.Payment;

namespace TrickyBookStore.Views
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddService()
                .BuildServiceProvider();

            var PaymentService = serviceProvider.GetService<IPaymentService>();

            Console.WriteLine("Input customer id: ");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input year: ");
            int year = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input month: ");
            int month = Int32.Parse(Console.ReadLine());

            DateTimeOffset startDate = new DateTimeOffset(new DateTime(year, month, 1));
            DateTimeOffset endDate = new DateTimeOffset(new DateTime(year, month, 31));

            double result = PaymentService.GetPaymentAmount(id, startDate, endDate);

            Console.WriteLine("Payment ammount: "+ result);
        }
    }
}
