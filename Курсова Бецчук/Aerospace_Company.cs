using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Курсова_Бейчук
{

    internal abstract class Aerospace_Company
    {
        private string _name; 
        private int _yearly_prod; 
        private int _yearly_orders; 
        private double _yearly_profit; 

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Yearly_prod
        {
            get => _yearly_prod;
            set => _yearly_prod = value;
        }

        public int Yearly_orders
        {
            get => _yearly_orders;
            set => _yearly_orders = value;
        }

        public double Yearly_profit
        {
            get => _yearly_profit;
            set => _yearly_profit = value;
        }

        public Aerospace_Company() {}

        public Aerospace_Company(string name, int yearly_prod, int yearly_orders, double yearly_profit)
        {
            this.Name = name;
            this.Yearly_prod = yearly_prod;
            this.Yearly_orders = yearly_orders;
            this.Yearly_profit = yearly_profit;
        }

        public abstract double AvgProfitPerPlane();

        ~Aerospace_Company()    
        {
            //MessageBox.Show("Об'єкт " + Name + " було знищено");
        }
    }
    
    internal interface IClass1
    {
        public int OrdersProduction();
    }

    internal class Aerospace_Company2 : Aerospace_Company, IClass1
    {
        public Aerospace_Company2() { }

        public Aerospace_Company2(string name, int yearly_prod, int yearly_orders, double yearly_profit) : base(name, yearly_prod, yearly_orders, yearly_profit) 
        {
            this.Name = name;
            this.Yearly_prod = yearly_prod;
            this.Yearly_orders = yearly_orders;
            this.Yearly_profit = yearly_profit;
        }


        public int OrdersProduction()   // Calculates percentage of uncompleted orders
        {
            double p = 100 - Convert.ToDouble(Yearly_prod) / Convert.ToDouble(Yearly_orders) * 100;
            return Convert.ToInt32(p);
        }

        public override double AvgProfitPerPlane()  // Calculates average profit per plane produced (rounded to 0 decimal places)
        {
            return Math.Round(Yearly_profit / Yearly_prod, 0); 
        }

        ~Aerospace_Company2()
        {
            //MessageBox.Show("Об'єкт " + Name + " було знищено");
        }
    }

    internal class Aerospace_Company3 : Aerospace_Company2
    {
        public Aerospace_Company3() { }

        public Aerospace_Company3(string name, int yearly_prod, int yearly_orders, double yearly_profit) : base(name, yearly_prod, yearly_orders, yearly_profit)
        {
            this.Name = name;
            this.Yearly_prod = yearly_prod;
            this.Yearly_orders = yearly_orders;
            this.Yearly_profit = yearly_profit;
        }

        public int OrdersProduction()   // Calculates percentage of completed orders
        {
            double p = Convert.ToDouble(Yearly_prod) / Convert.ToDouble(Yearly_orders) * 100;
            return Convert.ToInt32(p);
        }

        public override double AvgProfitPerPlane()   // Calculates average profit per plane produced
        {
            return Yearly_profit / Yearly_prod;
        }

        ~Aerospace_Company3()
        {
            //MessageBox.Show("Об'єкт " + Name + " було знищено");
        }
    }

    internal class AerospaceCompany : Aerospace_Company3
    {
        public AerospaceCompany() { }

        public AerospaceCompany(string name, int yearly_prod, int yearly_orders, double yearly_profit) : base(name, yearly_prod, yearly_orders, yearly_profit)
        {
            this.Name = name;
            this.Yearly_prod = yearly_prod;
            this.Yearly_orders = yearly_orders;
            this.Yearly_profit = yearly_profit;
        }

        public override double AvgProfitPerPlane()   // Calculates average profit per plane produced (rounded to 2 decimal places)
        {
            return Math.Round(Yearly_profit / Yearly_prod, 2);
        }

        ~AerospaceCompany()
        {
            //MessageBox.Show("Об'єкт " + Name + " було знищено");
        }
    }
}
