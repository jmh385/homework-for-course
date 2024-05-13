using System; 
using System.Collections.Generic;  

class NumericalExpression{
    private readonly int num;
    // this is for the english language however, to add more you simply need to change these numers to any language
    private readonly string[] ones = ["Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", 
    "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"];

    private readonly string[] tens = ["Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];

    private readonly string hunderds = "Hundred";


    private string[] powersOfTen = ["", "Thousand", "Million", "Billion", "Trillion"];
    // to add higher powers of ten simply add to this list
    
    public NumericalExpression(int num){
        this.num = num;
    }

    public override string ToString(){
        if(num == 0){
            return "Zero";
        }
        string st = ""; // initilalise return string
        int copyNum = num; // make copy of number so it does not get destroyed in the process
        int digitCount = 0; // counts the number of digits so far

        while(copyNum > 0)
        {
            //counts in sets of three

            int savedFirstDigit = 0; // the first digit in the set of three needs to be saved in case second digit is one 
            int digit = copyNum%10;
            if(digit != 0)
            {
                switch (digitCount % 3)
                {
                    case 0:
                        //first digit in set of three
                        st = ones[digit] + " " + powersOfTen[digitCount/3] +  " "  + st; // here we also add the strength in powers of ten of the set
                        savedFirstDigit = digit;
                        break;
                    case 1:
                        //second digit
                        if(digit == 1){
                            //if digit is one we must go to the teens
                            st = ones[10+savedFirstDigit] + " " + st;
                        }
                        else{
                            //otherwise in the tens
                            st = tens[digit-2] + " " + st;
                        }
                        break;
                    case 2:
                        //third digit
                        st = ones[digit] + " " + hunderds + " " + st;
                        break;
                }
            }
            digitCount++;
            copyNum /= 10;
        }
        return st;
    }

}