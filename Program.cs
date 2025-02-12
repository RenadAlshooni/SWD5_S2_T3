#region Q1
int num = 1;
//int multible;
do
{
    Console.WriteLine($" {num * 5} ");
    num++;
} while (num<=10);
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q2
int fact(int x)
{
    if (x <= 1)
        return 1;
    else 
        return x*fact(x-1);
}
Console.WriteLine("Please Enter Number To Get Factorial.");
int num2 = int.Parse(Console.ReadLine());
Console.WriteLine("fact of "+num2 + " = "+fact(num2));
#endregion

Console.WriteLine("--------------------------------------------------------");


#region Q3
int sum = 0;
for (int i = 0; i <= 100; i++)
{
    sum += i;
}
Console.WriteLine("The sum of the first 100 numbers  = " + sum);
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q4
for (int i = 1;i <= 12;i++)
{
    Console.WriteLine("Multiplicatio Table of "+ i);
    for (int j = 1; j <= 12; j++)
    {
        Console.WriteLine(i+" * "+j+" = "+i*j );
    }
    Console.WriteLine("*********************");
}
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q5

for (int i = 2; i <= 500; i++)
{
    bool isPrime = true;
    for (int j = 2; j < i; j++)
    {
        if (i % j == 0)
        { 
        isPrime = false;
        break;
        }
    }
    if (isPrime)
       Console.Write($" {i} ");
}
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q6
for (int i = 1; i <= 26; i++)
{
    for (char j = 'a'; j < 'a'+ i; j++)
    {
        Console.Write(j);
    }
    Console.WriteLine();
}
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q7
int[] arr = new int[] { 1, 2, 3, 4, 5 };
int max = arr[0];
int min = arr[0];
for (int i = 0; i < arr.Length; i++)
{
    if (arr[i] > max)
        max = arr[i];
    if (arr[i] < min)
        min = arr[i];
}
Console.WriteLine("Maximum element: " + max);
Console.WriteLine("Minimum element: " + min);
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q8
int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
int[] arr2 = new int[arr1.Length];
int counter = 0;
for (int i = arr1.Length-1; i >= 0; i--)
{
    arr2[counter++] = arr1[i];
}
for (int i = 0; i < arr2.Length ; i++)
{
    Console.Write(arr2[i]+"  ");
}
Console.WriteLine();
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q9
int[] arr9 = new int[5];
int[] arr10 = new int[5];
int counter2 = 0;

for(int i = 0;i < 5;i++)
{
    Console.Write("Please Enter Number:  ");
    arr9[i] = int.Parse(Console.ReadLine());
}

for(int i = 4; i >= 0;i--)
{
    arr10[counter2++] = arr9[i];
    
}
Console.WriteLine("Reserved Array :");

for(int i = 0; i < 5;  i++)
{
    Console.Write($" {arr10[i]} ");
}
Console.WriteLine();



#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q10
for (int i = 0; i <= 100; i++)
{
    if (i % 3 != 0)
        Console.Write($" {i} ");
    else
        continue;
}
Console.WriteLine();
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q11
Console.WriteLine("Please Enter Number");
int numberPrime = int.Parse(Console.ReadLine());
if (IsPrime(numberPrime))
{
    Console.WriteLine("Prime");
}
else
{
    Console.WriteLine("Not Prime");
}

bool IsPrime(int num)
{
    if (num < 2)
        return false;
    for (int i = 2;i*i <= num; i++)
    {
        if (num % i == 0)
            return false;
    }
    return true;
}
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q12
int count = 0;
int number = 2;

while (count < 20)
{
    if (IsPrime (number))
    {
        Console.Write($" {number} ");
        count++;
    }
    number++;
}
Console.WriteLine();
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q13
int even = 0 , odd = 0 , positive = 0 , negative = 0 ;
int[] arr3 = new int[] { 1, 2, -2, 8, 5 };
for (int i = 0; i < arr3.Length; i++)
{
    if (arr3[i] % 2 == 0 && arr3[i] >= 0)
    { 
        even++;
        positive++;
    }
    else if (arr3[i] % 2 == 0 && arr3[i] < 0)
    {
        even++;
        negative++;
    }
    else if (arr3[i] % 2  != 0 && arr3[i] >= 0)
    {
        odd++;
        positive++;
    }
    else
    {
        odd++;
        negative++;
    }
}
Console.WriteLine($"Even Number = {even} , Odd Number = {odd} , Positive Number = {positive} , Negative Number = {negative}");
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q14
Console.WriteLine("Please Enter Number.");
int numberFib =int.Parse(Console.ReadLine());
Fib(numberFib);
void Fib (int num)
{
    int first = 0 , second = 1 ;
    for (int i = 1; i <= num; i++)
    {
        Console.Write($"{first}  ");
        int next = first + second;
        first = second;
        second = next;
    }
    Console.WriteLine();
}
#endregion

Console.WriteLine("--------------------------------------------------------");

#region Q15
int[] arr4 = { 1, 2, 3, 2, 1 };
if (CheckPalindrome(arr4))
    Console.WriteLine("The array is a palindrome.");
else
    Console.WriteLine("The array is not a palindrome.");



bool CheckPalindrome(int[] arr)
{
    int left = 0 , right = arr.Length-1;
    while (left < right)
    {
        if (arr[left] != arr[right]) 
            return false;
        left++;
        right--;
    }
    return true;
}
#endregion

Console.ReadLine();
