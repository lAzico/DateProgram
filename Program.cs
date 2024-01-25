public class DateApp
{
    //This method exists as a way for a user who entered the date in
    //without forward slashes to be able to use the program
    public static string FormatString(string birthday)
    {
        if (birthday != null && !birthday.Contains("/"))
        {
            //Substrings for date formatting
            string day = birthday.Substring(0,2);
            string month = birthday.Substring(2,2); 
            string year = birthday.Substring(4);
      
            string newString = (day + "/" + month + "/" +  year);
            return newString;
        }
        else
        {
            return birthday;
        }
    }

    public static int DaysSinceBirthday(DateTime birthday)
    {
        //Retrieve the current day	
        DateTime currentDate = DateTime.Now;

        //Retrieve the Time between the dates
        var numberOfDays = currentDate.Subtract(birthday);

        //Grab the number of days from the retrieved value
        int daysSinceBirthday = ((int)numberOfDays.TotalDays);

        return daysSinceBirthday;
    }

    //This method exists to validate the format of the date and to check if it's a real date
    //The method accepts a string, checks if the date is real and then outputs that date as a DateTime object
    public static bool CheckDate(string date, out DateTime parsedDate)
    {
        //Try parse method, if it succeeds then the string date is recognised
        bool dateIsValid = DateTime.TryParse(date, out parsedDate);
        return dateIsValid;
    }

    public static int DaysUntilBirthday(DateTime birthday)
    {
        DateTime currentDate = DateTime.Now;
        double daysUntilBirthday = 0;

        //If the birthday has passed
        if (currentDate.Month > birthday.Month || currentDate.Month == birthday.Month && currentDate.Day >= birthday.Day) 
        {
            int nextBirthdayYear = currentDate.Year + 1;
            //Make a new DateTime variable with the next birthday year and the user's birthday month and day
            DateTime nextBirthday = new DateTime(nextBirthdayYear, birthday.Month, birthday.Day);

            //Subtract the current date from the birthday date to get the total days
            daysUntilBirthday = nextBirthday.Subtract(currentDate).TotalDays;
        }
        else
        {
            int nextBirthdayYear = currentDate.Year;
            DateTime nextBirthday = new DateTime(nextBirthdayYear, birthday.Month, birthday.Day);
            daysUntilBirthday = nextBirthday.Subtract(currentDate).TotalDays;
        }
        return (int)daysUntilBirthday;
    }

    public static void Main()
    {
        Console.WriteLine("Hi, please enter your date of birth in the format 'dd/mm/yyyy'");
        string inputDate = FormatString(Console.ReadLine());

        try
        {
            //Check whether the date entered is a valid date
            //Output a boolean with date
            if (CheckDate(inputDate, out var birthday))
            {
                int daysSinceBirthday = DaysSinceBirthday(birthday);
                //.25 accounting for leap year every 4 years
                double ageOfUser = DaysSinceBirthday(birthday) / 365.25;
                int daysUntilBirthday = DaysUntilBirthday(birthday);

                if (ageOfUser > 18) 
                {
                    Console.WriteLine("Over 18");
                }
                else
                {
                    Console.WriteLine("Under 18");
                }
                Console.WriteLine("It has been "  + daysSinceBirthday + " full days since date of birth");
                Console.WriteLine("There are " + (int)daysUntilBirthday + " full days until your next birthday");
            }
        }
        catch
        {
            Console.WriteLine("Invalid date format entered");
            return;
        }
    }
}