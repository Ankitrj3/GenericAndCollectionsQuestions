// All Questions Were done on Online Platform programiz


// 1. // Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{
    public static bool Check(string str){
        if(string.IsNullOrWhiteSpace(str)){
            return false;
        }
        if (str.Contains(" ")){
            return false;
        }
        if(!str.Contains("@")){
            return false;
        }
        string [] strarr = str.Split('@');
        if(strarr.Length > 2){
            return false;
        }
        if(strarr[0].Contains('.')){
            return false;
        }
        if(!strarr[1].Contains('.')){
            return false;
        }
            
        return true;
    }
    public static void Main(string[] args)
    {
        string a = Console.ReadLine();
        Console.WriteLine(Check(a));
    }
} 
// 2.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
//  Reverse a string without using built-in functions.
using System;

public class HelloWorld
{
    public static string ReverseString(string str){
        string res ="";
        for(int i=str.Length-1;i>=0;i--){
            res+=str[i];
        }
        return res;
    }
    public static void Main(string[] args)
    {
        string? str = Console.ReadLine();
        Console.WriteLine(ReverseString(str));
    }
}

// 3.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Find the largest element in an integer array
using System;
public class HelloWorld
{
    public static int LargestElemet(int [] arr){
        int max = int.MinValue;
        for(int i=0;i<arr.Length;i++){
            if(arr[i] > max){
                max = arr[i];
            }
        }
        return max;
    }
    public static void Main(string[] args)
    {
        int [] arr = new int[]{12,34,23,45,23,568,674,32};
        Console.WriteLine(LargestElemet(arr));
    }
}
// 4.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Remove duplicates from a list using a HashSet.
using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        List<int> list = new List<int>();
        list.Add(12);
        list.Add(45);
        list.Add(12);
        list.Add(45);
        list.Add(67);
        HashSet<int> set = new HashSet<int>(list);
        
        foreach(var i in set){
            Console.Write(i+" ");
        }
    }
} 
// 5.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Find the frequency of elements in an array using a Dictionary

using System;
using System.Collections.Generic;
public class HelloWorld
{
    public static void Main(string[] args)
    {
        List<int> list = new List<int>();
        Console.WriteLine("1. Enter Values in Array");
        Console.WriteLine("2. Show Values in Dictionary");
        Console.WriteLine("3. Exit");
        while(true){
            Console.WriteLine("Enter the choice");
            string choice = Console.ReadLine();
            
            if(choice =="3"){
                break;
            }
            else if(choice == "1"){
                Console.WriteLine("Enter the number of value in array");
                int n = int.Parse(Console.ReadLine());
                
                for(int i=0;i<n;i++){
                    int val = int.Parse(Console.ReadLine());
                    list.Add(val);
                }
            }
            else if(choice == "2"){
                Dictionary<int,int> res = new Dictionary<int,int>();
                foreach(var i in list){
                    if(res.ContainsKey(i)){
                        res[i]++;
                    }else{
                        res[i] = 1;
                    }
                }
                foreach(var i in res){
                    Console.WriteLine(i.Key+" "+i.Value);
                }
            }
        }
    }
}
// 6.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Find the sum of all elements in an array.
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        int [] arr = new int[]{12,34,23,56,34};
        int sum = 0;
        
        foreach(var i in arr){
            sum+=i;
        }
        Console.WriteLine(sum);
    }
}

// 7.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Check if a given string is a palindrome
using System;
using System.Collections.Generic;
public class HelloWorld
{
    public static bool CheckPalindrome(string str){
        int left = 0;
        int right = str.Length-1;
        
        while(left < right){
            while(left < right && !char.IsLetterOrDigit(str[left])){
                left++;
            }
                
            while(left < right && !char.IsLetterOrDigit(str[right])){
                right--;
            }
            
            if(str[left] != str[right]){
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
    public static void Main(string[] args)
    {
        string str = Console.ReadLine();
        Console.WriteLine(CheckPalindrome(str));
    }
}

// 8.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
//  Create a simple base class `Animal` with a method `Speak()`. Derive a `Dog` class that overrides it.
using System;

public class Animal{
    public virtual void Speak(){
        return;
    }
}
public class Dog : Animal{
    public override void Speak(){
        Console.WriteLine("Dog Speak");
    }
}
public class HelloWorld
{
    public static void Main(string[] args)
    {
        Animal an = new Dog();
        an.Speak();
    }
}

// 9.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Create a `Person` class with a method `GetDetails()`. Derive a `Student` class that overrides it.
using System;
public class Person{
    public virtual void GetDetails(){
        return;
    }
}
public class Student : Person{
    public override void GetDetails(){
        Console.WriteLine("Student is Present");
    }
}
public class HelloWorld
{
    public static void Main(string[] args)
    {
        Person p = new Student();
        p.GetDetails();
    }
}

// 10.
// Implement an `Employee` base class with a method `CalculateSalary()`. Create a `Manager` class that adds a bonus to salary.
// Max Time: 10 minutes

// Explanation: This question introduces method overriding and the use of `base` to call the parent class method while adding additional logic.
using System;

public class Employee{
    public virtual void CalculateSalary(double days){
       Console.WriteLine(days * 1100);
    }
}
public class Manager : Employee{
    public override void CalculateSalary(double days){
        double bonus = 10000;
        Console.WriteLine((days*1100)+bonus);
    }
}
public class HelloWorld
{
    public static void Main(string[] args)
    {
        Employee e = new Manager();
        e.CalculateSalary(23);
    }
}

// 11.
// 4. Create a `Vehicle` class with `StartEngine()`. Extend it to `Car` and `Motorcycle` with different behaviors.
// Max Time: 12 minutes

// Explanation: This demonstrates how multiple classes can inherit from the same parent and implement methods differently.

using System;

public class Vehicle{
    public string name{get; set;}
    public Vehicle(string name){
        this.name = name;
    }
    public virtual void StartEngine(){
        Console.WriteLine("this Engine is not Assigned to Any Vehicle");
    }
}
public class Car : Vehicle {
    public Car(string name) : base(name){
        
    }
    public override void StartEngine(){
        Console.WriteLine("This Engine is Assigned to this "+name);
    }
}
public class Bike : Vehicle {
    public Bike(string name) : base(name){
        
    }
    public override void StartEngine(){
        Console.WriteLine("This Engine is Assigned to this "+name);
    }
}
public class HelloWorld
{
    public static void Main(string[] args)
    {
        Vehicle v = new Car("Swift");
        v.StartEngine();
        Vehicle v1 = new Bike("Bullet");
        v1.StartEngine();
    }
}

// 12.
// 5. Implement a `BankAccount` class with `Deposit()` and `Withdraw()`. Extend it to `SavingsAccount` with interest calculation.
// Max Time: 15 minutes

// Explanation: You'll implement a basic banking system where `SavingsAccount` adds extra functionality.
using System;

public class BankAccount{
    public string AccountNo{get; set;}
    public double Amount{get; set;}
    
    public BankAccount(string accountNo){
        AccountNo = accountNo;
        Amount = 0;
    }
    
    public virtual void Deposit(double amount){
        Console.WriteLine("this account is not assigned to any account holder");
    }
    public virtual void Withdraw(double amount){
        Console.WriteLine("this account is not assigned to any account holder");
    }
}
public class SavingAccount : BankAccount{
    public SavingAccount(string accountNo) : base(accountNo){
        
    }
    public override void Deposit(double amount){
        Console.WriteLine("This Account is Used for Deposit "+AccountNo);
        Amount += amount;
        Console.WriteLine("Amount is Deposited "+Amount);
    }
    public override void Withdraw(double amount){
        Console.WriteLine("This Account is Used for Withdraw "+AccountNo);
        Amount -= amount;
        Console.WriteLine("Amount Remaining "+Amount);
    }
}
public class HelloWorld
{
    public static void Main(string[] args)
    {
        BankAccount bk = new SavingAccount("AKAS12143342");
        bk.Deposit(12032);
        bk.Withdraw(1200);
        
    }
}

// 13.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Implement `Shape` class with `CalculateArea()`. Extend to `Rectangle` and `Circle` with area calculations.
// Max Time: 15 minutes

// Explanation: You'll learn how different classes can provide unique implementations for a common method.


using System;

public class Shape{
    public virtual void CalculateArea(){
        return;
    }
}
public class Circle : Shape{
    public double radius{get; set;}
    public Circle(double radius){
        this.radius = radius;
    }
    public override void CalculateArea(){
        Console.WriteLine(Math.Round(Math.PI * radius,2));
    }
}
public class Rectangle : Shape{
    public double length{get; set;}
    public double width{get; set;}
    
    public Rectangle(double length, double width){
        this.length = length;
        this.width = width;
    }
    public override void CalculateArea(){
        Console.WriteLine(length*width);
    }
}
public class HelloWorld
{
    public static void Main(string[] args)
    {
        Shape s = new Circle(12.2);
        s.CalculateArea();
        Shape s1 = new Rectangle(12,34);
        s1.CalculateArea();
    }
}

// 14.
using System;

public abstract class Payment{
    public abstract void ProcessPayment();
}
public class CreditCardPayment : Payment{
    public override void ProcessPayment(){
        Console.WriteLine("CreditCard Payment");
    }
}
public class PayPalPayment : Payment{
    public override void ProcessPayment(){
        Console.WriteLine("PayPal Payment");
    }
}
public class HelloWorld
{
    public static void Main(string[] args)
    {
        Payment p = new PayPalPayment();
        p.ProcessPayment();
    }
}

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Email masking ("john.doe@gmail.com" → "j***@gmail.com").
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        string a = "Ankitranja@gmail.com";
        
        string [] z = a.Split("@");
        
        string mask = z[0];
        string ma = "";
        for(int i=0;i<mask.Length;i++){
            if(i == 0){
                ma += mask[i];
            }
        }
        ma+="***@";
        ma+=z[1];
        Console.WriteLine(ma);
    }
} 


// 15.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Valid Parentheses


using System;
using System.Collections.Generic;


public class HelloWorld
{
    public static bool ValidParentheses(string str){
        Stack<char> stack = new Stack<char>();
        
        foreach(var i in str){
            if(i == '(' || i == '{' || i == '['){
                stack.Push(i);
            }
            if(i == ')' || i == '}' || i == ']'){
                if(stack.Count == 0){
                    return false;
                }
                var top = stack.Pop();
                if(i == ')' && top != '(' || i == '}' && top != '{' || i == ']' && top != '['){
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the Parentheses ");
        string str = Console.ReadLine();
        
        Console.WriteLine(ValidParentheses(str));
    }
}

// 16.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Run-length encoding (e.g., "aaabbcccc" → "a3b2c4").
using System;
using System.Collections.Generic;
public class HelloWorld
{
    public static string Encoding(string str){
        Dictionary<char,int> map = new Dictionary<char,int>();
        
        foreach(var i in str){
            if(map.ContainsKey(i)){
                map[i]++;
            }else{
                map[i] = 1;
            }
        }
        string res = "";
        foreach(var i in map){
            res+=i.Key;
            res+=i.Value.ToString();
        }
        return res;
        
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter The String : ");
        string? str = Console.ReadLine();
        Console.WriteLine(Encoding(str));
    }
}

// 17.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Anagram checker without built-in sort.

using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static bool CheckAnagram(string s1, string s2){
        char [] ch1 = s1.ToCharArray();
        char [] ch2 = s2.ToCharArray();
        
        Array.Sort(ch1);
        Array.Sort(ch2);
        
        string ss = new string(ch1);
        string tt = new string(ch2);
        
        if(ss.Equals(tt)){
            return true;
        }else{
            return false;
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter string 1");
        string? s1 = Console.ReadLine();
        Console.WriteLine("Enter string 2");
        string? s2 = Console.ReadLine();
        
        Console.WriteLine(CheckAnagram(s1,s2));
    }
}

// 18.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Reverse words but not characters.
using System;

public class HelloWorld
{
    public static void ReverseWordOnly(string str){
        string [] strSplit = str.Split(" ");
        string res = "";
        foreach(var i in strSplit){
            char [] reverse = i.ToCharArray();
            Array.Reverse(reverse);
            string j = new string(reverse);
            
            res+=j+" ";
        }
        
        Console.WriteLine(res.Trim());
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String");
        string str = Console.ReadLine();
        
        ReverseWordOnly(str);
    }
}

// 19.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Remove duplicate characters while preserving order.

using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static string DuplicateItem(string str){
        HashSet<char> set = new HashSet<char>();
        foreach(var i in str){
            set.Add(i);
        }
        string res = "";
        foreach(var i in set){
            res += i.ToString();
        }
        return res;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String");
        string str = Console.ReadLine();
        Console.WriteLine(DuplicateItem(str));
    }
}

// 20.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Find all palindromic substrings

using System;
using System.Collections.Generic;


public class HelloWorld
{
    public static List<string> PalindromicString(string str){
        List<string> lis = new List<string>();
        string res = "";
        for(int i=0;i<str.Length;i++){
            for(int j=i;j<str.Length;j++){
                res = str.Substring(i, j - i + 1);
                if(IsPalindrome(res)){
                    lis.Add(res);
                }
            }
        }
        return lis;
    }
    public static bool IsPalindrome(string str){
        int left = 0;
        int right = str.Length-1;
        
        while(left < right){
            if(str[left] != str[right]){
                return false;
            }
        left++;
        right--;
        }
        return true;
    }
    public static void Main(string[] args)
    {
       Console.WriteLine("Enter the string");
       string str = Console.ReadLine();
       
       List<string> res = PalindromicString(str);
       foreach(var i in res){
           Console.WriteLine(i);
       }
    }
}

// 21.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Case-insensitive replace without regex
using System;

public class HelloWorld
{
    public static string ReplaceWithOutRegex(string val, string oldVal, string NewVal){
        
        return val.Replace(oldVal, NewVal);
    }
    public static void Main(string[] args)
    {
        Console.WriteLine(ReplaceWithOutRegex("Java is Very Good Language and Java Used in Devlopment","Java","C#"));
    }
}

// 22.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Count uppercase, lowercase, digits, spaces, and special characters
using System;

public class HelloWorld
{
    public static void CountVal(string s){
        int UpperCase = 0;
        int LowerCase = 0;
        int Digit = 0;
        int space = 0;
        int Special = 0;
        
        foreach(var i in s){
            if(char.IsLetter(i) && char.IsUpper(i)){
                UpperCase++;
            }
            if(char.IsLetter(i) && char.IsLower(i)){
                LowerCase++;
            }
            if(char.IsDigit(i)){
                Digit++;
            }
            if(i.Equals(' ')){
                space++;
            }
            if(!char.IsLetter(i) && !char.IsDigit(i) && !i.Equals(' ')){
                Special++;
            }
        }
        Console.WriteLine($"UpperCase={UpperCase}");
        Console.WriteLine($"LowerCase={LowerCase}");
        Console.WriteLine($"Digit={Digit}");
        Console.WriteLine($"space={space}");
        Console.WriteLine($"SpecialChar={Special}");
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String");
        string s = Console.ReadLine();
        
        CountVal(s);
    }
}

// 23.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Remove all digits using char checks
using System;

public class HelloWorld
{
    public static string RemoveDigit(string str){
        string res = "";
        foreach(var i in str){
            if(char.IsLetter(i)){
                res+=i;
            }
        }
        return res;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String ");
        string s = Console.ReadLine();
        
        Console.WriteLine(RemoveDigit(s));
    }
}

// 24.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// First non-repeating character
using System;
using System.Collections.Generic;
using System.Text;

public class HelloWorld
{
    public static string NonRepeatingChar(string str){
        Dictionary<char,int> map = new Dictionary<char,int>();
        StringBuilder sb = new StringBuilder();
        foreach(var i in str){
            if(map.ContainsKey(i)){
                map[i]++;
            }else{
                map[i] = 1;
            }
        }
        foreach(var i in map){
            if(i.Value == 1){
                sb.Append(i.Key);
                break;
            }
        }
        return sb.ToString();
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the string");
        string read = Console.ReadLine();
        
        Console.WriteLine(NonRepeatingChar(read));
    }
}

// 25.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// Remove vowels efficiently.
using System;

public class HelloWorld
{
    public static string RemoveVowels(string str){
        string res = "";
        foreach(var i in str){
            if(!"aeiou".Contains(i)){
                res+=i;
            }
        }
        return res;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine ("Enter the string");
        string read = Console.ReadLine();
        
        Console.WriteLine(RemoveVowels(read));
    }
}