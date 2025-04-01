namespace aztro_cchardos_back_group2.Application.DTOs.Responses.Statistics
{
    public class DestinationStatistics
    {
        public string FirstCityName { get; set; } = "";
        public string SecondCityName { get; set; } = "";
        public int TimesShown { get; set; }
        public DateTime LastShownDate { get; set; }
    }
}