using System;

namespace CoreLibrary.MethodExtensions
{
    public static class ValidatorExtensions
    {
        public static bool IsValidCitizenshipNumber(this string citizenshipNumber)
        {
            if (string.IsNullOrWhiteSpace(citizenshipNumber) || citizenshipNumber.Length < 11)
                return false;
            else if (citizenshipNumber.Substring(0, 1) == "0")
                return false;

            int firstSum = Convert.ToInt32(citizenshipNumber[0].ToString()) + Convert.ToInt32(citizenshipNumber[2].ToString()) + Convert.ToInt32(citizenshipNumber[4].ToString()) + Convert.ToInt32(citizenshipNumber[6].ToString()) + Convert.ToInt32(citizenshipNumber[8].ToString());
            int secondSum = Convert.ToInt32(citizenshipNumber[1].ToString()) + Convert.ToInt32(citizenshipNumber[3].ToString()) + Convert.ToInt32(citizenshipNumber[5].ToString()) + Convert.ToInt32(citizenshipNumber[7].ToString());

            if ((((firstSum * 7) - secondSum) % 10).ToString() != citizenshipNumber[9].ToString())
                return false;

            int thirdSum = 0;
            for (int i = 0; i < 10; i++)
                thirdSum += Convert.ToInt32(citizenshipNumber[i].ToString());

            if ((thirdSum % 10).ToString() != citizenshipNumber[10].ToString())
                return false;

            return true;
        }
    }
}
