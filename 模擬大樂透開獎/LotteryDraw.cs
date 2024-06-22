using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬大樂透開獎
{
    internal class LotteryDraw
    {
        public static List<String> RandomNumList()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            HashSet<String> set = new HashSet<String>();
            while (set.Count < 6)
            {
                set.Add(random.Next(1, 50).ToString());
            }
            return set.ToList();
        }

        public static String GetLotteryResult(List<String> buttonNameList)
        {
            int num = 0;

            List<String> randomNum = RandomNumList();
            Console.WriteLine("Random" + randomNum.Count);

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(randomNum[i]);

                if (randomNum.Contains(buttonNameList[i]))
                {
                    num++;
                }
            }

            String specialNum = buttonNameList.Where(x => x.Contains(randomNum[5])).Select(x => x).FirstOrDefault();

            return specialNum;

            //MessageBox.Show(GetRewardResult(num, specialNum), "B", MessageBoxButtons.OKCancel);
        }

        private String GetRewardResult(int num, String specialNum)
        {
            Console.WriteLine($"特別號:{specialNum}");
            switch (num)
            {
                case 2:
                    return (specialNum != null) ? "七獎" : "未中獎";
                case 3:
                    return (specialNum != null) ? "普獎" : "六獎";
                case 4:
                    return (specialNum != null) ? "四獎" : "五獎";
                case 5:
                    return (specialNum != null) ? "二獎" : "三獎";
                case 6:
                    return "頭獎";
                default:
                    return "未中獎";
            }
        }
    }
}
