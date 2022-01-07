using System; 
using System.Configuration;
using System.Data;
using System.Diagnostics; 
using System.Globalization;
using System.Linq; 
using System.Threading.Tasks;
using System.Windows.Forms;
using errai_pasifik.Class;
namespace errai_pasifik
{
    public partial class Form1 : Form
    {
        decimal[] InpArr; 
        public Form1()
        {
            InitializeComponent();
        }
        void SortQ() {
           
            var stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            decimal[] DecArrQ  = InpArr;
            SortCls.quickSort(DecArrQ, 0, DecArrQ.Length - 1); 

            stopwatch1.Stop();
            dataGridView1.BeginInvoke(new Action(() => { dataGridView1.DataSource = DecArrQ.Where(x => x > 0).Select((x, index) => new { val = x }).ToList(); }));          
            label1.BeginInvoke(new Action(() => { label1.Text = stopwatch1.ElapsedMilliseconds.ToString() + " ms"; }));
        }
        void SortB()
        {
            var stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            decimal[] DecArrB = SortCls.bubleSort(InpArr); 

           
            dataGridView2.BeginInvoke(new Action(() => { dataGridView2.DataSource = DecArrB.Where(x => x > 0).Select((x, index) => new { val = x }).ToList(); }));
            stopwatch2.Stop();
            label2.BeginInvoke(new Action(() => { label2.Text = stopwatch2.ElapsedMilliseconds.ToString() + " ms"; }));
            
        }
        void SortM()
        {
            var stopwatch3 = new Stopwatch();
            stopwatch3.Start();
             decimal[] DecArrM = InpArr; 
            SortCls.SortMerge(DecArrM, 0, DecArrM.Length - 1);

           
            dataGridView3.BeginInvoke(new Action(() => { dataGridView3.DataSource = DecArrM.Where(x => x > 0).Select((x, index) => new { val = x }).ToList(); }));
            stopwatch3.Stop();
            label3.BeginInvoke(new Action(() => { label3.Text = stopwatch3.ElapsedMilliseconds.ToString() + " ms"; }));

        }
        void SortG()
        {
            var stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            string GCFCompare = ConfigurationManager.AppSettings["GCFCompare"];

            decimal[] DecArrG = InpArr;
            DataTable dtG = SortCls.sortgcd(DecArrG, Convert.ToDecimal(GCFCompare));           
            dataGridView4.BeginInvoke(new Action(() => { dataGridView4.DataSource = dtG; }));
            stopwatch4.Stop();

            label4.BeginInvoke(new Action(() => { label4.Text = stopwatch4.ElapsedMilliseconds.ToString() + " ms"; }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
                decimal d;
            
                string[] StrArr = textBox1.Text.Split(',');

                if (StrArr.All(number => Decimal.TryParse(number, out d)))
                {
                    InpArr = new decimal[StrArr.Length];
                    for (int i = 0; i < StrArr.Length; i++)
                    {
                        InpArr[i] = Convert.ToDecimal(StrArr[i], new CultureInfo("en-US"));
                    }
 
                    Parallel.Invoke(new Action(SortQ) , new Action(SortB) , new Action(SortM), new Action(SortG));
                    
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());              
            }
        }
    }
}
