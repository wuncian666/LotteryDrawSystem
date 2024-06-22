using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬大樂透開獎
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <49; i++)
            {
                Button button = new Button();
                button.Text = (i+1).ToString();
                button.Width = 50;
                button.Height = 50;
                button.Click += Number_Click;
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        int limit = 6;
        List<Button> buttonList = new List<Button>();
        private void Number_Click(object sender, EventArgs e)
        {
            if (buttonList.Count < limit)
            {
                Button button = (sender) as Button;
                buttonList.Add(button);

                PrintNum();

                button.Enabled = false;
            } 
            else
            {
                MessageBox.Show("超過六個數字", "B", MessageBoxButtons.OKCancel);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button lastButton = buttonList.LastOrDefault();

            if (lastButton != null)
            {
                lastButton.Enabled = true;
                buttonList.Remove(lastButton);

                PrintNum();
            }
        }

        private void PrintNum()
        {
            textBox1.Clear();

            foreach (Button button in buttonList)
            {
                textBox1.Text += button.Text + " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<String> buttonNameList = buttonList.Select(x => x.Text).ToList();
            String result = LotteryDraw.GetLotteryResult(buttonNameList);
            MessageBox.Show(result, "B", MessageBoxButtons.OKCancel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<String> nums = LotteryDraw.RandomNumList();

            String numsStr = "";
            for (int i = 0; i < nums.Count; i++)
            {
                if (i < (nums.Count - 1))
                {
                    numsStr += nums[i] + ", ";
                } else
                {
                    numsStr += nums[i];
                }
                    
            }

            textBox2.Text = numsStr;
        }
    }
}
