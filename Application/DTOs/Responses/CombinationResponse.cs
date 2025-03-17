namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class CombinationResponse
    {
        public int Id { get; set; }
        public int DestinationOptionId { get; set; }
        public int ClimateOptionId { get; set; }
        public int ActivityOptionId { get; set; }
        public int AccommodationOptionId { get; set; }
        public int DurationOptionId { get; set; }
        public int AgeOptionId { get; set; }
        public bool Success { get; set; }
        public CityResponse FirstCity { get; set; } = null!;
        public CityResponse SecondCity { get; set; } = null!;
        public QuestionOptionResponse DestinationOption { get; set; } = null!;
        public QuestionOptionResponse ClimateOption { get; set; } = null!;
        public QuestionOptionResponse ActivityOption { get; set; } = null!;
        public QuestionOptionResponse AccommodationOption { get; set; } = null!;
        public QuestionOptionResponse DurationOption { get; set; } = null!;
        public QuestionOptionResponse AgeOption { get; set; } = null!;
    }
}