namespace LimeAirlinesSystem.Data
{
    public class DataConstants
    {
        public class PassangerConstants
        {
            public const int FullNameMinLength = 2;
            public const int FullNameMaxLength = 50;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
            public const int PassangerMaxLength = 20;
        }

        public class PlaneConstants
        {
            public const int PlaneBrandAndModelMinLength = 1;
            public const int PlaneBrandAndModelMaxLength = 30;
            public const int NumberofSeatsMinValue = 4;
            public const int NumberofSeatsMaxValue = 1000;
            public const int PlaneMinValue = 1950;
            public const int PlaneMaxValue = 2100;
        }


        public class FlightConstants
        {
            public const int FlightLocationMinLength = 2;
            public const int FlightLocationMaxLength = 50;
            public const int FlightPriceMinValue = 5;
            public const int FlightPriceMaxValue = 10000;
            public const int TransferCountMinValue = 0;
            public const int TransferCountMaxValue = 2;
        }


        public class CategoryConstants
        {
            public const int CategoryMaxLength = 20;
        }

        public class BaggageConstants
        {
            public const int SmallBaggagePrice = 20;
            public const int MediumBaggagePrice = 50;
            public const int LargeBaggagePrice = 60;
            public const int BaggageMinCount = 0;
            public const int BaggageMaxCount = 5;
        }

        public class FAQConstants
        {
            public const int InformationDescriptionMinLength = 10;
            public const int InformationDescriptionMaxLength = 1000;
            public const int InformationTitleMaxLength = 50;
            public const int InformationTitleMinLength = 5;
        }
    }
}