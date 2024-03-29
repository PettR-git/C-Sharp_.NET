namespace UtilitiesLib
{
    public class ConvertToNumerical
    {

        //Overloaded method, to convert to integer and accepting different
        //arguments
        public int ConvertStringToInteger(string str)
        {
            int num = 0;

            int.TryParse(str, out num);

            return num;
        }

        //Overloaded method, to convert to integer and evaluating the viability of 
        //the number based on a high- and lowlimit
        public int ConvertStringToInteger(string str, int lowLimit, int highLimit)
        {
            int num = ConvertStringToInteger(str);

            if(num > lowLimit && num < highLimit)
            {
                return num;
            }
            else
            {
                return -1;
            }
        }

        //Overloaded method, to convert to double and accepting different
        //arguments
        public double ConvertStringToDouble(string str)
        {
            double num = 0;

            double.TryParse(str, out num);

            return num;
        }

        //Overloaded method, to convert to double and evaluating the viability of the
        //number based on a high- and lowlimit
        public double ConvertStringToDouble(string str, int lowLimit, int highLimit)
        {
            double num = ConvertStringToInteger(str);

            if (num > lowLimit && num < highLimit)
            {
                return num;
            }
            else
            {
                return -1.0;
            }
        }
    }
}