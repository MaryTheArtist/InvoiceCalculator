using System;
using System.Runtime.CompilerServices;

namespace InvoiceCalculator
{
    class InvoiceCalculator
    {
        static void Main(string[] args)
        {
            Console.Write("Monthly fee: ");
            double monthFee = double.Parse(Console.ReadLine());
            Console.Write("SMSs: ");
            int sms = int.Parse(Console.ReadLine());
            Console.Write("MMCs: ");
            int mmc = int.Parse(Console.ReadLine());
            Console.Write("Not included minutes to A1: ");
            int notInclMinsToA1 = int.Parse(Console.ReadLine());
            Console.Write("Not included minutes to Telenor: ");
            int notInclMinsToTelenor = int.Parse(Console.ReadLine());
            Console.Write("Not included minutes to Vivacom: ");
            int notInclMinsToVivacom = int.Parse(Console.ReadLine());
            Console.Write("Minutes in rouming: ");
            int minsInRoaming = int.Parse(Console.ReadLine());
            Console.Write("Not included minutes in country: ");
            int notInclMbInCountry = int.Parse(Console.ReadLine());
            Console.Write("Not included minutes in EU: ");
            int notInclMbInEU = int.Parse(Console.ReadLine());
            Console.Write("Not included minutes outside EU: ");
            int notInclMbOutEU = int.Parse(Console.ReadLine());
            Console.Write("Other fees: ");
            double otherFees = double.Parse(Console.ReadLine());
            Console.Write("Discounts: ");
            double discounts = double.Parse(Console.ReadLine());


            double totalSum = CalculateInvoiceSum(monthFee,
                                           sms,
                                           mmc,
                                           notInclMinsToA1,
                                           notInclMinsToTelenor,
                                           notInclMinsToVivacom,
                                           minsInRoaming,
                                           notInclMbInCountry,
                                           notInclMbInEU,
                                           notInclMbOutEU,
                                           otherFees,
                                           discounts);

            Console.WriteLine("Total Sum: " + Math.Round(totalSum, 2) + " BGN");
            
        }

        private static double CalculateInvoiceSum(double monthFee,
                                                  int sms,
                                                  int mmc,
                                                  int notInclMinsToA1,
                                                  int notInclMinsToTelenor,
                                                  int notInclMinsToVivacom,
                                                  int minsInRoaming,
                                                  int notInclMbInCountry,
                                                  int notInclMbInEU,
                                                  int notInclMbOutEU,
                                                  double otherFees,
                                                  double discounts)
        {

            double smsSum = CalculateSmsSum(sms);
            double mmcSum = CalculateMmcSum(mmc);

            double totalSum = monthFee 
                            + smsSum 
                            + mmcSum 
                            + notInclMinsToA1 * 0.03 
                            + notInclMinsToTelenor * 0.09 
                            + notInclMinsToVivacom * 0.09 
                            + minsInRoaming * 0.15 
                            + notInclMbInCountry * 0.02 
                            + notInclMbInEU * 0.05 
                            + notInclMbOutEU * 0.2 
                            + otherFees 
                            - discounts;

            return totalSum;
        }

        private static double CalculateSmsSum(int sms)
        {
            double smsSum = 0;

            if (sms < 50)
            {
                smsSum += sms * 0.18;
            }
            else if (sms >= 50 && sms <= 100)
            {
                smsSum += sms * 0.16;
            }
            else
            {
                smsSum += sms * 0.11;
            }

            return smsSum;
        }

        private static double CalculateMmcSum(int mmc)
        {
            double mmcSum = 0;

            if (mmc < 50)
            {
                mmcSum += mmc * 0.25;
            }
            else if (mmc >= 50 && mmc <= 100)
            {
                mmcSum += mmc * 0.23;
            }
            else
            {
                mmcSum += mmc * 0.18;
            }

            return mmcSum;
        }
}
}
