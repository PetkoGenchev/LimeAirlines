namespace LimeAirlinesSystem.Data
{
    public class DataConstants
    {
        public class Passanger
        {
            public const int FullNameMinLength = 2;
            public const int FullNameMaxLength = 50;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
            public const int PassangerMaxLength = 20;
        }

        public class Plane
        {
            public const int PlaneBrandAndModelMinLength = 1;
            public const int PlaneBrandAndModelMaxLength = 30;
            public const int NumberofSeatsMinValue = 4;
            public const int NumberofSeatsMaxValue = 1000;
            public const int PlaneMinValue = 1950;
            public const int PlaneMaxValue = 2100;
        }


        public class Flight
        {
            public const int FlightLocationMinLength = 2;
            public const int FlightLocationMaxLength = 50;
            public const int FlightPriceMinValue = 5;
            public const int FlightPriceMaxValue = 10000;
            public const int TransferCountMinValue = 0;
            public const int TransferCountMaxValue = 2;
        }


        public class Category
        {
            public const int CategoryMaxLength = 20;
        }
    }
}