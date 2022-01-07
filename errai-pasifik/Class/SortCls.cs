 
using System.Data; 

namespace errai_pasifik.Class
{
    internal class SortCls
    {
        static public int Partition(decimal[] arr, int left, int right)
        {
            decimal pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    decimal temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static public void quickSort(decimal[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    quickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSort(arr, pivot + 1, right);
                }
            }
        }

        static public decimal[] bubleSort(decimal[] arr) {
            decimal temp;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            } 
            return arr;
        }



        static public void MainMerge(decimal[] numbers, int left, int mid, int right)
        {
            decimal[] temp = new decimal[25];
            int i, eol, num, pos;
            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }
            while (left <= eol)
                temp[pos++] = numbers[left++];
            while (mid <= right)
                temp[pos++] = numbers[mid++];
            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        static public void SortMerge(decimal[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                SortMerge(numbers, left, mid);
                SortMerge(numbers, (mid + 1), right);
                MainMerge(numbers, left, (mid + 1), right);
            } 
        }

       static public DataTable sortgcd(decimal[] arrdec, decimal compareInt) {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("val");
            dt.Columns.Add("gcd");
           
            foreach (decimal i in arrdec)
            {
                DataRow dr = dt.NewRow();
                dr["val"] = i;
                dr["gcd"] = gcd(i,compareInt);
                dt.Rows.Add(dr);
            }

            dt.DefaultView.Sort = "gcd, val";
            return dt;
        }
        static decimal gcd(decimal a, decimal b)
        { 
            if (a == 0)
                return b;
            if (b == 0)
                return a; 
            if (a == b)
                return a; 
            if (a > b)
                return gcd(a - b, b);

            return gcd(a, b - a);
        }
    }
}
