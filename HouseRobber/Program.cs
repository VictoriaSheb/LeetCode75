

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        var result = solution.Rob(new int[] { 228, 67, 195, 15, 0, 90, 151, 210, 17, 196, 0, 10, 28, 110, 169, 94, 9, 23, 52, 63, 136, 122, 22, 191, 144, 22, 173, 106, 88, 59, 200, 156, 39, 109, 244, 231, 183, 99, 114, 15, 114, 32, 57, 36, 117, 151, 177, 106, 229, 188, 178, 47, 96, 191, 25, 180, 153, 187, 136, 146, 117, 57, 77, 110, 215, 115, 84, 218, 59, 121, 202, 109, 205, 95, 214, 100, 175, 50, 223, 11, 14, 164, 224, 15, 100, 241, 61, 64, 197, 206, 3, 149, 108, 186 });
    //    var result = solution.Rob(new int[] { 8, 9, 9, 4, 10, 5, 6, 9, 7, 9 });

        Console.WriteLine(result);
    }
}

public class Solution 
{

    int[] even3Sums;
    int[] odd3Sums;

    public int Rob(int[] nums) 
    {
        int maxSum;
        int lenAddNums = nums.Length / 3;
        int remainder = nums.Length - lenAddNums * 3;
        even3Sums = new int[((remainder==0)?0:1) + lenAddNums];
        odd3Sums = new int[((remainder == 0) ? 0 : 1) + lenAddNums];
        for (int i = 0; i < lenAddNums*3; i = i + 3)
        {
            if (((i + 1) % 2) == 0)
            {
                even3Sums[i / 3] = nums[i + 1];
                odd3Sums[i / 3] = nums[i] + nums[i + 2];
            }
            else 
            { 
                even3Sums[i / 3] = nums[i] + nums[i + 2];
                odd3Sums[i / 3] = nums[i + 1];
            }
        }
        int lastThree = nums.Length - 1;
        if (remainder == 2)
        {
            if ((lastThree % 2) == 0)
            {
                even3Sums[lastThree / 3] = nums[lastThree];
                odd3Sums[lastThree / 3] = nums[lastThree - 1];
            }
            else
            {
                even3Sums[lastThree / 3] = nums[lastThree - 1];
                odd3Sums[lastThree / 3] = nums[lastThree];
            }
        }
        else if (remainder == 1) 
        {
            if ((lastThree % 2) == 0)
            {
                even3Sums[lastThree / 3] = nums[lastThree];
                odd3Sums[lastThree / 3] = 0;
            }
            else
            {
                even3Sums[lastThree / 3] = 0;
                odd3Sums[lastThree / 3] = nums[lastThree];
            }
        }
        return SearchSum(nums);

        //maxSum = Math.Max(even3Sums.Sum(), odd3Sums.Sum());
        //int oddSum = odd3Sums.First(), evenSum = even3Sums.First();
        //for (int i = 1; i < even3Sums.Length; i++) 
        //{
        //    // Тут нужно найти наилучшую сумму по четному и нечетному массивам
        //    // Возможно стоит добавить рекурсию в случае неопределенности, тогда рекурсия для этого for
        //}
        ///*
        //1 2 8 2 1 10
        //even: 9 1    // чтобы не образовывать новый случай можно проверять разность между суммой для массива и текущей суммой
        //odd: 2 12

         
        // */



    }

    private int SearchSum(int[] nums) 
    {
        bool idIsEven;
        int newPositionSum;
        int oddSum = odd3Sums.First(), evenSum = even3Sums.First();
        int maxSum = 0;
        bool isEvenId;
        int remainingSumOdd = odd3Sums.Sum() - odd3Sums[0], remainingSumEven = even3Sums.Sum() - even3Sums[0];
        for (int i = 1; i < even3Sums.Length; i++)
        {
            isEvenId = (((i - 1) * 3) % 2) == 0;
            if (!isEvenId && even3Sums[i] > odd3Sums[i])
            {
                newPositionSum = nums[(i - 1) * 3] + even3Sums[i];
                newPositionSum = Math.Max(newPositionSum, (odd3Sums[i - 1] + ((nums.Length <= (i * 3 + 2)) ? 0 : nums[i * 3 + 2])));
              
                newPositionSum -= odd3Sums[i - 1];               
                if (newPositionSum > odd3Sums[i])
                    maxSum = Math.Max(maxSum, SearchOneSum(nums, i + 1, oddSum + newPositionSum, true, remainingSumEven, remainingSumOdd));
            }
            else if (isEvenId && even3Sums[i] < odd3Sums[i]) 
            {
                newPositionSum = nums[(i - 1) * 3] + odd3Sums[i];
                newPositionSum = Math.Max(newPositionSum, (even3Sums[i - 1] + ((nums.Length <= (i * 3 + 2)) ? 0 : nums[i * 3 + 2])));

                newPositionSum -= even3Sums[i - 1];
                if (newPositionSum > even3Sums[i])
                    maxSum = Math.Max(maxSum, SearchOneSum(nums, i + 1, evenSum + newPositionSum, false, remainingSumEven, remainingSumOdd));
            }
            if (!isEvenId && (remainingSumEven <= remainingSumOdd))
                maxSum = Math.Max(maxSum, SearchOneSum(nums, i + 1, evenSum + odd3Sums[i], false, remainingSumEven - even3Sums[i], remainingSumOdd - odd3Sums[i]));
            if (isEvenId && (remainingSumEven >= remainingSumOdd))
                maxSum = Math.Max(maxSum, SearchOneSum(nums, i + 1, oddSum + even3Sums[i], true, remainingSumEven - even3Sums[i], remainingSumOdd - odd3Sums[i]));
            oddSum += odd3Sums[i];
            evenSum += even3Sums[i];

            remainingSumEven -= even3Sums[i];
            remainingSumOdd -= odd3Sums[i];
        }
        return Math.Max(maxSum, Math.Max(oddSum, evenSum));
    }

    private int SearchOneSum(int[] nums, int id, int sum, bool isEven, int remainingSumEven, int remainingSumOdd) 
    {
        int newPositionSum;
        int maxSum = 0;
        bool isEvenId;
        for (int i = id; i < even3Sums.Length; i++)
        {
            isEvenId = (((i - 1) * 3) % 2) == 0;
            if (!isEvenId && !isEven && even3Sums[i] > odd3Sums[i])
            {
                newPositionSum = nums[(i - 1) * 3] + even3Sums[i];
                newPositionSum = Math.Max(newPositionSum, (odd3Sums[i - 1] + ((nums.Length <= (i * 3 + 2)) ? 0 : nums[i * 3 + 2])));

                newPositionSum -= odd3Sums[i - 1];
                if (newPositionSum > odd3Sums[i])
                    maxSum = Math.Max(maxSum, SearchOneSum(nums, i + 1, sum + newPositionSum, !isEven, remainingSumEven, remainingSumOdd));
            }
            else if (isEvenId && isEven && even3Sums[i] < odd3Sums[i])
            {
                newPositionSum = nums[(i - 1) * 3] + odd3Sums[i];
                newPositionSum = Math.Max(newPositionSum, (even3Sums[i - 1] + ((nums.Length <= (i * 3 + 2)) ? 0 : nums[i * 3 + 2])));

                newPositionSum -= even3Sums[i - 1];
                if (newPositionSum > even3Sums[i])
                    maxSum = Math.Max(maxSum, SearchOneSum(nums, i + 1, sum + newPositionSum, !isEven, remainingSumEven, remainingSumOdd));
            }
           
            if (!(isEven && isEvenId) && (isEven || isEvenId))
                if((!isEven && (remainingSumEven>=remainingSumOdd)) || (isEven && (remainingSumEven <= remainingSumOdd)))
                maxSum = Math.Max(maxSum, SearchOneSum(nums, i + 1, sum + ((isEven) ? odd3Sums[i] : even3Sums[i]), !isEven, remainingSumEven - even3Sums[i], remainingSumOdd - odd3Sums[i]));
            
            sum += (isEven) ? even3Sums[i] : odd3Sums[i];
            remainingSumEven -= even3Sums[i];
            remainingSumOdd -= odd3Sums[i];

        }
        return Math.Max(maxSum, sum);
    }
}



