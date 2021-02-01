using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        int cpuPrice;
        int gpuPrice;
        int ramPrice;
        int total;
        public MainWindow()
        {
            InitializeComponent();
            
            

        }

        private void CPU_DropDownClosed(object sender, EventArgs e)
        {
            Dictionary<string, int> proc = new Dictionary<string, int>();
            proc.Add("Ryzen 5 3600X", 325);
            proc.Add("Ryzen 7 3700X", 329);
            proc.Add("Intel i7 6700k", 273);
            proc.Add("Intel i7 9700K", 300);
            proc.Add("Ryzen 9 3900X", 489);
            proc.Add("Intel i7 10700KF", 332);
            proc.Add("Intel i7 9900K", 409);
            proc.Add("Ryzen 9 3950X", 750);
            proc.Add("Intel i9 10900K", 549);

            string processor = CPU.SelectionBoxItem as string;
            foreach (KeyValuePair<string, int> cpu in proc)
            {
                if (processor == cpu.Key)
                {

                    cpuPrice = cpu.Value;
                    CPU_Price.Text = cpuPrice.ToString();
                }
            }
            UpdatePrice();
        }

        private void GPU_DropDownClosed(object sender, EventArgs e)
        {
            Dictionary<string, int> gpu = new Dictionary<string, int>();
            gpu.Add("GTX 1060", 160);
            gpu.Add("GTX 1080ti", 600);
            gpu.Add("RTX 2060", 350);
            gpu.Add("RTX 2070 Super", 550);
            gpu.Add("RTX 2080ti", 800);
            gpu.Add("RX 570", 150);
            gpu.Add("Intel i7 9900K", 409);
            gpu.Add("RX 5600", 340);
            gpu.Add("RX 5700XT", 450);
            foreach (KeyValuePair<string, int> gfx in gpu)
            {
                if (GPU.SelectionBoxItem.ToString() == gfx.Key)
                {
                    gpuPrice = gfx.Value;
                    GPU_Price.Text = gpuPrice.ToString();
                }


            }
            UpdatePrice();
        }

        private void Ram_DropDownClosed(object sender, EventArgs e)
        {
            Dictionary<string, int> ram = new Dictionary<string, int>();
            ram.Add("8 GB 2666", 30);
            ram.Add("16 GB 2666", 50);
            ram.Add("8 GB 3000", 40);
            ram.Add("16 GB 3000", 75);
            ram.Add("32 GB 3000", 140);
            ram.Add("16 GB 3200", 120);
            ram.Add("32 GB 3200", 200);
            foreach (KeyValuePair<string, int> mem in ram)
            {
                if (Ram.SelectionBoxItem.ToString() == mem.Key)
                {
                    ramPrice = mem.Value;
                    Ram_Price.Text = ramPrice.ToString();
                }
            }
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            total = 0;
            total = cpuPrice + gpuPrice + ramPrice;
            Total.Text = total.ToString();
            
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            
            if (ValidInputs(out string userFeedback))
            {
                int answer = Convert.ToInt32(Payments.Text);
                int payment = total / answer;
                Answer.Text = payment.ToString();
                
                
            }
            else
            {
                MessageBox.Show(userFeedback);
            }


        }
        private bool ValidInputs(out string userFeedback)
        {
            bool validInputs = true;
            userFeedback = "";

            //
            // set bool value and build out the user feedback message
            //
            if (!int.TryParse(Payments.Text, out int goodNum))
            {
                validInputs = false;
                userFeedback += "Please enter a Number" + Environment.NewLine;
            }
            return validInputs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void Exit_Window_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
