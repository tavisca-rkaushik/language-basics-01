using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        public static int RequiredDigit(int num,int i)
        {
           int Reverse = 0;  
            while(num>0)  
            {  
                int remainder = num % 10;  
                Reverse = (Reverse * 10) + remainder;  
                num = num / 10;  
            }  
            int j=0;
            while(Reverse>0)
            {
                if(i==j)
                {
                    return Reverse%10;
                }
                else
                {
                    Reverse/=10;
                    j++;
                }
            }
            return -1;
        }
        public static bool ispossible(string str,int num)
        {
            var charsToRemove = new string[] { "?"};
            foreach (var c in charsToRemove)
            {
               str = str.Replace(c, string.Empty);
            }   
            int compare=System.Convert.ToInt32(str);
            if(compare>=num) return false;
            return true;
        }
        public static int FindDigit(string equation)
        {
            // Add your code here.
            string s1="",s2="",s3="",temp="";
              for(int i=0;i<equation.Length;i++)
              {
    	        if(equation[i]=='*')
    	        {
    		        s1=temp;
    		        temp="";
    	        }
    	        else if(equation[i]=='=')
    	        {
    		        s2=temp;
    		        temp="";
    	        }
    	        else if(i==equation.Length-1)
    	        {
    		        temp=temp+equation[i];
    		        s3=temp;
    	        }
    	        else temp=temp+equation[i];	
              }
              int num1=0,num2=0,num3=0;
              if (s1.Contains("?"))
              {
                num2=System.Convert.ToInt32(s2);
                num3=System.Convert.ToInt32(s3);
                if(num3%num2!=0)
                {
                    return -1;
                }
                num1=num3/num2;
                //Now check if it is impossible to place any digit in place of ?
                string str=s1;
                if(!ispossible(str,num1)) return -1;
                int i=0;
                for(i=0;i<s1.Length;i++)
                {
                  if(s1[i]=='?')
                  {
                    break;
                  }
                }
                //Now we need to return the digit present at ith position in num1
                 int ans=RequiredDigit(num1,i);
                 return ans;
              }
              else if(s2.Contains("?"))
              {
                  num3=System.Convert.ToInt32(s3);
                  num1=System.Convert.ToInt32(s1);
                  if(num3%num1!=0)
                  {
                    return -1;
                  }
                  num2=num3/num1;
                  //Now check if it is impossible to place any digit in place of ?
                  string str=s2;
                  if(!ispossible(str,num2)) return -1;
                  int i=0;
                  for(i=0;i<s2.Length;i++)
                  {
                    if(s2[i]=='?')
                    {
                     break;
                    }
                  }
                  int ans=RequiredDigit(num2,i);
                  return ans;
              }
              else
              {
                  num1=System.Convert.ToInt32(s1);
                  num2=System.Convert.ToInt32(s2);
                  num3=num1*num2;
                  //Now check if it is impossible to place any digit in place of ?
                  string str=s3;
                  if(!ispossible(str,num3)) return -1;
                  int i=0;
                  for(i=0;i<s3.Length;i++)
                  {
                    if(s3[i]=='?')
                    {
                     break;
                    }
                  }
                  int ans=RequiredDigit(num3,i);
                  return ans;
              }              
            throw new NotImplementedException();
        }
    }
}
