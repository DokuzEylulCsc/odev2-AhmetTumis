using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace roman_numerals                //KAYNAKÇA SONDA
{
    class Program
    {   
        static void typeWriteMessage(string text, int speed){     // I dont know what kind of adhd medicines were in my system that evantually caused this function to be written
        
            for(int i=0; i<text.Length; i++){
            
                Console.Write(text[i]);
                Thread.Sleep(speed);
            }
        }
        
        static void print(string text){   //görmezden gelebilirsiniz, muscle memoryim beni bunları yazmaya zorladı
            
            Console.WriteLine(text);

        }
        static void printn(int number){     //görmezden gelebilirsiniz v2
            
            Console.WriteLine(number);
        }


        static void decToRom(int decimalNumber){     // obv integer to roman
            
            int[] numbers = {1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000};
	        string[] symbols = {"I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M"};
	        
            int i = 12;
            Console.WriteLine("Equivalent of the number you put in Roman Numerals is: ");
	        while (decimalNumber > 0)
	        {
	          int divergency = decimalNumber / numbers[i];
	          decimalNumber = decimalNumber % numbers[i];

	          while ((divergency--) != 0){
		        Console.Write(symbols[i]);
	          }
	          i--;
	        }
            Console.WriteLine();
            Console.WriteLine();
        }

        public virtual int romToDec(string romanNumber){    // roman to decimal
           
            int res = 0; 
  
            for (int i = 0; i < romanNumber.Length; i++){ 
                
                int s1 = value(romanNumber[i]); 
  
                if (i + 1 < romanNumber.Length){ 
                    
                    int s2 = value(romanNumber[i + 1]); 
  
                    if (s1 >= s2){ 
                        res = res + s1; 
                    } 
                    else{ 
                        res = res + s2 - s1; 
                        i++; 
                    } 
                } 
                else{ 
                    res = res + s1; 
                    i++; 
                } 
            } 
  
            return res;
        }
 
        public virtual int value(char r){           // function for symbols
            if (r == 'I') 
                return 1; 
            if (r == 'V') 
                return 5; 
            if (r == 'X') 
                return 10; 
            if (r == 'L') 
                return 50; 
            if (r == 'C') 
                return 100; 
            if (r == 'D') 
                return 500; 
            if (r == 'M') 
                return 1000; 
            return -1; 
        } 
        
        static void Main(string[] args)
        {
                                                                                        
            string welcomeMessage = "Welcome to Roman Numeral Converter\n";                 //wish bash was this easy to create menus
            typeWriteMessage(welcomeMessage, 50);
            Thread.Sleep(1000);

            while(true){
                

                typeWriteMessage("\n************************************\n"+
                                 "Please choose the convertion method:\n\n"+
                                 "1. Decimal to Roman\n\n2. Roman to Decimal\n\n"+
                                 "q. Quit\n\n"+
                                 "************************************", 5);
                Thread.Sleep(1000);

                typeWriteMessage("\n1/2? ", 25);

                string selection = Console.ReadLine();

                if (selection == "1"){     // decimal to roman ******************************************************************************
                    
                    while(true){

                        Console.Clear();

                        typeWriteMessage("Please enter a value between 1 and 3999: (q to quit)\n",20);

                        string selection2 = Console.ReadLine();

                        if(selection2 == "q" || selection2 == "Q"){
                            Console.Clear();
                            break;
                        }

                        int number = (Convert.ToInt32(selection2));
                        if (number < 1 || number > 3999){
                            Console.Clear();
                            typeWriteMessage("Value must be in the range 1 - 3,999\n", 30);
                            typeWriteMessage("Please enter another value or make sure you typed it correctly.\n", 30);
                            Thread.Sleep(1500);
                        }
                        
                        else{
                            Console.Clear();
                            decToRom(number);

                            typeWriteMessage("Would you like to make another conversion? [Y/n]\n", 20);
                            string selection3 = Console.ReadLine();

                            if(selection3=="N" || selection3 == "n"){
                                Console.Clear();
                                typeWriteMessage("Returning to previous menu...\n",30);                      
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                            }
                            
                        }
                    }
                
                }
                else if(selection == "2"){   // roman to decimal**************************************************************************
                    
                    Program conversion= new Program();
                    
                    
                    
                    while(true){

                        Console.Clear();

                        print("Please enter the Roman Numeral that you want to convert: (case insensitive)(expected characteres are as follows: I,V,X,L,C,D,M,i,v,x,l,c,d,m)");
                    
                        string numeralInput = Console.ReadLine();
                        numeralInput = numeralInput.ToUpper();
                    

                        //Eligibilty checker 

                        int check = 0;

                        foreach(char c in numeralInput){

                            if (c =='I' || c=='V' || c=='X' || c=='L' || c=='C' || c=='D' || c=='M' && check >=0){
                        
                                check += 1;
                   
                            }
                        
                            else{
                                Console.Clear();
                                check -=10000;
                                Console.WriteLine("You have entered an unexpected value, please try again or take a look at the rule set..");
                                break;

                            }

                        }
                        
                        if (check >= 1){
                        Console.Clear();
                        Console.WriteLine("Integer form of Roman Numeral is: "+ conversion.romToDec(numeralInput));
                        }

                        Console.WriteLine();
                        Thread.Sleep(1000);
                        Console.WriteLine("Would you like to make another conversion? [Y/n]\n", 20);
                        string selection4 = Console.ReadLine();

                        if(selection4=="N" || selection4 == "n"){
                            Console.Clear();
                            typeWriteMessage("Returning to previous menu...\n",30);                      
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }

                    }

                }
                else if(selection == "q" || selection == "Q"){  //quit **********************************************************************************
                
                    typeWriteMessage("Sorry to see you go\n", 25);
                    break;
                }
                else{                                         //invalid input *********************************************************************************
                    print("Please enter either 1 or 2...");
                    continue;
                }
                
            }
            
        }
    
    }

}


/*    KAYNAKÇA
 *    
 *    https://www.youtube.com/watch?v=dQw4w9WgXcQ     :) no college students program gets built without an indian angels youtube tutorial
 *    https://en.wikipedia.org/wiki/Roman_numerals
 *    https://www.geeksforgeeks.org/converting-one-string-using-append-delete-last-operations/
 *    https://stackoverflow.com/questions/12967896/converting-integers-to-roman-numerals-java    aklımda bişi oluşması için başka dilde baktım
 *    https://www.dotnetperls.com/loop-chars
 *    https://translate.google.com/#view=home&op=translate&sl=auto&tl=en&text=kar%C5%9F%C4%B1l%C4%B1k  I literally forgot what karşılık meant in Eng
 *    http://www.blackwasp.co.uk/RomanToNumber_2.aspx  scrapped but worth a mention
 *    
 */